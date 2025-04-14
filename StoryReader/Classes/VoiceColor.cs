namespace StoryReader.Classes
{
    public class VoiceColor(string name, Color color)
    {
        public string Name { get; set; } = name;

        public Color Color { get; set; } = color;

        public string RTF
        {
            get => $"\\red{Color.R}\\green{Color.G}\\blue{Color.B};";
        }

        public override string ToString()
            => Name;

        public override bool Equals(object? obj)
        {
            if (obj is not VoiceColor that) return false;
            if (this == that) return true;
            return this.Name == that.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static IEnumerable<VoiceColor> AllColors =
        [
            new VoiceColor("orange", Color.FromArgb(240, 155, 90)),
            new VoiceColor("pink", Color.FromArgb(185, 105, 145)),
            new VoiceColor("red", Color.FromArgb(128, 0, 0)),
            new VoiceColor("green", Color.FromArgb(0, 128, 64)),
            new VoiceColor("blue", Color.FromArgb(0, 64, 128)),
            new VoiceColor("brown", Color.FromArgb(90, 64, 64)),
            new VoiceColor("grey", Color.FromArgb(155, 155, 155)),
        ];
    }
}
