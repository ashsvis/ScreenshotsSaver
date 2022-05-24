using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotsSaver
{
    public partial class TuningForm : Form
    {
        public TuningForm()
        {
            InitializeComponent();
        }

        public void Build(string selectedPath)
        {
            if (!string.IsNullOrWhiteSpace(selectedPath) && !cbFolder.Items.Contains(selectedPath))
                cbFolder.Items.Add(selectedPath);
            cbFolder.Text = selectedPath;
        }

        public string SelectedPath => cbFolder.Text;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = SelectedPath;
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                if (!cbFolder.Items.Contains(folderBrowserDialog1.SelectedPath))
                    cbFolder.Items.Add(folderBrowserDialog1.SelectedPath);
                cbFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
