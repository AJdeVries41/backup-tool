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
            this.waitingText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // waitingText
            // 
            this.waitingText.AcceptsReturn = true;
            this.waitingText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingText.Location = new System.Drawing.Point(12, 26);
            this.waitingText.Name = "waitingText";
            this.waitingText.ReadOnly = true;
            this.waitingText.Size = new System.Drawing.Size(745, 75);
            this.waitingText.TabIndex = 0;
            this.waitingText.Text = "Please wait, copying files...";
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.waitingText);
            this.Name = "WaitForm";
            this.Text = "WaitForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox waitingText;
    }
}