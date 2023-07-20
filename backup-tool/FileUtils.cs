using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backup_tool
{
    internal class FileUtils
    {
        public static void CopyToDirectory(string source, string destination, List<String> finalFileTypes, 
            int totalAmountOfFiles, int completedPercentage, BackgroundWorker worker)
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
            int fileCount = fileArr.Length;
            double percentageIncrease = ((double)fileCount / (double)totalAmountOfFiles) * 100;
            //floating point errors probably
            completedPercentage += (int) Math.Round(percentageIncrease);

            //Report progress to worker to update load bar
            worker.ReportProgress(completedPercentage);

            DirectoryInfo[] subDirs = sourceDir.GetDirectories();
            //Recursively copy each subdirectory to the destination folder
            foreach (DirectoryInfo subDir in subDirs)
            {
                string destSubdirLoc = Path.Combine(destination, subDir.Name);
                CopyToDirectory(subDir.FullName, destSubdirLoc, finalFileTypes, totalAmountOfFiles, completedPercentage, worker);
            }
        }

        public static List<KeyValuePair<string, long>> ExtensionToFilesizeMapping(List<FileInfo> files)
        {
            Dictionary<string, long> result = new Dictionary<string, long>();
            foreach (var file in files)
            {
                var ext = Path.GetExtension(file.FullName);
                if (!result.ContainsKey(ext))
                {
                    result[ext] = file.Length;
                }
                else
                {
                    result[ext] += file.Length;
                }
            }
            var resultAsList = result.OrderByDescending(x => x.Value).ToList();
            return resultAsList;
        }

        public static double ByteToGB(long bytes)
        {
            double res = (bytes / (1e9));
            double rounded = Math.Round(res, 2);
            return rounded;
        }

        public static List<string> GetExtensions(IEnumerable<string> fileList)
        {
            var result = new List<string>();
            foreach (string file in fileList)
            {
                var ext = Path.GetExtension(file);
                if (!result.Contains(ext))
                {
                    result.Add(ext);
                }
            }
            return result;
        }
    }
}
