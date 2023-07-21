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
            double res = ((double) bytes / (double) (1e9));
            double rounded = Math.Round(res, 2);
            return rounded;
        }

    }
}
