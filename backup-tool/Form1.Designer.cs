namespace backup_tool
{
    partial class Form1
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
            this.sourceFolderTextbox = new System.Windows.Forms.TextBox();
            this.targetFolderButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.targetFolderTextbox = new System.Windows.Forms.TextBox();
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sourceFolderTextbox
            // 
            this.sourceFolderTextbox.Location = new System.Drawing.Point(98, 147);
            this.sourceFolderTextbox.Name = "sourceFolderTextbox";
            this.sourceFolderTextbox.Size = new System.Drawing.Size(164, 22);
            this.sourceFolderTextbox.TabIndex = 1;
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
            // targetFolderTextbox
            // 
            this.targetFolderTextbox.Location = new System.Drawing.Point(516, 147);
            this.targetFolderTextbox.Name = "targetFolderTextbox";
            this.targetFolderTextbox.Size = new System.Drawing.Size(158, 22);
            this.targetFolderTextbox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.targetFolderTextbox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.targetFolderButton);
            this.Controls.Add(this.sourceFolderTextbox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox sourceFolderTextbox;
        private System.Windows.Forms.Button targetFolderButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox targetFolderTextbox;
    }
}