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
                string targetFilePath = Path.Combine(destination, file.Name);
                //Default option is to allow overwriting with the new version
                file.CopyTo(targetFilePath, true);
            }

            //Recursively copy each subdirectory to the destination folder

            foreach (DirectoryInfo subDir in subDirs)
            {
                string destSubdirLoc = Path.Combine(destination, subDir.Name);
                CopyToDirectory(subDir.FullName, destSubdirLoc);
            }
        }

        public static List<KeyValuePair<string, long>> ExtensionToFilesize(List<FileInfo> files)
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
            var resultAsList = result.OrderBy(x => x.Value).ToList();
            return resultAsList;
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
