﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace backup_tool
{
    public partial class MainForm : Form
    {

        private FolderPicker sourceFolderDialog;
        private FolderPicker destFolderDialog;

       
        public MainForm()
        {
            InitializeComponent();
            //AllocConsole();

            this.sourceFolderDialog = new FolderPicker();
            this.sourceFolderDialog.Multiselect = false;
            this.destFolderDialog = new FolderPicker();
            this.destFolderDialog.Multiselect = false;
        }

        private void sourceFolderButton_Click(object sender, EventArgs e)
        {
            this.sourceFolderDialog.ResetResults();
            sourceFolderDialog.InputPath = @"C:\Users";
            if (sourceFolderDialog.ShowDialog(IntPtr.Zero) == true)
            {
                this.sourceFolderLabel.Text = sourceFolderDialog.ResultPath;
            }
        }

        private void targetFolderButton_Click(object sender, EventArgs e)
        {
            this.destFolderDialog.ResetResults();
            destFolderDialog.InputPath = @"C:\Users";
            if (destFolderDialog.ShowDialog(IntPtr.Zero) == true)
            {
                this.destFolderLabel.Text = destFolderDialog.ResultPath;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string sourcePath = this.sourceFolderLabel.Text;
            string destPath = this.destFolderLabel.Text;
            int invalidPathChecks = InvalidPathHandling(sourcePath, destPath);
            if (invalidPathChecks == 0)
            {
                var fileInfoList = FileUtils.GetFileInfoList(sourcePath);
                ExtensionListForm frm2 = new ExtensionListForm(sourcePath, destPath, fileInfoList);

                frm2.ShowDialog();
            }
        }

        private int InvalidPathHandling(string sourcePath, string destPath)
        {
            var invalidChars = Path.GetInvalidPathChars();
            var invalidCharsAsString = string.Join(", ", invalidChars);

            //Check if the paths contain any invalid characters
            foreach (var c in invalidChars)
            {
                if (sourcePath.Contains(c)) 
                {
                    string errorMsg = $"The source folder \"{sourcePath}\" contains characters that are not allowed in a path. Invalid characters in a path are {invalidCharsAsString}";
                    MessageBox.Show(errorMsg, "Invalid characters in path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (destPath.Contains(c))
                {
                    string errorMsg = $"The destination folder \"{destPath}\" contains characters that are not allowed in a path. Invalid characters in a path are {invalidCharsAsString}";
                    MessageBox.Show(errorMsg, "Invalid characters in path", MessageBoxButtons.OK, MessageBoxIcon.Error); MessageBox.Show(errorMsg, "Invalid characters in path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            //Check if path is a rooted path (because else we can't really create it)
            if (!Path.IsPathRooted(sourcePath))
            {
                string errorMsg = $"The source folder \"{sourcePath}\" is not rooted. Please select a path that is fully specified from a root drive";
                MessageBox.Show(errorMsg, "Path is not rooted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (!Path.IsPathRooted(destPath))
            {
                string errorMsg = $"The destination folder \"{destPath}\" is not rooted. Please select a path that is fully specified from a root drive";
                MessageBox.Show(errorMsg, "Path is not rooted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            //Check whether the source folder exists at all
            else if (!Directory.Exists(sourcePath))
            {
                string errorMsg = $"The source folder \"{sourcePath}\" does not exist. Please select a folder that does exist";
                MessageBox.Show(errorMsg, "Source folder does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            //The destination folder is allowed to not exist, we create it in "FileCopier" if necessary
            return 0;            
        }

        //This is to be able to use the console while running the application
        //(in order to print values to debug)
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}