
namespace StoryReader.Classes
{
    public class Part
    {
        public required string Text { get; set; }

        public required Voice Voice { get; set; }

        public override string ToString()
            => $"{Voice.Character}: {Text[..30]}";

        public string ToSSML()
        {
            throw new NotImplementedException();
            //TODO use functions from TextFs class
        }
    }
}
