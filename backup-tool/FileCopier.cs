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

            this.options.AttributesToSkip = FileAttributes.System;
            this.options.IgnoreInaccessible = true;
            this.options.RecurseSubdirectories = false;
        }

        /*public void CopyToDirectory(string source, string destination)
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
        }*/

        /// <summary>
        /// Copy all files and directories from source to destination
        /// Requirement: source and destination both exist. Else, the method fails
        /// </summary>
        /// <param name="source">Source directory info</param>
        /// <param name="destination">Destination directory info</param>
        /// <exception cref="DirectoryNotFoundException">If source or destination does not exist</exception>
        public void CopyToDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!source.Exists)
            {
                throw new DirectoryNotFoundException($"The directory {source.FullName} does not exist");
            }
            if (!destination.Exists)
            {
                throw new DirectoryNotFoundException($"The directory {destination.FullName} does not exist");
            }
            var files = source.EnumerateFiles("*", this.options);
            foreach (FileInfo file in files)
            {
                string ext = Path.GetExtension(file.Name);
                string targetFilePath = Path.Combine(destination.FullName, file.Name);
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

            var sourceSubDirs = source.EnumerateDirectories("*", this.options);

            //Recursively copy each subdirectory to the destination folder
            foreach (DirectoryInfo sourceSubDir in sourceSubDirs)
            {
                string destSubDirName = Path.Combine(destination.FullName, sourceSubDir.Name);
                var destSubDir = new DirectoryInfo(destSubDirName);
                if (!destSubDir.Exists)
                {
                    destSubDir.Create();
                    //If the source subdir had any special attributes (such as being hidden)
                    //the destination subdir should have those as well
                    destSubDir.Attributes = sourceSubDir.Attributes;
                }
                this.CopyToDirectory(sourceSubDir, destSubDir);
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
