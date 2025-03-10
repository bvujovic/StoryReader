namespace StoryReader.Classes
{
    public class Voice
    {
        public required string Character { get; set; }
        public required string VoiceName { get; set; }

        public override string ToString()
            => $"{Character}: {VoiceName}";
    }
}
