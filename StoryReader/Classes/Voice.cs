namespace StoryReader.Classes
{
    public class Voice
    {
        /// <summary>Name of the character for a story: default, husband, friend, John...</summary>
        public required string Character { get; set; }
        /// <summary>Name of the installed voice that will be used for the character in a story: Microsoft David Desktop, Microsoft Heera</summary>
        public required string VoiceName { get; set; }

        public required string Volume { get; set; } = "default";
        // silent, x-low, low, medium, loud, x-loud, default

        public required string Pitch { get; set; } = "default";
        // x-low, low, medium, high, x-high, default.

        public required string Rate { get; set; } = "default";
        // x-slow, slow, medium, fast, x-fast, or default

        public override string ToString()
            => $"{Character}: {VoiceName}";

        /// <summary>Default voice for the story.</summary>
        public static string Default => "default";
    }
}
