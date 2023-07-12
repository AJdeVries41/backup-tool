using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backup_tool
{
    internal class FileUtils
    {
        public static void CopyToDirectory(string source, string destination)
        {
            var sourceDir = new DirectoryInfo(source);
            if (!sourceDir.Exists)
            {
                throw new DirectoryNotFoundException($"{source} does not exist");
            }
            DirectoryInfo[] subDirs = sourceDir.GetDirectories();
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (FileInfo file in sourceDir.GetFiles())
            {
                Console.WriteLine(file.Name);
                string targetFilePath = Path.Combine(destination, file.Name);
                file.CopyTo(targetFilePath);
            }

            //Recursively copy each subdirectory to the destination folder

            foreach (DirectoryInfo subDir in subDirs)
            {
                string destSubdirLoc = Path.Combine(destination, subDir.Name);
                CopyToDirectory(subDir.FullName, destSubdirLoc);
            }
        }
    }
}
