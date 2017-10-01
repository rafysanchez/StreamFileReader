
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using StreamfileReader;
using StreamfileReader.Domain;
using StreamfileReader.Tests.Library;
using Xunit;

namespace StreamfileReader.Tests.DirectoryProcess {
    [ExcludeFromCodeCoverage]
    public class DirectoryProcessTests {
        private string InComingDirectory { get; }
        private string SearchPattern { get; }

        public DirectoryProcessTests() {
            SearchPattern = @"*.txt";
            InComingDirectory = @"c:\temp\data";
        }

        [Fact]
        [Order(1)]
        public void FileListSuccess() {
            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            FileUtility.ClearDirectory(startUpSettings.InComingDirectory, startUpSettings.SearchPattern);
            FileUtility.CreateStubFile(startUpSettings.InComingDirectory, startUpSettings.SearchPattern, "Test");

            IFileReaderManager fileReaderManager = new FileReaderManager(startUpSettings);

            var fileList = fileReaderManager.GetFileList();

            Assert.True(fileList.Count > 0);
        }

        [Fact]
        [Order(2)]
        public void FileListNotFound() {
            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            FileUtility.ClearDirectory(startUpSettings.InComingDirectory, startUpSettings.SearchPattern);

            IFileReaderManager fileReaderManager = new FileReaderManager(startUpSettings);

            var fileList = fileReaderManager.GetFileList();

            Assert.True(fileList.Count == 0);
        }
    }
}