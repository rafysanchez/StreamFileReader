using StreamfileReader.Tests.Library;
using StreamFileReader.Domain;
using StreamFileReader.Library;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace StreamfileReader.Tests.Processors {

    [ExcludeFromCodeCoverage]
    public class DirectoryProcessTests {
        private string InComingDirectory { get; }
        private string SearchPattern { get; }

        public DirectoryProcessTests() {
            SearchPattern = @"*.txt";
            InComingDirectory = @"c:\temp\data\dirtests";
        }

        [Fact]
        [Order(1)]
        public void GetFileNamesSuccess() {
            var startUpSettings = new StartUpSettings {
                InComingDirectory = InComingDirectory,
                SearchPattern = SearchPattern
            };

            FileUtility.ClearDirectory(startUpSettings.InComingDirectory);
            var file01 =
                FileUtility.CreateStubFile(startUpSettings.InComingDirectory, startUpSettings.SearchPattern, "01");
            var file02 =
                FileUtility.CreateStubFile(startUpSettings.InComingDirectory, startUpSettings.SearchPattern, "02");

            var fileNames = DirectoryProcessor.GetFileNames(startUpSettings.InComingDirectory);

            Assert.NotNull(fileNames);
            Assert.True(fileNames.Length == 2);
            Assert.True(!string.IsNullOrEmpty(fileNames[0]));
            Assert.True(!string.IsNullOrEmpty(fileNames[1]));
            Assert.Equal(fileNames[0], file01);
            Assert.Equal(fileNames[1], file02);
        }

        [Fact]
        [Order(2)]
        public void CreateDirectoryIfNotExistsSuccess() {
            var fileNames = DirectoryProcessor.GetFileNames($@"{InComingDirectory}\{DateTime.UtcNow.Ticks}", createDirectoryIfNotExists: false);
            Assert.Null(fileNames);
        }
    }
}