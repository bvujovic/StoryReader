using System.Diagnostics;

namespace StoryReader.Classes
{
    public static class Utils
    {
        private static readonly string[] folders = [
            "c:\\Users\\bvnet\\OneDrive\\x\\AppData\\StoryReader\\",
            "c:\\Users\\sosos\\OneDrive\\x\\AppData\\StoryReader\\"
            ];

        private static int idxFolder = -1;

        public static void CalcIdxFolder()
        {
            for (int i = 0; i < folders.Length; i++)
                if (Directory.Exists(folders[i]))
                    idxFolder = i;
            if (idxFolder == -1)
                throw new Exception("StoryReader folder not found on this computer.");
        }

        public static string GetStoriesFolderName()
            => Path.Combine(folders[idxFolder], "Stories");

        public static string GetAzureSoundsFolderName()
            => Path.Combine(folders[idxFolder], "AzureSounds");

        public static string GetAzureKey()
        {
            var fileName = Path.Combine(folders[idxFolder], "AzureSounds", "azk.txt");
            return File.ReadAllText(fileName);
        }

        public static void GoToLink(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = "chrome",
                    Arguments = url,
                });
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Go to Link"); }
        }
    }
}
