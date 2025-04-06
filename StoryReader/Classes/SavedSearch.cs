using System.ComponentModel;

namespace StoryReader.Classes
{
    public class SavedSearch
    {
        public required string Find { get; set; }
        public string? Replace { get; set; }

        public override string ToString()
            => (Replace == null) ? $"F: {Find}" : $"F: {Find}, R: {Replace}";

        /// <summary>Saving searches enabled.</summary>
        public static bool Enabled { get; set; } = false;

        public static BindingList<SavedSearch> Searches { get; set; } = [];

        private const int maxSearches = 12;

        public static void Add(string find, string? replace)
        {
            if (!Enabled)
                return;
            if (replace == string.Empty)
                replace = null;
            var s = Searches.FirstOrDefault(it => it.Find == find);
            if (s == null)
                Searches.Insert(0, new SavedSearch { Find = find, Replace = replace });
            else
            {
                if (replace != null)
                    s.Replace = replace;
                // place newest search at the top of the list
                if (Searches.IndexOf(s) != 0)
                {
                    Searches.Remove(s);
                    Searches.Insert(0, s);
                }
            }
            while (Searches.Count > maxSearches)
                Searches.RemoveAt(maxSearches);
        }
    }
}
