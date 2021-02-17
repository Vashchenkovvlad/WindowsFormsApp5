using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private string CurrentFile { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Текстовые файлы(*.txt)| *.txt";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            CurrentFile = fileDialog.FileName;

            if (!CurrentFile.EndsWith(".txt"))
                return;
            StreamReader sr = File.OpenText(CurrentFile);
            richTextBox1.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(CurrentFile))
                sw.WriteLine(richTextBox1.Text);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() != DialogResult.OK)
                return;
            Font = fontDialog.Font;
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() != DialogResult.OK)
                return;
            richTextBox1.BackColor = colorDialog.Color;
        }
    }
}
