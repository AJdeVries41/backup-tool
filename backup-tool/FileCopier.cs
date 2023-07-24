using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;

namespace backup_tool
{
    internal class FileCopier
    {
        List<string> finalFileTypes;
        int totalAmountOfFiles;
        double completedPercentage;
        BackgroundWorker worker;
        EnumerationOptions options;
        public FileCopier(List<string> finalFileTypes, int totalAmountOfFiles, BackgroundWorker worker)
        {
            this.finalFileTypes = finalFileTypes;
            this.totalAmountOfFiles = totalAmountOfFiles;
            this.completedPercentage = 0.0;
            this.worker = worker;
            this.options = new EnumerationOptions();
            this.options.IgnoreInaccessible = true;
            this.options.RecurseSubdirectories = false;
        }

        public void CopyToDirectory(string source, string destination)
        {
            var sourceDir = new DirectoryInfo(source);
            if (!sourceDir.Exists)
            {
                throw new DirectoryNotFoundException($"The directory {source} does not exist");
            }
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            var files = sourceDir.EnumerateFiles("*", this.options);
            foreach (FileInfo file in files)
            {
                string ext = Path.GetExtension(file.Name);
                string targetFilePath = Path.Combine(destination, file.Name);
                if (finalFileTypes.Contains(ext) && !File.Exists(targetFilePath))
                {
                    file.CopyTo(targetFilePath);
                }
                else if (finalFileTypes.Contains(ext) && File.Exists(targetFilePath))
                {
                    continue;
                }
                else
                {
                    //If the file is not a final file type, we must copy it no matter what
                    file.CopyTo(targetFilePath, true);
                }
            }

            UpdateLoadingBar(files);

            var sourceSubDirs = sourceDir.EnumerateDirectories("*", this.options);

            //Recursively copy each subdirectory to the destination folder
            foreach (DirectoryInfo sourceSubDir in sourceSubDirs)
            {
                string destSubDir = Path.Combine(destination, sourceSubDir.Name);
                this.CopyToDirectory(sourceSubDir.FullName, destSubDir);
            }
        }

        private void UpdateLoadingBar(IEnumerable<FileInfo> files)
        {
            //Loading bar progress is updated per block of files, I could also try per file...
            int rootFileCount = files.Count();
            double percentageIncrease = ((double)rootFileCount / (double)totalAmountOfFiles) * 100;
            this.completedPercentage += percentageIncrease;

            int forReporting = (int) Math.Floor(this.completedPercentage);

            //Report progress to worker to update load bar
            this.worker.ReportProgress(forReporting);
        }
    }
}
