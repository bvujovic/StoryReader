using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Diagnostics;

namespace StoryReader.Classes
{
    public static class AzureSounds
    {
        private const string VoicesFolderName = "AzureSounds";

        public static string? GetFile(Part part)
        {
            var folder = FrmMain.GetStoriesFolderName() ?? throw new Exception("Stories folder not found.");
            folder = Path.Combine(folder, VoicesFolderName, part.Voice.VoiceName);
            if (!Directory.Exists(folder))
                return null;
            var fileName = GetFileName(part);
            fileName = Path.Combine(folder, fileName);
            return File.Exists(fileName) ? fileName : null;
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
            => $"{VoiceHelpers.GetPitch(part.Voice.Pitch)}, {part.Text.GetDeterministicHashCode()}.mp3";

        private static string GetFilePath(Part part)
        {
            var folder = FrmMain.GetStoriesFolderName()!;
            folder = Path.Combine(folder, VoicesFolderName, part.Voice.VoiceName);
            return Path.Combine(folder, GetFileName(part));
        }

        public async static Task<string> CreateFile(Part part)
        {
            var config = SpeechConfig.FromSubscription(azKey, "westeurope");
            config.SpeechSynthesisVoiceName = part.Voice.VoiceName;
            config.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Audio16Khz32KBitRateMonoMp3);
            var fileName = GetFilePath(part);
            using var fileStream = AudioConfig.FromWavFileOutput(fileName);
            using var synt = new SpeechSynthesizer(config, fileStream);
            var result = await synt.SpeakSsmlAsync(part.ToSSML());
            if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                return fileName;
            else
                throw new Exception($"Error: {result.Reason}");
        }
     }
}
