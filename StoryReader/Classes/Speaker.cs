using System.Speech.Synthesis;

// G: windows languages voices
// https://support.microsoft.com/en-us/windows/appendix-a-supported-languages-and-voices-4486e345-7730-53da-fcfe-55cc64300f01

// ChatGPT - SpeechSynthesizer (text to speech, C#)
// Command Prompt (Admin):
// reg copy "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\SPEECH_OneCore\Voices\Tokens\TTS_MS_EN-US_MARK_11.0" "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\SPEECH\Voices\Tokens\TTS_MS_EN-US_MARK_11.0" /s /f

namespace StoryReader.Classes
{
    public class Speaker
    {
        private readonly SpeechSynthesizer synth = new();

        public SpeechSynthesizer Synth => synth;

        public void Speak(string ssml)
        {
            synth.SpeakSsmlAsync(ssml);
        }

        public void Stop()
        {
            synth.SpeakAsyncCancelAll();
        }
    }
}
