
namespace StoryReader.Classes
{
    public class Part
    {
        public required string Text { get; set; }

        public required Voice Voice { get; set; }

        public override string ToString()
            //=> $"{Voice.Character}: {Text[..30]}{(Text.Length > 30 ? "..." : "")}";
            => $"{Voice.Character}: " + (Text.Length > 30 ? $"{Text[..30]}..." : Text);

        public string ToSSML()
        {
            var s = TextFs.VoiceForCharacter(Text, Voice);
            return TextFs.AddSSMLroot(s);
        }
    }
}
