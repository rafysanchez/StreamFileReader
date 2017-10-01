using System;
using System.Collections.Generic;
using System.Text;

namespace StreamfileReader {
    public interface IFileReaderManager {
        void Execute();

        string[] GetFileList();
    }
}
