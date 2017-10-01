using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using StreamfileReader.Domain;
using StreamfileReader.Library;

namespace StreamfileReader {
    public class FileReaderManager : IFileReaderManager {
        private StartUpSettings StartUpSettings { get; }
        public FileReaderManager(StartUpSettings startUpSettings) {
            StartUpSettings = startUpSettings;
        }

        public FileData[] Execute() {
            var fileList = DirectoryProcessor.GetFilenames(StartUpSettings.InComingDirectory, StartUpSettings.SearchPattern, true);

            var fileDataList = FileProcessor.GetFiles(fileList);

            return fileDataList;
        }

        public string[] GetFileList() {
            var fileList = DirectoryProcessor.GetFilenames(StartUpSettings.InComingDirectory, StartUpSettings.SearchPattern, true);

            return fileList;
        }
    }
}


