using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace backup_tool
{
    public partial class ExtensionListForm : Form
    {
        string sourceDir;
        string destDir;
        List<FileInfo> fileList;
        public ExtensionListForm(string sourceDir, string destDir, List<FileInfo> fileList)
        {
            this.sourceDir = sourceDir;
            this.destDir = destDir;
            this.fileList = fileList;
            InitializeComponent();

            List<KeyValuePair<string, long>> sortedExtsBySize = FileUtils.ExtensionToFilesizeMapping(fileList);
            foreach (var pair in sortedExtsBySize)
            {
                string sizeString = $"\t({FileUtils.ByteToGB(pair.Value).ToString()} GB)";
                this.exts.Items.Add(pair.Key+sizeString, false);
            }
            this.Controls.Add(exts);
        }

        public List<string> processCheckedExtensions(CheckedListBox.CheckedItemCollection checkedList)
        {
            var toList = checkedList.Cast<string>().ToList();
            var result = new List<string>();

            var pattern = @"[^\t]*";
            Regex r = new Regex(pattern);
            foreach (var item in toList)
            {
                var extensionPart = r.Match(item).Value;
                result.Add(extensionPart);
            }
            return result;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //Copy all the files from the source folder to the dest folder
            var finalFileExtensions = processCheckedExtensions(this.exts.CheckedItems);
            
            var timer = Stopwatch.StartNew();

            WaitForm wf = new WaitForm();
            wf.ShowDialog();
            FileUtils.CopyToDirectory(this.sourceDir, destDir, finalFileExtensions);
            wf.Close();

            timer.Stop();
            Console.WriteLine($"Execution time to copy all the files: {timer.ElapsedMilliseconds} ms");
            
            return;
        }
    }
}
