using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace backup_tool
{
    internal class FileCopier
    {
        List<string> finalFileTypes;
        int totalAmountOfFiles;
        int completedPercentage;
        BackgroundWorker worker;
        public FileCopier(List<string> finalFileTypes, int totalAmountOfFiles, BackgroundWorker worker)
        {
            this.finalFileTypes = finalFileTypes;
            this.totalAmountOfFiles = totalAmountOfFiles;
            this.completedPercentage = 0;
            this.worker = worker;
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

            var fileArr = sourceDir.GetFiles();
            foreach (FileInfo file in fileArr)
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
            //Loading bar progress is updated per block of files, I could also try per file...
            int rootFileCount = fileArr.Length;
            double percentageIncrease = ((double)rootFileCount / (double)totalAmountOfFiles) * 100;
            this.completedPercentage += (int)Math.Round(percentageIncrease);

            //Report progress to worker to update load bar
            this.worker.ReportProgress(this.completedPercentage);

            DirectoryInfo[] sourceSubDirs = sourceDir.GetDirectories();
            //Recursively copy each subdirectory to the destination folder
            foreach (DirectoryInfo sourceSubDir in sourceSubDirs)
            {
                //Again, ignore any subDirs that are hidden
                if (!((sourceSubDir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                {
                    string destSubDir = Path.Combine(destination, sourceSubDir.Name);
                    this.CopyToDirectory(sourceSubDir.FullName, destSubDir);
                }
            }
        }
    }
}
