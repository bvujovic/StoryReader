namespace StoryReader.Classes
{
    public class VoiceColor(string name, Color color)
    {
        public string Name { get; set; } = name;

        public Color Color { get; set; } = color;

        public string RTF => $"\\red{Color.R}\\green{Color.G}\\blue{Color.B};";

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
    }
}
