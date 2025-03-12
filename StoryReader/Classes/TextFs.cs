using System.ComponentModel;

namespace StoryReader.Classes
{
    public static class TextFs
    {
        public static List<string> SplitSSMLs(string s)
        {
            var parts = new List<string>();
            for (var idx = 0; idx < s.Length; idx++)
            {
                var idxStart = s.IndexOf("<voice", idx);
                if (idxStart == -1)
                {
                    AddPart(parts, s[idx..]);
                    break;
                }
                else
                {
                    AddPart(parts, s[idx..idxStart]); // dodavanje texta pre <voice> taga
                    var idxEnd = s.IndexOf("</voice>", idxStart);
                    if (idxEnd != -1)
                        AddPart(parts, s[idxStart..(idxEnd += "</voice>".Length)]); // text izmedju <voice> i </voice>
                    //if (idxEnd != -1)
                    //{
                    //    idxEnd += "</voice>".Length;
                    //    AddPart(parts, s[idxStart..idxEnd]); // text izmedju <voice> i </voice>
                    //}
                    //if (idxEnd == -1)
                    else
                    {
                        AddPart(parts, s[idxStart..] + "</voice>");
                        break;
                    }
                    idx = idxEnd;
                }
            }
            return parts;
        }

        private static void AddPart(List<string> parts, string str)
        {
            str = str.Trim();
            if (str != "")
            {
                if (!str.Contains("<voice"))
                    str = $"<voice name=\"default\">{str}</voice>";
                parts.Add(str);
            }
        }

        public static void VoicesForCharacters(List<string> parts, IEnumerable<Voice> voices)
        {
            for (int i = 0; i < parts.Count; i++)
                foreach (var v in voices)
                    parts[i] = parts[i].Replace($"<voice name=\"{v.Character}\">", $"\r\n<voice name=\"{v.VoiceName}\">");
        }

        public static void AddSSMLroot(List<string> parts)
        {
            for (int i = 0; i < parts.Count; i++)
                parts[i] = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\">\r\n"
                    + parts[i] + "\r\n</speak>";
        }
    }
}
