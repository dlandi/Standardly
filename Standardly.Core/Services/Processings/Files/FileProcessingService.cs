﻿// ---------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Standardly.Core.Brokers.Loggings;
using Standardly.Core.Services.Processings.Files;

namespace Standardly.Core.Services.Foundations.FileServices
{
    public partial class FileProcessingService : IFileProcessingService
    {
        private readonly IFileService fileService;
        private readonly ILoggingBroker loggingBroker;

        public FileProcessingService(IFileService fileService, ILoggingBroker loggingBroker)
        {
            this.fileService = fileService;
            this.loggingBroker = loggingBroker;
        }
        public bool CheckIfFileExists(string path) =>
            TryCatch(() =>
            {
                ValidateCheckIfFileExists(path);

                return this.fileService.CheckIfFileExists(path);
            });

        public void WriteToFile(string path, string content) =>
            throw new System.NotImplementedException();

        public string ReadFromFile(string path) =>
            throw new System.NotImplementedException();

        public void DeleteFile(string path) =>
            throw new System.NotImplementedException();

        public string[] RetrieveListOfFiles(string path, string searchPattern = "*") =>
            throw new System.NotImplementedException();

        public bool CheckIfDirectoryExists(string path) =>
            throw new System.NotImplementedException();

        public void CreateDirectory(string path) =>
            throw new System.NotImplementedException();

        public void DeleteDirectory(string path, bool recursive = false) =>
            throw new System.NotImplementedException();
    }
}
