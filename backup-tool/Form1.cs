using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace backup_tool
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog sourceFolderDialog;
        private FolderBrowserDialog targetFolderDialog;
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            this.sourceFolderDialog = new FolderBrowserDialog();
            this.targetFolderDialog = new FolderBrowserDialog();
        }

        //This is to be able to use the console while running the application
        //(in order to print values to debug)
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.sourceFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.sourceFolderTextbox.Text = this.sourceFolderDialog.SelectedPath;
            }
        }

        private void targetFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = this.targetFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.targetFolderTextbox.Text = this.targetFolderDialog.SelectedPath;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            //recursively print all files from the source folder
            DirectoryInfo d = new DirectoryInfo(this.sourceFolderTextbox.Text);
            if (d.Exists)
            {
                Console.WriteLine("Directory exists");
                foreach (var file in d.EnumerateFiles()) 
                { 
                    Console.WriteLine(file.FullName);
                } 
                /*foreach (var file in d.GetFiles())
                {
                    Console.WriteLine(file.FullName);
                }*/
            }
        }
    }
}