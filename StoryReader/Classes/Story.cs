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

        public bool IsCurrentPartFirst
            => idxCurrentPart == 0;

        public void SetCurrentPartNull()
            => idxCurrentPart = -1;

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

        public Part? GetPrevPart()
        {
            //if (parts.Count == 0)
            //    return null;
            if (parts.Count == 0 || idxCurrentPart == 0)
            {
                idxCurrentPart = -1;
                return null;
            }
            idxCurrentPart--;
            return CurrentPart;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, parts);
        }

        // display story in RTB - parts in colors
        public string ToRtf()
        {
            var voices = parts.Select(it => it.Voice).Distinct().ToList();
            var colors = voices.Select(it => VoiceColorHelpers.AllColors.First(c => c.Name == it.Color).RTF).ToList();
            var colorTable = $"{{\\colortbl; {string.Join(" ", colors)}}}";
            if (voices.Count == 0)
                return string.Empty;
            var s = parts.First().ToRtf(voices, CurrentPart);
            for (var i = 1; i < parts.Count; i++)
                s += (Equals(parts[i - 1].Voice, parts[i].Voice) ? " " : Environment.NewLine) + parts[i].ToRtf(voices, CurrentPart);
            s = $"{{\\rtf1\\ansi {colorTable}{s.Replace(Environment.NewLine, "\\par ")}}}";
            return s.Replace("č", "\\u269x").Replace("ć", "\\u263x").Replace("đ", "\\u273x");
        }
    }
}
