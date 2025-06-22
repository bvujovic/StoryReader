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
                    str = $"<voice name=\"{Voice.Default}\">{str}</voice>";
                parts.Add(str);
            }
        }

        private const string VoiceTagStart = "<voice name=\"";
        private const string VoiceTagEnd = "</voice>";

        public static Part CreatePart(string str, System.ComponentModel.BindingList<Voice> voices)
        {
            // e.g. <voice name="cousin">"Looks like it's your turn to do it"</voice>
            str = str.Trim();
            if (!str.Contains(VoiceTagStart))
                str = $"{VoiceTagStart}{Voice.Default}\">{str}{VoiceTagEnd}";
            if (!str.StartsWith(VoiceTagStart))
                throw new Exception("String part must start with definition of its character (voice) - voice tag.");
            var voiceTagLen = VoiceTagStart.Length;
            var idx = str.IndexOf('\"', voiceTagLen);
            if (idx == -1)
                throw new Exception("Name property of the voice tag is not properly closed.");
            var character = str[voiceTagLen..idx];
            var v = voices.FirstOrDefault(it => it.Character == character)
                ?? throw new Exception($"'{character}' is not found in the Voices table.");
            idx += 2; // 1 for '\"' and 1 for '>' (characters at the end of the starting voice tag)
            str = str.Substring(idx, str.Length - idx - VoiceTagEnd.Length); // extract text without voice tags
            //? remove quotation marks from the start and the end
            return new Part { Text = str, Voice = v };
        }

        public static string VoiceForCharacter(string part, Voice v)
        {
            var vol = string.IsNullOrEmpty(v.Volume) ? "medium" : v.Volume;
            var rate = string.IsNullOrEmpty(v.Rate) ? "medium" : v.Rate;
            //var pitch = string.IsNullOrEmpty(v.Pitch) ? VoiceHelpers.DefaultPitch : v.Pitch;
            var pitch = VoiceHelpers.GetPitch(v.Pitch);
            var prosody = $"<prosody volume='{vol}' rate='{rate}' pitch='{pitch}'>";
            return $"<voice name=\"{v.VoiceName}\">{prosody}{part}</prosody></voice>";
        }

        public static IEnumerable<string> SplitSentences(string s)
        {
            //var sentenceSeparators = new char[] { '.', '?', '!' };
            //var ss = new List<string>();
            //foreach (var sentence in s.Split(sentenceSeparators))
            //    ss.Add(sentence.Trim());
            //return ss;

            //var sentenceSeparators = new string[] { ".", "?", "!", Environment.NewLine };
            var sentenceSeparators = new char[] { '.', '?', '!', '\r', '\n' };
            var sents = new List<string>();
            var sent = string.Empty;
            var atTheEnd = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (sentenceSeparators.Contains(s[i]))
                    atTheEnd = true;
                else if (atTheEnd)
                {
                    sents.Add(sent);
                    atTheEnd = false;
                    sent = string.Empty;
                }
                sent += s[i];
            }
            sent = sent.Trim();
            if (sent.Length > 0)
                sents.Add(sent);
            return sents;
        }

        //public static void VoicesForCharacters(List<string> parts, IEnumerable<Voice> voices)
        //{
        //    for (int i = 0; i < parts.Count; i++)
        //    {
        //        foreach (var v in voices)
        //        {
        //            var vol = string.IsNullOrEmpty(v.Volume) ? "medium" : v.Volume;
        //            var rate = string.IsNullOrEmpty(v.Rate) ? "medium" : v.Rate;
        //            var pitch = string.IsNullOrEmpty(v.Pitch) ? "medium" : v.Pitch;
        //            var prosody = $"<prosody volume='{vol}' rate='{rate}' pitch='{pitch}'>";
        //            parts[i] = parts[i].Replace($"<voice name=\"{v.Character}\">"
        //                , $"<voice name=\"{v.VoiceName}\">{prosody}" +
        //                $"");
        //        }
        //        if (parts[i].Contains("<prosody"))
        //            parts[i] = parts[i].Replace("</voice>", "</prosody></voice>");
        //    }
        //}

        //public static void AddSSMLroot(List<string> parts)
        //{
        //    for (int i = 0; i < parts.Count; i++)
        //        parts[i] = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\">\r\n"
        //            + parts[i] + "\r\n</speak>\r\n";
        //}

        public static string AddSSMLroot(string part)
        {
            return "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\">\r\n"
                + part + "\r\n</speak>\r\n";
        }
    }
}
