
using System;
using System.IO;
using StreamfileReader;
using StreamfileReader.Domain;
using StreamfileReader.Tests.Library;
using Xunit;

namespace StreamfileReader.Tests.DirectoryProcess {
    [TestCaseOrderer("FullNameOfOrderStrategyHere", "OrderStrategyAssemblyName")]
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
            ClearDirectory();
            CreateStubFile();

            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            IFileReaderManager fileReaderManager = new FileReaderManager(startUpSettings);

            var fileList = fileReaderManager.GetFileList();

            Assert.True(fileList.Count > 0);
        }

        [Fact]
        [Order(2)]
        public void FileListNotFound() {
            ClearDirectory();

            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            IFileReaderManager fileReaderManager = new FileReaderManager(startUpSettings);

            var fileList = fileReaderManager.GetFileList();

            Assert.True(fileList.Count == 0);
        }

        private void ClearDirectory() {
            if (Directory.Exists(InComingDirectory)) {
                Directory.Delete(InComingDirectory, true);
            }
        }

        private void CreateDirectory() {
            if (!Directory.Exists(InComingDirectory)) {
                Directory.CreateDirectory(InComingDirectory);
            }
        }

        private void CreateStubFile() {
            var path =
                $@"{InComingDirectory}\{new Random(DateTime.UtcNow.Millisecond).Next(100000, 9999999)}{
                        SearchPattern.Replace('*', '_')
                    }";

            CreateDirectory();

            using (var sw = File.CreateText(path)) {
                sw.WriteLine("Be");
                sw.WriteLine("better");
                sw.WriteLine("than");
                sw.WriteLine("yesterday");
            }
        }
    }
}