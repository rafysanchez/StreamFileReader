using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StreamfileReader.Tests")]
namespace StreamFileReader.Library {
    internal static class DirectoryProcessor {

        public static string[] GetFilenames(string path, string searchPattern = "*.*", bool createDirectoryIfNotExists = true) {
            return !CreateDirectoryIfNotExists(path, createDirectoryIfNotExists) ? null : GetListOfFiles(path, searchPattern);
        }
        
        private static bool CreateDirectoryIfNotExists(string path, bool createDirectoryIfNotExists = true) {
            if (Directory.Exists(path)) return true;

            if (!createDirectoryIfNotExists) return false;

            Directory.CreateDirectory(path);

            return true;
        }

        private static string[] GetListOfFiles(string path, string searchPattern) {
            var fileEntries = Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);

            return fileEntries;
        }
    }
}
