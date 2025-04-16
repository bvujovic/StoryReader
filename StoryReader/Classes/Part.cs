
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

        public string ToRtf(List<Voice> voices, Part? current)
        {
            // green \ul background\ulnone  text
            var isCurrent = this != null && this == current;
            return "\\highlight" + (voices.IndexOf(Voice) + 1) 
                + (isCurrent ? "{\\ul " : "") + Text + (isCurrent ? "\\ulnone}" : "");
        }
    }
}
