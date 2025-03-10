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

        private readonly SpeechSynthesizer synth = new() { Volume = 100, Rate = 0 };

        private readonly string headerSeparator = "*****";

        //BindingList<Voice> voices = new BindingList<Voice>
        //{
        //    new() { Character = "mom", VoiceName = "Hazel" }
        //};

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
                //var v = dgvVoices.CurrentRow!.DataBoundItem as Voice;
                //voices.Add(new Voice { Character = "x", VoiceName = "bla" });

                synth.Rate = (int)numRate.Value;
                synth.Volume = (int)numVolume.Value;
                synth.SelectVoice(SpeechVoice);
                var s = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\">\r\n\r\n"
                    + txtIn.SelectedText + "\r\n\r\n</speak>";
                s = s.Replace("<voice name=\"cousin\">", "<voice name=\"Microsoft Mark\">");
                s = s.Replace("<voice name=\"mom\">", "<voice name=\"Microsoft Hazel Desktop\">");
                txtOut.Text = s;
                synth.SpeakSsmlAsync(s);

                //bsVoices.Add(new Voice { Character = "cousin", VoiceName = "Microsoft Mark" });
                //var c = new Voice { Character = "cousin", VoiceName = "Microsoft Mark" };
                //var d = new Voice { Character = "default", VoiceName = "Microsoft David Desktop" };
                //var vs = new Voice[] { c, d };
                //var json = JsonSerializer.Serialize(vs);
                //var meta = $"<meta name='speech' content='{json}'";
                //var vcs = JsonSerializer.Deserialize<Voice[]>(json);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // u content od meta-speech staviti JSON podatke o glasovima likova
        // <meta name="speech" content="[{...},{...}]">

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                //synth.Pause();
                //synth.SpeakAsyncCancel(ppp);
                synth.SpeakAsyncCancelAll();
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
                txtIn.Lines[0] = json;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
