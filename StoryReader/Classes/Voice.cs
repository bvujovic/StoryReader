﻿namespace StoryReader.Classes
{
    public class Voice
    {
        /// <summary>Name of the character for a story: default, husband, friend, John...</summary>
        public required string Character { get; set; }
        /// <summary>Name of the installed voice that will be used for the character in a story: Microsoft David Desktop, Microsoft Heera</summary>
        public required string VoiceName { get; set; }

        public override string ToString()
            => $"{Character}: {VoiceName}";

        /// <summary>Default voice for the story.</summary>
        public static string Default => "default";
    }
}
