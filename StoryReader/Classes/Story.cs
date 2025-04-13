namespace StoryReader.Classes
{
    public class Story
    {
        // class Story: parts, [separators: space, newParagraph], [current]textReading
        // reakcija na dogadjaj kada je part procitan kako bi se znalo kada da se pokrene citanje novog part-a
        // metode: string ToRtf(), Read(idxChar/idxPart)

        private readonly List<Part> parts = [];

        private int idxCurrentPart = -1;

        public Part? CurrentPart
        {
            get
            {
                if (parts.Count == 0)
                    return null;
                return idxCurrentPart == -1 ? null : parts[idxCurrentPart];
            }
        }

        public void AddPart(Part part)
        {
            parts.Add(part);
        }

        public void Clear()
        {
            idxCurrentPart = -1;
            parts.Clear();
        }

        public Part? GetNextPart()
        {
            if (parts.Count == 0)
                return null;
            if (idxCurrentPart == parts.Count - 1)
            {
                idxCurrentPart = -1;
                return null;
            }
            idxCurrentPart++;
            return CurrentPart;
        }

        // public void ReadPrevPart()

        public override string ToString()
        {
            return string.Join(Environment.NewLine, parts);
        }

        public string ToRtf()
        {
            return ToString();
        }
    }
}
