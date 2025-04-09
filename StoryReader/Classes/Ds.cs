using System.Data;

namespace StoryReader.Classes
{
    public partial class Ds
    {
        public partial class SettingsRow
        {
            public override string ToString()
                => $"{Name} => {Value}";
        }

        public partial class SettingsDataTable
        {
            public void SaveSetting(string name, string value)
            {
                var s = FindByName(name);
                if (s == null)
                {
                    s = NewSettingsRow();
                    s.Name = name;
                }
                s.Value = value;
                if (s.RowState == DataRowState.Detached)
                    AddSettingsRow(s);
            }

            public int ReadInt(string name, int defValue, Func<int, bool>? checkMethod = null)
            {
                var s = FindByName(name);
                if (s != null)
                {
                    var val = int.Parse(s.Value);
                    if (checkMethod == null)
                        return val;
                    else
                        return checkMethod(val) ? val : defValue;
                }
                return defValue;
            }

            public bool ReadBool(string name, bool defValue)
            {
                var s = FindByName(name);
                if (s != null)
                    return bool.Parse(s.Value);
                return defValue;
            }

            public string ReadString(string name, string defValue)
            {
                var s = FindByName(name);
                if (s != null)
                    return s.Value;
                return defValue;
            }

            //public static DateTime ReadDateTimeSetting(string name, DateTime defValue)
            //{
            //    var s = Ds.Settings.FindByName(name);
            //    if (s != null)
            //        return DateTime.Parse(s.Value);
            //    return defValue;
            //}
        }
    }
}
