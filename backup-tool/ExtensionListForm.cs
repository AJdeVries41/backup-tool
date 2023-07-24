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
using System.Windows.Forms;

namespace backup_tool
{
    public partial class ExtensionListForm : Form
    {
        string sourceDirName;
        string destDirName;
        int amountOfFiles;
        public ExtensionListForm(string sourceDirName, string destDirName, IEnumerable<FileInfo> fileList)
        {
            InitializeComponent();

            this.sourceDirName = sourceDirName;
            this.label1.Text = $"Select all file types within \"{this.sourceDirName}\" that are final";
            this.destDirName = destDirName;
            this.amountOfFiles = fileList.Count();

            this.ConcstuctCheckedListBox(fileList);
        }

        public void ConcstuctCheckedListBox(IEnumerable<FileInfo> fileList)
        {
            List<KeyValuePair<string, long>> sortedExtsBySize = FileUtils.ExtensionToFilesizeMapping(fileList);
            foreach (var pair in sortedExtsBySize)
            {
                string sizeString = $"\t({FileUtils.ByteToGB(pair.Value).ToString()} GB)";
                this.exts.Items.Add(pair.Key + sizeString, false);
            }
        }

        public List<string> ProcessCheckedExtensions(CheckedListBox.CheckedItemCollection checkedList)
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
            var finalFileExtensions = ProcessCheckedExtensions(this.exts.CheckedItems);
            WaitForm wf = new WaitForm(this.sourceDirName, this.destDirName, finalFileExtensions, this.amountOfFiles);

            wf.ShowDialog();
            
            return;
        }
    }
}
