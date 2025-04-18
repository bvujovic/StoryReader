namespace StoryReader.Classes
{
    internal static class VoiceColorHelpers
    {
        public static IEnumerable<VoiceColor> AllColors =
        [
            new VoiceColor("orange", Color.FromArgb(240, 155, 90)),
            new VoiceColor("pink", Color.FromArgb(185, 105, 145)),
            new VoiceColor("red", Color.FromArgb(128, 0, 0)),
            new VoiceColor("green", Color.FromArgb(0, 128, 64)),
            new VoiceColor("blue", Color.FromArgb(0, 64, 128)),
            new VoiceColor("brown", Color.FromArgb(90, 64, 64)),
            new VoiceColor("grey", Color.FromArgb(155, 155, 155)),
            new VoiceColor(defaultColorName, Color.FromArgb(30, 30, 30)),
        ];

        private const string defaultColorName = "dark";

        public static VoiceColor Default = AllColors.FirstOrDefault(it => it.Name == defaultColorName)!;
    }
}