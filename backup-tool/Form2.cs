using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace backup_tool
{
    public partial class Form2 : Form
    {
        public Form2(List<KeyValuePair<string, long>> sortedExtsBySize)
        {
            InitializeComponent();

            foreach (var pair in sortedExtsBySize)
            {
                string sizeString = $"\t({FileUtils.ByteToGB(pair.Value).ToString()} GB)";
                exts.Items.Add(pair.Key+sizeString, false);
            }

            this.Controls.Add(exts);
           
            this.ShowDialog();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //TODO   
            return;
        }
    }
}
