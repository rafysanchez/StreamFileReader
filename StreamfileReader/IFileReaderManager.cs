using StreamFileReader.Domain;

namespace StreamFileReader {

    public interface IFileReaderManager {

        FileData[] GetFiles();

        FileData GetFile(string fullfileName);

        string[] GetFileList();
    }
}