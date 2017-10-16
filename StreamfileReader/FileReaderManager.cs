using StreamFileReader.Domain;
using StreamFileReader.Library;

namespace StreamFileReader {

    public class FileReaderManager : IFileReaderManager {
        private StartUpSettings StartUpSettings { get; }

        public FileReaderManager(StartUpSettings startUpSettings) {
            StartUpSettings = startUpSettings;
        }

        public FileData[] GetFiles() {
            var fileList = DirectoryProcessor.GetFileNames(StartUpSettings.InComingDirectory, StartUpSettings.SearchPattern, true);

            var fileDataList = FileProcessor.GetFiles(fileList);

            return fileDataList;
        }

        public FileData GetFile(string fullfileName) {
            var fileDataList = FileProcessor.GetFile(fullfileName);

            return fileDataList;
        }

        public string[] GetFileList() {
            var fileList = DirectoryProcessor.GetFileNames(StartUpSettings.InComingDirectory, StartUpSettings.SearchPattern, true);

            return fileList;
        }
    }
}