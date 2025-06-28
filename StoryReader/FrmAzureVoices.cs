using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using StoryReader.Classes;
using System.ComponentModel;

namespace StoryReader
{
    public partial class FrmAzureVoices : Form
    {
        public FrmAzureVoices()
        {
            InitializeComponent();
            TestsFolder = Path.Combine(Utils.GetAzureSoundsFolderName(), "_tests");
            TestsTextFile = Path.Combine(TestsFolder, "_test.txt");
            if (File.Exists(TestsTextFile))
                txtTest.Text = File.ReadAllText(TestsTextFile);
            TestsSoundFile = Path.Combine(TestsFolder, "_test.mp3");
        }

        public string TestsFolder { get; private set; }
        public string TestsTextFile { get; private set; }
        public string TestsSoundFile { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Voices
        {
            get => txtVoices.Text.Trim();
            set => txtVoices.Text = value.Trim();
        }

        private void BtnListOfAllAzureVoices_Click(object sender, EventArgs e)
        {
            Utils.GoToLink("https://learn.microsoft.com/en-us/azure/ai-services/speech-service/language-support?tabs=tts#multilingual-voices");
        }

        // https://speech.microsoft.com/portal/voicegallery

        private async void BtnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                var config = SpeechConfig.FromSubscription(Utils.GetAzureKey(), "westeurope");
                config.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Audio16Khz32KBitRateMonoMp3);
                using var fileStream = AudioConfig.FromWavFileOutput(TestsSoundFile);
                using var synt = new SpeechSynthesizer(config, fileStream);
                var result = await synt.SpeakSsmlAsync(txtTest.SelectedText);
                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    MessageBox.Show("Done.");
                else
                    throw new Exception($"Error: {result.Reason}");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FrmAzureVoices_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                File.WriteAllText(TestsTextFile, txtTest.Text);
        }
    }
}
