namespace backup_tool
{
    partial class WaitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar1 = new System.Windows.Forms.ProgressBar();
            label1 = new System.Windows.Forms.Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            execTimeLabel = new System.Windows.Forms.Label();
            loadPercentLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(102, 245);
            progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(435, 36);
            progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(169, 34);
            label1.MaximumSize = new System.Drawing.Size(300, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(295, 72);
            label1.TabIndex = 2;
            label1.Text = "Please wait, copying files...";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // execTimeLabel
            // 
            execTimeLabel.AutoSize = true;
            execTimeLabel.Location = new System.Drawing.Point(102, 378);
            execTimeLabel.Name = "execTimeLabel";
            execTimeLabel.Size = new System.Drawing.Size(312, 20);
            execTimeLabel.TabIndex = 3;
            execTimeLabel.Text = "<execution time appears here when finished>";
            // 
            // loadPercentLabel
            // 
            loadPercentLabel.AutoSize = true;
            loadPercentLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            loadPercentLabel.Location = new System.Drawing.Point(288, 285);
            loadPercentLabel.Name = "loadPercentLabel";
            loadPercentLabel.Size = new System.Drawing.Size(132, 23);
            loadPercentLabel.TabIndex = 4;
            loadPercentLabel.Text = "progressPercent";
            // 
            // WaitForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(651, 441);
            Controls.Add(loadPercentLabel);
            Controls.Add(execTimeLabel);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "WaitForm";
            Text = "backup-tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label execTimeLabel;
        private System.Windows.Forms.Label loadPercentLabel;
    }
}