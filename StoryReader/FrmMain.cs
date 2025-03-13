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
                foreach (var v in speaker.Synth.GetInstalledVoices())
                    cmbVoices.Items.Add(v.VoiceInfo.Name);
                if (cmbVoices.Items.Count > 0)
                    cmbVoices.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private readonly BindingList<Voice> voices = [];

        //private SpeechSynthesizer synth = new() { Volume = 100, Rate = 0 };

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

        //private string? SpeechVoice
        //    => cmbVoices.SelectedItem?.ToString();

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            try
            {
                //if (synth.State == SynthesizerState.Speaking)
                //    synth.SpeakAsyncCancelAll();
                //synth.SelectVoice(SpeechVoice);
                //synth.Rate = (int)numRate.Value;
                //synth.Volume = (int)numVolume.Value;
                //synth.SpeakAsync(SpeechText);

                var parts = TextFs.SplitSSMLs(SpeechText);
                TextFs.VoicesForCharacters(parts, voices);
                TextFs.AddSSMLroot(parts);
                txtOut.Clear();
                foreach (var p in parts)
                {
                    speaker.AddToSpeak(p);
                    txtOut.Text += p + Environment.NewLine;
                }
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

        //private Prompt prompt;
        private readonly Speaker speaker = new();

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                speaker.Stop();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnChangeVoiceName_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVoices.CurrentRow?.DataBoundItem is Voice v
                    && cmbVoices.SelectedItem is string voiceName)
                {
                    v.VoiceName = voiceName;
                    dgvVoices.Refresh();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DisplayStatus(string s)
        {
            lblLastStatus.Text = s;
            lblLastStatus.BackColor = Color.Green;
            timStatus.Start();
        }

        private void TimStatus_Tick(object sender, EventArgs e)
        {
            timStatus.Stop();
            lblLastStatus.BackColor = SystemColors.Control;
        }

        private void TsmiFileSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileName != null)
                {
                    File.WriteAllText(fileName, txtIn.Text);
                    DisplayStatus("Done.");
                }
                else
                    throw new Exception("You have to open a file first.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string? fileName = null;

        private void TsmiFileOpen_Click(object sender, EventArgs e)
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

        private void BtnInsertVoicesJson_Click(object sender, EventArgs e)
        {
            try
            {
                var idx = txtIn.Text.IndexOf(headerSeparator);
                if (idx != -1)
                {
                    txtIn.Text = txtIn.Text[(idx + headerSeparator.Length + 1)..];
                }
                var json = JsonSerializer.Serialize(voices);
                txtIn.Text = $"{json}\r\n{headerSeparator}\r\n{txtIn.Text}";
                //Clipboard.SetText(json);
                //txtIn.Lines[0] = json; //! NE RADI
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnApplyVoice_Click(object sender, EventArgs e)
        {
            try
            {
                int idxStart, lenInsert;
                if (dgvVoices.CurrentRow?.DataBoundItem is not Voice v)
                    throw new Exception("You have to select a voice to be able to apply it to selected text.");
                if (txtIn.SelectionLength == 0)
                {
                    //var tweenQuot = false;
                    if (txtIn.SelectionStart > 0 && txtIn.SelectionStart < txtIn.TextLength)
                    {
                        idxStart = txtIn.Text.LastIndexOf('"', txtIn.SelectionStart - 1);
                        var idxEnd = txtIn.Text.IndexOf('"', txtIn.SelectionStart);
                        if (idxStart != -1 && idxEnd != -1)
                        {
                            //tweenQuot = true;
                            lenInsert = InsertVoiceTags(idxStart, idxEnd - idxStart + 1, v.Character);
                            //var s = txtIn.Text;
                            //s = s.Insert(idxEnd, "</voice>");
                            FocusOnText(idxStart, lenInsert);
                            return;
                        }
                    }
                    //if (!tweenQuot)
                    throw new Exception("You have to select some text (or put cursor between quotation marks) to be able to apply selected voice.");
                }
                idxStart = txtIn.SelectionStart;
                var selLen = txtIn.SelectionLength;
                //var selEnd = selStart + selLen;
                //var s = txtIn.Text;
                //s = s.Insert(selStart + selLen, "</voice>");
                //var startTag = $"<voice name=\"{v.Character}\">";
                //s = s.Insert(txtIn.SelectionStart, startTag);
                //txtIn.Text = s;
                lenInsert = InsertVoiceTags(idxStart, selLen, v.Character);
                //txtIn.Select(selEnd, 0);
                //txtIn.ScrollToCaret();
                FocusOnText(idxStart, lenInsert);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int InsertVoiceTags(int idxStart, int selLen, string character)
        {
            var s = txtIn.Text;
            s = s.Insert(idxStart + selLen, "</voice>");
            var startTag = $"<voice name=\"{character}\">";
            //s = s.Insert(txtIn.SelectionStart, startTag);
            s = s.Insert(idxStart, startTag);
            txtIn.Text = s;
            return startTag.Length + selLen + "</voice>".Length;
        }

        private void FocusOnText(int idxStart, int length)
        {
            txtIn.Select(idxStart, length);
            txtIn.ScrollToCaret();
            txtIn.Focus();
        }

        private void BtnPauseResume_Click(object sender, EventArgs e)
        {
            var s = speaker.Synth;
            var paused = s.State == SynthesizerState.Paused;
            btnPauseResume.Text = paused ? "Pause" : "Play";
            btnPauseResume.BackColor = paused ? SystemColors.Control : Color.LightBlue;
            if (paused)
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

        private void PnlLeftTop_Click(object sender, EventArgs e)
        {
            txtIn.Select();
        }

        private void Search_Click(object sender, EventArgs e)
            => TxtSearch_TextChanged(this, EventArgs.Empty);

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var str = txtSearch.Text;
            if (str.Length == 0)
            {
                lblSearchResults.Text = "";
                return;
            }
            var idx = txtIn.Text.IndexOf(str);
            if (idx > -1)
            {
                txtIn.Select(idx, str.Length);
                lblSearchResults.Text = "✅";
            }
            else
            {
                txtIn.Select(0, 0);
                lblSearchResults.Text = "❌";
            }

        }

        private void BtnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIn.SelectionLength == 0)
                    throw new Exception();
                var s = txtIn.Text[..txtIn.SelectionStart];
                s += txtReplace.Text;
                s += txtIn.Text[(txtIn.SelectionStart + txtIn.SelectionLength)..];
                txtIn.Text = s;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
