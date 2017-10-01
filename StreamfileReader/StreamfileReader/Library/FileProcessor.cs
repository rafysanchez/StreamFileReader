using System;
using System.Collections.Generic;
using System.Text;
using StreamfileReader.Domain;

namespace StreamfileReader.Library {
    public static class FileProcessor {
        public static FileData GetFile(string fullFileName) {
            var lines = System.IO.File.ReadAllLines(fullFileName);

            var fileData = new FileData {
                FullName = fullFileName,
                Lines = new HashSet<string>(lines)
            };

            return fileData;
        }
    }
}
