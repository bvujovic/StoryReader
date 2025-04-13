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
        private readonly Queue<string> speakerSounds = [];

        private readonly SpeechSynthesizer synth = new();

        public SpeechSynthesizer Synth => synth;

        public Speaker()
        {
            synth.SpeakCompleted += Synth_SpeakCompleted;
        }

        private void Synth_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            if (speakerSounds.Count > 0)
                speakerSounds.Dequeue();
            if (speakerSounds.Count > 0)
                synth.SpeakSsmlAsync(speakerSounds.First());
            //Speak2(speakerSounds.Last().ToString());

            //if (speakerSounds.Count > 0)
            //    synth.SpeakAsync(speakerSounds.Dequeue().ToString());
        }

        public void Speak(string ssml)
        {
            synth.SpeakSsmlAsync(ssml);
        }

        /// <summary>Add string </summary>
        public void AddToSpeak(string text)
        {
            speakerSounds.Enqueue(text);
            if (synth.State != SynthesizerState.Speaking)
                synth.SpeakSsmlAsync(text);
            //Speak2(text);

            //if (synth.State == SynthesizerState.Speaking)
            //    speakerSounds.Enqueue(text);
            //else
            //    synth.SpeakAsync(text);
        }

        public void Stop()
        {
            synth.SpeakAsyncCancelAll();
            speakerSounds.Clear();
        }

        //public void Speak(SpeakerSounds sound)
        //{
        //    if (speakerSounds.Count > 0 && speakerSounds.Last() == sound.ToString())
        //        return;
        //    Speak(sound.ToString());
        //}
    }
}
