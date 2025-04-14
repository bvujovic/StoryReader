namespace StoryReader.Classes
{
    public class Voice
    {
        /// <summary>Name of the character for a story: default, husband, friend, John...</summary>
        public required string Character { get; set; }
        /// <summary>Name of the installed voice that will be used for the character in a story: Microsoft David Desktop, Microsoft Heera</summary>
        public required string VoiceName { get; set; }

        // Background color of the text/part for this character/voice
        public string? Color { get; set; }

        //public string Volume { get; set; } = "default";
        public string? Volume { get; set; }
        // silent, x-low, low, medium, loud, x-loud, default

        public string? Pitch { get; set; }
        // x-low, low, medium, high, x-high, default.

        public string? Rate { get; set; }

        public override string ToString()
            => $"{Character}: {VoiceName}";

        public override bool Equals(object? obj)
        {
            if (obj is not Voice that) return false;
            if (this == that) return true;
            return this.Character == that.Character;
        }
        public override int GetHashCode()
        {
            return Character.GetHashCode();
        }

        /// <summary>Default voice for the story.</summary>
        public static string Default => "default";
    }
}
