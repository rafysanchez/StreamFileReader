using StreamfileReader.Tests.Library;
using StreamFileReader;
using StreamFileReader.Domain;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace StreamfileReader.Tests.Manager {

    [ExcludeFromCodeCoverage]
    public class FileReaderManagerTests {
        private string InComingDirectory { get; }
        private string SearchPattern { get; }

        public FileReaderManagerTests() {
            SearchPattern = @"*.txt";
            InComingDirectory = @"c:\temp\data\filemanagerests";
        }

        [Fact]
        [Order(1)]
        public void FileListSuccess() {
            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            FileUtility.ClearDirectory(startUpSettings.InComingDirectory);
            var file01 =
                FileUtility.CreateStubFile(startUpSettings.InComingDirectory, startUpSettings.SearchPattern, "01");
            var file02 =
                FileUtility.CreateStubFile(startUpSettings.InComingDirectory, startUpSettings.SearchPattern, "02");

            IFileReaderManager fileReaderManager = new FileReaderManager(startUpSettings);

            var fileList = fileReaderManager.GetFileList();

            Assert.True(fileList.Length > 0);

            var fileDataList = fileReaderManager.GetFiles();

            Assert.NotNull(fileDataList);
            Assert.True(fileDataList.Length == 2);

            TestFileDataList(fileDataList[0], file01);
            TestFileDataList(fileDataList[1], file02);

            void TestFileDataList(FileData fileData, string fullName) {
                Assert.Equal(fileData.FullName, fullName);
            }
        }

        [Fact]
        [Order(2)]
        public void FileListNotFound() {
            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            FileUtility.ClearDirectory(startUpSettings.InComingDirectory);

            IFileReaderManager fileReaderManager = new FileReaderManager(startUpSettings);

            var fileList = fileReaderManager.GetFileList();

            Assert.True(fileList.Length == 0);
        }
    }
}