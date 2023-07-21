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
                Console.WriteLine($"Destination directory {destination} does not exist, creating it...");
                Directory.CreateDirectory(destination);
            }

            var fileArr = sourceDir.GetFiles();
            foreach (FileInfo file in fileArr)
            {
                string ext = Path.GetExtension(file.Name);
                string targetFilePath = Path.Combine(destination, file.Name);
                if (finalFileTypes.Contains(ext) && !File.Exists(targetFilePath))
                {
                    Console.WriteLine($"Copying {file.Name}...");
                    file.CopyTo(targetFilePath);
                }
                else if (finalFileTypes.Contains(ext) && File.Exists(targetFilePath))
                {
                    Console.WriteLine($"Skipping {file.Name}");
                    continue;
                }
                else
                {
                    //If the file is not a final file type, we must copy it no matter what
                    Console.WriteLine($"Creating or overwriting {file.Name}...");
                    file.CopyTo(targetFilePath, true);
                }
            }
            int rootFileCount = fileArr.Length;
            double percentageIncrease = ((double)rootFileCount / (double)totalAmountOfFiles) * 100;
            //floating point errors probably
            this.completedPercentage += (int)Math.Round(percentageIncrease);

            //Report progress to worker to update load bar
            this.worker.ReportProgress(this.completedPercentage);

            DirectoryInfo[] subDirs = sourceDir.GetDirectories();
            //Recursively copy each subdirectory to the destination folder
            foreach (DirectoryInfo subDir in subDirs)
            {
                string destSubdirLoc = Path.Combine(destination, subDir.Name);
                this.CopyToDirectory(subDir.FullName, destSubdirLoc);
            }
        }
    }
}
