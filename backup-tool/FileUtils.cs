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
        /// <summary>
        /// Returns every file within a rootfolder as well as files within subdirectories of rootfolder
        /// Ignore any folders that are hidden
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> GetFileInfoList(string path)
        {
            var options = new EnumerationOptions();
            options.IgnoreInaccessible = true;
            options.RecurseSubdirectories = true;
            var fileList = Directory.EnumerateFiles(path, "*", options)
                .Select(f => new FileInfo(f)).ToList();
            return fileList;
        }
        public static List<KeyValuePair<string, long>> ExtensionToFilesizeMapping(IEnumerable<FileInfo> files)
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
            double res = ((double) bytes / (double) (1e9));
            double rounded = Math.Round(res, 2);
            return rounded;
        }

    }
}
