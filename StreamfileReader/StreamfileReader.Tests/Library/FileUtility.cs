using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace StreamfileReader.Tests.Library {
    [ExcludeFromCodeCoverage]
    public static class FileUtility {
        public static void ClearDirectory(string inComingDirectory, string searchPattern) {
            if (Directory.Exists(inComingDirectory)) {
                Directory.Delete(inComingDirectory, true);
            }
        }

        public static void CreateDirectory(string inComingDirectory, string searchPattern) {
            if (!Directory.Exists(inComingDirectory)) {
                Directory.CreateDirectory(inComingDirectory);
            }
        }

        public static void CreateStubFile(string inComingDirectory, string searchPattern) {
            var path =
                $@"{inComingDirectory}\{new Random(DateTime.UtcNow.Millisecond).Next(100000, 9999999)}{
                        searchPattern.Replace('*', '_')
                    }";

            CreateDirectory(inComingDirectory, searchPattern);

            using (var sw = File.CreateText(path)) {
                sw.WriteLine("Be");
                sw.WriteLine("better");
                sw.WriteLine("than");
                sw.WriteLine("yesterday");
            }
        }
    }
}
