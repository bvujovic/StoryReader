using StoryReader.Classes;
using System.ComponentModel;
using System.Speech.Synthesis;
using System.Text.Json;

namespace StoryReader
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                dgvVoices.DataSource = voices;
                dgvVoices.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVoices.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvVoices.Columns[1].HeaderText = "Voice Name";
                cmbVoices.Items.Clear();
                foreach (var v in synth.GetInstalledVoices())
                    cmbVoices.Items.Add(v.VoiceInfo.Name);
                if (cmbVoices.Items.Count > 0)
                    cmbVoices.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private readonly BindingList<Voice> voices = [];

        private SpeechSynthesizer synth = new() { Volume = 100, Rate = 0 };

        private readonly string headerSeparator = "*****";

        private string SpeechText
        {
            get
            {
                // ako je selektovan deo teksta - citaj taj deo
                if (txtIn.SelectionLength != 0)
                    return txtIn.SelectedText;
                // ako je kursor na kraju - citaj ceo tekst (od separatora zaglavlja i price)
                if (txtIn.SelectionStart == txtIn.TextLength)
                {
                    var idx = txtIn.Text.IndexOf(headerSeparator);
                    if (idx != -1)
                        return txtIn.Text[idx..];
                    else
                        return txtIn.Text;
                }
                // ako nije selektovano nista, niti je kursor na kraju teksta - citaj od kursora
                return txtIn.Text[txtIn.SelectionStart..];
            }
        }

        private string? SpeechVoice
            => cmbVoices.SelectedItem?.ToString();

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            try
            {
                if (synth.State == SynthesizerState.Speaking)
                    synth.SpeakAsyncCancelAll();
                synth.SelectVoice(SpeechVoice);
                synth.Rate = (int)numRate.Value;
                synth.Volume = (int)numVolume.Value;
                synth.SpeakAsync(SpeechText);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            try
            {
                //var defaultVoice = voices.FirstOrDefault(it => it.Character == "default" || it.Character == "def")
                //    ?.VoiceName;
                //if (cmbVoices.SelectedItem is string voice)
                //    TextFs.SplitSSMLs(SpeechText, voice);
                var parts = TextFs.SplitSSMLs(SpeechText);
                TextFs.VoicesForCharacters(parts, voices);
                TextFs.AddSSMLroot(parts);
                txtOut.Clear();
                foreach (var p in parts)
                {
                    speaker.AddToSpeak(p);
                    txtOut.Text += p + Environment.NewLine;
                }

                //if (cmbVoices.SelectedItem != null)
                //    TextFs.SplitSSMLs(SpeechText, cmbVoices.SelectedItem.ToString()!);

                //var s = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\">\r\n\r\n"
                //    + txtIn.SelectedText + "\r\n\r\n</speak>";
                //foreach (var v in voices)
                //    s = s.Replace($"<voice name=\"{v.Character}\">", $"\r\n<voice name=\"{v.VoiceName}\">");
                //s = s.Replace("</voice>", "</voice>\r\n");
                //speaker.AddToSpeak(s);

                //var v = dgvVoices.CurrentRow!.DataBoundItem as Voice;
                //voices.Add(new Voice { Character = "x", VoiceName = "bla" });

                //synth.Rate = (int)numRate.Value;
                //synth.Volume = (int)numVolume.Value;
                //synth.SelectVoice(SpeechVoice);
                //var s = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\">\r\n\r\n"
                //    + txtIn.SelectedText + "\r\n\r\n</speak>";
                //foreach (var v in voices)
                //    s = s.Replace($"<voice name=\"{v.Character}\">", $"\r\n<voice name=\"{v.VoiceName}\">");
                //s = s.Replace("</voice>", "</voice>\r\n");
                //txtOut.Text = s;
                //prompt = synth.SpeakSsmlAsync(s);
                //synth.Resume();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // u content od meta-speech staviti JSON podatke o glasovima likova
        // <meta name="speech" content="[{...},{...}]">

        private Prompt prompt;
        private Speaker speaker = new();

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                speaker.Stop();
                //synth.SpeakAsyncCancelAll();
                //synth.Volume = (int)numVolume.Value;

                //var start = DateTime.Now;
                ////synth.Pause();
                //synth.SpeakAsyncCancelAll();
                ////synth.SpeakAsyncCancel(prompt);
                //synth.Dispose();
                //synth = new SpeechSynthesizer();
                //System.Diagnostics.Debug.WriteLine((DateTime.Now - start).TotalSeconds);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnCopyVoiceName_Click(object sender, EventArgs e)
        {
            try
            {
                var voiceName = cmbVoices.SelectedItem?.ToString();
                if (voiceName != null)
                    Clipboard.SetText(voiceName);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileName != null)
                {
                    File.WriteAllText(fileName, txtIn.Text);
                    MessageBox.Show("Done.");
                }
                else
                    throw new Exception("You have to open a file first.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string? fileName = null;

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtIn.Text = File.ReadAllText(fileName = ofd.FileName);
                    ReadCharVoices();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ReadCharVoices()
        {
            if (txtIn.Lines.Length >= 2 && txtIn.Lines[1] == headerSeparator)
            {
                var vcs = JsonSerializer.Deserialize<Voice[]>(txtIn.Lines[0]);
                if (vcs == null)
                    return;
                voices.Clear();
                foreach (var v in vcs)
                    voices.Add(v);
            }
        }

        private void BtnCopyVoicesJson_Click(object sender, EventArgs e)
        {
            try
            {
                var json = JsonSerializer.Serialize(voices);
                Clipboard.SetText(json);
                txtIn.Lines[0] = json; //! NE RADI
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnApplyVoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVoices.CurrentRow?.DataBoundItem is not Voice v)
                    throw new Exception("You have to select a voice to be able to apply it to selected text.");
                if (txtIn.SelectionLength == 0)
                    throw new Exception("You have to select some text to be able to apply selected voice.");
                var selEnd = txtIn.SelectionStart + txtIn.SelectionLength;
                var s = txtIn.Text;
                s = s.Insert(selEnd, "</voice>");
                s = s.Insert(txtIn.SelectionStart, $"<voice name=\"{v.Character}\">");
                txtIn.Text = s;
                txtIn.Select(selEnd, 0);
                txtIn.ScrollToCaret();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnPauseResume_Click(object sender, EventArgs e)
        {
            var s = speaker.Synth;
            btnPauseResume.Text = s.State == SynthesizerState.Paused ? "Pause" : "Play";
            if (s.State == SynthesizerState.Paused)
                s.Resume();
            else
                s.Pause();
        }

        private void NumRate_ValueChanged(object sender, EventArgs e)
        {
            speaker.Synth.Rate = (int)numRate.Value;
        }

        private void NumVolume_ValueChanged(object sender, EventArgs e)
        {
            speaker.Synth.Volume = (int)numVolume.Value;
        }

        private void CmbVoices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
