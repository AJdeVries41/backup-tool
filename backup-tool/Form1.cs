using System;
using System.Drawing;
using System.IO;
using System.Linq;
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
            string sourcePath = this.sourceFolderTextbox.Text;
            string destPath = this.targetFolderTextbox.Text;
            //recursively print all files from the source folder
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

                var sortedExtsBySize = FileUtils.ExtensionToFilesize(fileInfoList);


                Form2 frm2 = new Form2(sortedExtsBySize);

                // Create a button to add to the new form.
                Button button1 = new Button();
                // Set text for the button.
                button1.Text = "Scrolled Button";
                // Set the size of the button.
                button1.Size = new Size(100, 30);
                // Set the location of the button to be outside the form's client area.
                button1.Location = new Point(frm2.Size.Width + 200, frm2.Size.Height + 200);

                // Add the button control to the new form.
                frm2.Controls.Add(button1);
                // Set the AutoScroll property to true to provide scrollbars.
                frm2.AutoScroll = true;

                // Display the new form as a dialog box.
                frm2.ShowDialog();

                return;

            }
        }
    }
}