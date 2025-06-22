using NAudio.Wave;

namespace StoryReader.Classes
{
    public class Player
    {
        private Part? part;
        private readonly Speaker speaker = new();
        private WaveOutEvent? waveOutDevice;
        private AudioFileReader? audioFileReader;

        public async Task Play(Part part, int volume, int rate)
        {
            this.part = part;
            if (VoiceHelpers.IsAzureVoice(part.Voice.VoiceName))
            {
                if (waveOutDevice == null)
                {
                    var mp3FilePath = AzureSounds.GetFile(part);
                    mp3FilePath ??= await AzureSounds.CreateFile(part);
                    waveOutDevice = new WaveOutEvent();
                    waveOutDevice.PlaybackStopped += OnPlaybackStopped;
                    //var mp3FilePath = "c:\\Users\\sosos\\Music\\Hurricane - Favorito.mp3";
                    audioFileReader = new AudioFileReader(mp3FilePath);
                    waveOutDevice.Init(audioFileReader);
                }
                waveOutDevice.Volume = volume / 100.0f;
                waveOutDevice.Play(); // Start or resume playback
            }
            else
                speaker.Speak(part.ToSSML());
        }

        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }
            if (e.Exception != null)
                MessageBox.Show($"Playback error: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Stopped?.Invoke(this, e);
        }

        public event EventHandler Stopped;
    }
}
