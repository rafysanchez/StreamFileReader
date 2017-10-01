using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using StreamfileReader.Domain;
using StreamfileReader.Library;
using StreamfileReader.Tests.Library;
using Xunit;

namespace StreamfileReader.Tests.Processors {
    public class FileProcessoTests {
        [ExcludeFromCodeCoverage]
        private string InComingDirectory { get; }
        private string SearchPattern { get; }

        public FileProcessoTests() {
            SearchPattern = @"*.txt";
            InComingDirectory = @"c:\temp\data";
        }

        [Fact]
        [Order(1)]
        public void FileReadSuccess() {
            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            FileUtility.ClearDirectory(startUpSettings.InComingDirectory, startUpSettings.SearchPattern);
            FileUtility.CreateStubFile(startUpSettings.InComingDirectory, startUpSettings.SearchPattern);

            IFileReaderManager fileReaderManager = new FileReaderManager(startUpSettings);

            var fileList = fileReaderManager.GetFileList();

            Assert.True(fileList.Count > 0);

            foreach (var file in fileList) {
                var fileData = FileProcessor.GetFile(file);

                Assert.NotNull(fileData);
                Assert.True(!string.IsNullOrEmpty(fileData.FullName));
                Assert.Equal(file, fileData.FullName);
                Assert.NotNull(fileData.Lines);
                Assert.True(fileData.Lines.Count == 4);
                Assert.True(!string.IsNullOrEmpty(fileData.Lines.ToArray()[0]));
                Assert.True(!string.IsNullOrEmpty(fileData.Lines.ToArray()[1]));
                Assert.True(!string.IsNullOrEmpty(fileData.Lines.ToArray()[2]));
                Assert.True(!string.IsNullOrEmpty(fileData.Lines.ToArray()[3]));
                Assert.Equal(fileData.Lines.ToArray()[0], "Be");
                Assert.Equal(fileData.Lines.ToArray()[1], "better");
                Assert.Equal(fileData.Lines.ToArray()[2], "than");
                Assert.Equal(fileData.Lines.ToArray()[3], "yesterday");
            }
        }
    }
}
