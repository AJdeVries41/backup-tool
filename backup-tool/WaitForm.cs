using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace backup_tool
{
    public partial class WaitForm : Form
    {
        string sourceDirName;
        string destDirName;
        List<string> finalFileExtensions;
        int totalAmountOfFiles;
        long finalExecutionTime;
        public WaitForm(string sourceDirName, string destDirName, List<string> finalFileExtensions, int totalAmountOfFiles)
        {
            InitializeComponent();

            this.sourceDirName = sourceDirName;
            this.destDirName = destDirName;
            this.finalFileExtensions = finalFileExtensions;
            this.totalAmountOfFiles = totalAmountOfFiles;

            //Reset the boilerplate text which I gave it in the designer
            this.execTimeLabel.Text = "";
            this.loadPercentLabel.Text = "";

            this.backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            var c = new FileCopier(this.finalFileExtensions, this.totalAmountOfFiles, worker);
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();



            //do the expensive operation
            var sourceDir = new DirectoryInfo(this.sourceDirName);
            var destDir = new DirectoryInfo(this.destDirName);

            c.CopyToDirectory(sourceDir, destDir);

            stopwatch.Stop();
            this.finalExecutionTime = stopwatch.ElapsedMilliseconds;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.loadPercentLabel.Text = $"{e.ProgressPercentage}%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                this.label1.Text = "Encountered an error. Operation was stopped";
            }
            else if (e.Cancelled)
            {
                this.label1.Text = "Operation was cancelled";
            }
            else
            {
                this.label1.Text = "*All done* (You can now close the application)";
                this.execTimeLabel.Text = $"Final execution time: {this.finalExecutionTime} ms";
                //IDK if this is necessary, but it might be...
                this.progressBar1.Value = 100;
                this.loadPercentLabel.Text = $"100%";
            }
        }
    }
}
