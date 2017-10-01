using System;
using System.Collections.Generic;
using System.Text;
using StreamfileReader.Domain;

namespace StreamfileReader {
    public interface IFileReaderManager {
        FileData[] Execute();

        string[] GetFileList();
    }
}
