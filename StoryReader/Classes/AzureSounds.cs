using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace StoryReader.Classes
{
    public static class AzureSounds
    {
        public static string? GetFile(Part part)
        {
            var folder = Utils.GetAzureSoundsFolderName();
            CreateFolderINE(folder);
            folder = Path.Combine(folder, part.Voice.VoiceName);
            CreateFolderINE(folder);
            folder = Path.Combine(folder, VoiceHelpers.GetPitch(part.Voice.Pitch));
            CreateFolderINE(folder);
            var fileName = GetFileName(part);
            fileName = Path.Combine(folder, fileName);
            return File.Exists(fileName) ? fileName : null;
        }

        private static void CreateFolderINE(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }

        // FNV-1a hash for string. Provides a deterministic hash.
        public static int GetDeterministicHashCode(this string str)
        {
            unchecked
            {
                int hash = (int)2166136261; // FNV_offset_basis_32
                foreach (char c in str)
                {
                    hash ^= c;
                    hash *= 16777619; // FNV_prime_32
                }
                return hash;
            }
        }

        private static string GetFileName(Part part)
            => $"{part.Text.GetDeterministicHashCode()}.mp3";

        private static string GetFilePath(Part part)
        {
            var folder = Path.Combine(Utils.GetAzureSoundsFolderName()
                , part.Voice.VoiceName, VoiceHelpers.GetPitch(part.Voice.Pitch));
            return Path.Combine(folder, GetFileName(part));
        }

        /// <summary></summary>
        /// <remarks>Text to Speech: 0.5 million characters free per month</remarks>
        public async static Task<string> CreateFile(Part part)
        {
            try
            {
                var config = SpeechConfig.FromSubscription(Utils.GetAzureKey(), "westeurope");
                config.SpeechSynthesisVoiceName = part.Voice.VoiceName;
                config.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Audio16Khz32KBitRateMonoMp3);
                var fileName = GetFilePath(part);
                using var fileStream = AudioConfig.FromWavFileOutput(fileName);
                using var synt = new SpeechSynthesizer(config, fileStream);
                var tst = part.ToSSML();
                var result = await synt.SpeakSsmlAsync(part.ToSSML());
                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    return fileName;
                else
                    throw new Exception($"Error: {result.Reason}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        // https://learn.microsoft.com/en-us/azure/ai-services/speech-service/language-support?tabs=tts#multilingual-voices

        public static string[] AzureVoices { get; set; }

        public static bool IsAzureVoice(string s)
            => AzureVoices.Contains(s);

        public static bool IsAzureVoice(Part p)
            => AzureVoices.Contains(p.Voice.VoiceName);
    }
}
