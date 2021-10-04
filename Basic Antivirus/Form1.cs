using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

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
                    return BitConverter.ToString(md5.ComputeHash(stream));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                tbMD5.Text = GetMD5FromFile(browse.FileName);
            }
        }
    }
}
