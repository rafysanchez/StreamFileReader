using System.Linq;
using System.Runtime.CompilerServices;
using StreamFileReader.Domain;

[assembly: InternalsVisibleTo("StreamfileReader.Tests")]
namespace StreamFileReader.Library {
    internal static class FileProcessor {
        public static FileData GetFile(string fullFileName) {
            var lines = System.IO.File.ReadAllLines(fullFileName);

            var fileData = new FileData {
                FullName = fullFileName,
                Lines = lines
            };

            return fileData;
        }

        public static FileData[] GetFiles(string[] fileList) {
            return (from fullFileName in fileList
                    let lines = System.IO.File.ReadAllLines(fullFileName)
                    select new FileData {
                        FullName = fullFileName,
                        Lines = lines
                    }).ToArray();
        }
    }
}
