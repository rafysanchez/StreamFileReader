using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using StreamfileReader.Tests.Library;
using Xunit;
using System.Runtime.CompilerServices;
using StreamFileReader;
using StreamFileReader.Domain;
using StreamFileReader.Library;

namespace StreamfileReader.Tests.Processors {
    [ExcludeFromCodeCoverage]
    public class FileProcessoTests {
        
        private string InComingDirectory { get; }
        private string SearchPattern { get; }

        public FileProcessoTests() {
            SearchPattern = @"*.txt";
            InComingDirectory = @"c:\temp\data\filetests";
        }

        [Fact]
        [Order(1)]
        public void FileReadSuccess() {
            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            FileUtility.ClearDirectory(startUpSettings.InComingDirectory);
            FileUtility.CreateStubFile(startUpSettings.InComingDirectory, startUpSettings.SearchPattern, "Test");

            IFileReaderManager fileReaderManager = new FileReaderManager(startUpSettings);

            var fileList = fileReaderManager.GetFileList();

            Assert.True(fileList.Length > 0);

            foreach (var file in fileList) {
                var fileData = FileProcessor.GetFile(file);

                Assert.NotNull(fileData);
                Assert.True(!string.IsNullOrEmpty(fileData.FullName));
                Assert.Equal(file, fileData.FullName);
                Assert.NotNull(fileData.Lines);
                Assert.True(fileData.Lines.Length == 4);
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

        [Fact]
        [Order(2)]
        public void FileListReadSuccess() {
            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            FileUtility.ClearDirectory(startUpSettings.InComingDirectory);
            var file01 = FileUtility.CreateStubFile(startUpSettings.InComingDirectory, startUpSettings.SearchPattern, "01");
            var file02 = FileUtility.CreateStubFile(startUpSettings.InComingDirectory, startUpSettings.SearchPattern, "02");

            IFileReaderManager fileReaderManager = new FileReaderManager(startUpSettings);

            var fileList = fileReaderManager.GetFileList();

            Assert.True(fileList.Length == 2);

            var fileDataList = FileProcessor.GetFiles(fileList);

            TestFileData(file01, fileDataList[0]);
            TestFileData(file02, fileDataList[1]);

            void TestFileData(string fullName, FileData fileData) { 
                Assert.NotNull(fileData);
                Assert.True(!string.IsNullOrEmpty(fileData.FullName));
                Assert.Equal(fullName, fileData.FullName);
                Assert.NotNull(fileData.Lines);
                Assert.True(fileData.Lines.Length == 4);
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
