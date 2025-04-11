using System.Text.RegularExpressions;

namespace StoryReader.Classes
{
    internal static class VoiceHelpers
    {
        public static string[] RateConstants = ["x-slow", "slow", "medium", "fast", "x-fast"];
        public static string[] PitchConstants = ["x-low", "low", "medium", "high", "x-high"];
        public static string[] VolumeConstants = ["silent", "x-low", "low", "medium", "loud", "x-loud"];

        public static string[] Constants(string property)
        {
            return property switch
            {
                nameof(Voice.Volume) => VolumeConstants,
                nameof(Voice.Pitch) => PitchConstants,
                nameof(Voice.Rate) => RateConstants,
                _ => [],
            };
        }

        public static bool IsStringValid(string? s, string property)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            if (Constants(property).Contains(s))
                return true;
            if (property != nameof(Voice.Pitch))
                return Regex.IsMatch(s, "^\\d+%$");
            else
                return false; // only constants work for the Pitch
        }
    }
}