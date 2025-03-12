using System.Speech.Synthesis;

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

        //public int Rate
        //{
        //    get { return synth.Rate; }
        //    set { synth.Rate = value; }
        //}

        //public int Volume
        //{
        //    get { return synth.Volume; }
        //    set { synth.Volume = value; }
        //}

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
