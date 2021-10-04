using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Drawing;

namespace Basic_Antivirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetMD5FromFile(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var md5signatures = File.ReadAllLines("MD5base.txt");
            if (md5signatures.Contains(tbMD5.Text))
            {
                lbStatus.Text = "Infected!";
                lbStatus.ForeColor = Color.Red;
            }

            else
            {
                lbStatus.Text = "Clean!";
                lbStatus.ForeColor = Color.Green;
            }
        }

        /// <summary>
        /// Open explorer to select a file.
        /// </summary>
        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog();
            browse.Filter = "Textfiles | *.txt";
            if(browse.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = browse.FileName;
                tbMD5.Text = GetMD5FromFile(browse.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
