using System;
using System.Collections.Generic;
using System.Linq;
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

        public static IList<FileData> GetFiles(HashSet<string> fileList) {
            return (from fullFileName in fileList
                    let lines = System.IO.File.ReadAllLines(fullFileName)
                    select new FileData {
                        FullName = fullFileName,
                        Lines = new HashSet<string>(lines)
                    }).ToList();
        }
    }
}
