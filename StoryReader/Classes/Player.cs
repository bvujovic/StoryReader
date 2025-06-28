using NAudio.Wave;
using System.Speech.Synthesis;

namespace StoryReader.Classes
{
    public enum PlayerState
    {
        Ready = 0,
        Playing = 1,
        Paused = 2,
    }

    public class Player
    {
        private Part? part;
        public bool StoppedByUser { get; private set; }
        public PlayerState State
        {
            get
            {
                if (part == null)
                    return PlayerState.Ready;
                if (AzureSounds.IsAzureVoice(part))
                {
                    if (waveOutDevice == null)
                        return PlayerState.Ready;
                    else
                        return ToState(waveOutDevice.PlaybackState);
                }
                else
                    return ToState(synth.State);
            }
        }

        private static PlayerState ToState(PlaybackState ps)
        {
            return ps switch
            {
                //PlaybackState.Stopped => PlayerState.Ready,
                PlaybackState.Playing => PlayerState.Playing,
                PlaybackState.Paused => PlayerState.Paused,
                _ => PlayerState.Ready,
            };
        }

        private static PlayerState ToState(SynthesizerState ss)
        {
            return ss switch
            {
                SynthesizerState.Speaking => PlayerState.Playing,
                SynthesizerState.Paused => PlayerState.Paused,
                _ => PlayerState.Ready,
            };
        }

        private WaveOutEvent? waveOutDevice;
        private AudioFileReader? audioFileReader;

        // G: windows languages voices
        // https://support.microsoft.com/en-us/windows/appendix-a-supported-languages-and-voices-4486e345-7730-53da-fcfe-55cc64300f01
        // ChatGPT - SpeechSynthesizer (text to speech, C#)
        // Command Prompt (Admin):
        // reg copy "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\SPEECH_OneCore\Voices\Tokens\TTS_MS_EN-US_MARK_11.0" "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\SPEECH\Voices\Tokens\TTS_MS_EN-US_MARK_11.0" /s /f
        private readonly SpeechSynthesizer synth = new();

        public void Init()
        {
            synth.SpeakCompleted += Synth_SpeakCompleted;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<InstalledVoice> GetInstalledVoices()
            => synth.GetInstalledVoices();

        public int Volume
        {
            get
            {
                if (part == null)
                    return synth.Volume;
                if (AzureSounds.IsAzureVoice(part))
                    return waveOutDevice != null ? (int)Math.Round(waveOutDevice.Volume * 100) : 0;
                else
                    return synth.Volume;
            }
            set
            {
                if (part == null)
                    return;
                if (AzureSounds.IsAzureVoice(part))
                {
                    if (waveOutDevice != null)
                        waveOutDevice.Volume = value / 100f;
                }
                else
                    synth.Volume = value;
            }
        }

        public int Rate
        {
            get
            {
                if (part == null)
                    return synth.Rate;
                if (AzureSounds.IsAzureVoice(part))
                    return 0;
                else
                    return synth.Rate;
            }
            set
            {
                if (part == null || AzureSounds.IsAzureVoice(part))
                    return;
                synth.Rate = value;
            }
        }

        public async Task Play(Part part, int volume, int rate)
        {
            this.part = part;
            StoppedByUser = false;
            if (AzureSounds.IsAzureVoice(part))
            {
                if (waveOutDevice == null)
                {
                    var mp3FilePath = AzureSounds.GetFile(part);
                    mp3FilePath ??= await AzureSounds.CreateFile(part);
                    waveOutDevice = new WaveOutEvent();
                    waveOutDevice.PlaybackStopped += OnPlaybackStopped;
                    audioFileReader = new AudioFileReader(mp3FilePath);
                    waveOutDevice.Init(audioFileReader);
                }
                waveOutDevice.Volume = volume / 100.0f;
                waveOutDevice.Play(); // Start or resume playback
            }
            else
                synth.SpeakSsmlAsync(part.ToSSML());
        }

        private void Synth_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            Stopped?.Invoke(this, e);
        }

        public void Pause()
        {
            if (part == null)
                return;
            if (AzureSounds.IsAzureVoice(part))
                waveOutDevice?.Pause();
            else
                synth.Pause();
        }

        public void Resume()
        {
            if (part == null)
                return;
            if (AzureSounds.IsAzureVoice(part))
                waveOutDevice?.Play();
            else
                synth.Resume();
        }

        public void Stop()
        {
            if (part == null)
                return;
            StoppedByUser = true;
            if (AzureSounds.IsAzureVoice(part))
                waveOutDevice?.Stop();
            else
                synth.SpeakAsyncCancelAll();
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
