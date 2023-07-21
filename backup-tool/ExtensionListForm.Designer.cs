namespace backup_tool
{
    partial class ExtensionListForm
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
            this.exts = new System.Windows.Forms.CheckedListBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exts
            // 
            this.exts.FormattingEnabled = true;
            this.exts.Location = new System.Drawing.Point(53, 100);
            this.exts.Name = "exts";
            this.exts.Size = new System.Drawing.Size(421, 327);
            this.exts.TabIndex = 0;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(226, 433);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(91, 37);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 10);
            this.label1.MaximumSize = new System.Drawing.Size(350, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "<Instructions appear here>";
            // 
            // ExtensionListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 482);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.exts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExtensionListForm";
            this.Text = "backup-tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox exts;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label1;
    }
}