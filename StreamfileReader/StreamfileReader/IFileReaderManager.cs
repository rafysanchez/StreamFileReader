using StreamFileReader.Domain;

namespace StreamFileReader {
    public interface IFileReaderManager {
        FileData[] Execute();

        string[] GetFileList();
    }
}
