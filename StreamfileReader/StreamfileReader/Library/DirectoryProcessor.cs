using System;
using System.IO;
using System.Collections.Generic;

namespace StreamfileReader.Library {
    internal static class DirectoryProcessor {

        public static HashSet<string> GetFilenames(string path, string searchPattern = "*.*", bool createDirectoryIfNotExists = true) {
            return !CreateDirectoryIfNotExists(path, createDirectoryIfNotExists) ? null : GetListOfFiles(path, searchPattern);
        }
        
        private static bool CreateDirectoryIfNotExists(string path, bool createDirectoryIfNotExists = true) {
            if (Directory.Exists(path)) return true;

            if (!createDirectoryIfNotExists) return false;

            Directory.CreateDirectory(path);

            return true;
        }

        private static HashSet<string> GetListOfFiles(string path, string searchPattern) {
            var fileEntries = Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);

            return new HashSet<string>(fileEntries);
        }
    }
}
