namespace backup_tool
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.targetFolderButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.sourceFolderLabel = new System.Windows.Forms.Label();
            this.destFolderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Source Folder...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.sourceFolderButton_Click);
            // 
            // targetFolderButton
            // 
            this.targetFolderButton.Location = new System.Drawing.Point(516, 48);
            this.targetFolderButton.Name = "targetFolderButton";
            this.targetFolderButton.Size = new System.Drawing.Size(158, 34);
            this.targetFolderButton.TabIndex = 2;
            this.targetFolderButton.Text = "Select target folder...";
            this.targetFolderButton.UseVisualStyleBackColor = true;
            this.targetFolderButton.Click += new System.EventHandler(this.targetFolderButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(329, 375);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(137, 44);
            this.runButton.TabIndex = 3;
            this.runButton.Text = "RUN";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(329, 48);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(118, 34);
            this.testButton.TabIndex = 5;
            this.testButton.Text = "TEST";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // sourceFolderLabel
            // 
            this.sourceFolderLabel.AutoSize = true;
            this.sourceFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceFolderLabel.Location = new System.Drawing.Point(93, 147);
            this.sourceFolderLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.sourceFolderLabel.Name = "sourceFolderLabel";
            this.sourceFolderLabel.Size = new System.Drawing.Size(176, 50);
            this.sourceFolderLabel.TabIndex = 6;
            this.sourceFolderLabel.Text = "<Source folder will appear here>";
            // 
            // destFolderLabel
            // 
            this.destFolderLabel.AutoSize = true;
            this.destFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destFolderLabel.Location = new System.Drawing.Point(511, 147);
            this.destFolderLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.destFolderLabel.Name = "destFolderLabel";
            this.destFolderLabel.Size = new System.Drawing.Size(179, 50);
            this.destFolderLabel.TabIndex = 7;
            this.destFolderLabel.Text = "<Destination folder will appear here>";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.destFolderLabel);
            this.Controls.Add(this.sourceFolderLabel);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.targetFolderButton);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "backup-tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button targetFolderButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label sourceFolderLabel;
        private System.Windows.Forms.Label destFolderLabel;
    }
}