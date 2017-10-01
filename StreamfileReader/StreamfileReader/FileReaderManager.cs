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

        public void Execute() {
            //Obtem a lista de nomes arquivos do diretório
            var fileList = DirectoryProcessor.GetFilenames(StartUpSettings.InComingDirectory, StartUpSettings.SearchPattern, true);

            //Processa cada arquivo e transforma em uma lista de stream

        }

        public string[] GetFileList() {
            var fileList = DirectoryProcessor.GetFilenames(StartUpSettings.InComingDirectory, StartUpSettings.SearchPattern, true);

            return fileList;
        }
    }
}
