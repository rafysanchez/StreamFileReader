using StreamFileReader.Domain;

namespace StreamFileReader {

    public interface IFileReaderManager {

        FileData[] GetFiles();

        string[] GetFileList();
    }
}