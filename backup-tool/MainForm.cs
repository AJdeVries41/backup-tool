using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace backup_tool
{
    public partial class MainForm : Form
    {
        private FolderBrowserDialog sourceFolderDialog;
        private FolderBrowserDialog targetFolderDialog;
        public MainForm()
        {
            InitializeComponent();
            AllocConsole();
            this.sourceFolderDialog = new FolderBrowserDialog();
            this.targetFolderDialog = new FolderBrowserDialog();
        }

        private void sourceFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = this.sourceFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.sourceFolderLabel.Text = this.sourceFolderDialog.SelectedPath;
            }
        }

        private void targetFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = this.targetFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.destFolderLabel.Text = this.targetFolderDialog.SelectedPath;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string sourcePath = this.sourceFolderLabel.Text;
            string destPath = this.destFolderLabel.Text;
            if (Directory.Exists(sourcePath) && Directory.Exists(destPath))
            {
                var fileList = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories);
                var fileInfoList = fileList.Select(x => new FileInfo(x)).ToList();
                var exts = FileUtils.GetExtensions(fileList);
                Console.WriteLine($"There are {exts.Count} unique file types in {sourcePath}");
                foreach ( var ext in exts )
                {
                    Console.WriteLine($"{ext}");
                }
                ExtensionListForm frm2 = new ExtensionListForm(sourcePath, destPath, fileInfoList);

                frm2.ShowDialog();

                return;

            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            this.sourceFolderLabel.Text = @"C:\Users\AJ\Documents\tudelft";
            this.destFolderLabel.Text = @"C:\Users\AJ\Documents\backups";

            runButton_Click(sender, e);
        }

        //This is to be able to use the console while running the application
        //(in order to print values to debug)
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}