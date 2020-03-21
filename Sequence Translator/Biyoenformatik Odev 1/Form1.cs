using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Biyoenformatik_Odev_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            Translator translator = new Translator(FileOperations.ReadFile("dnaToAaTable.txt"), FileOperations.ReadFile("aaToDNATable.txt"));
            string sequence = richTextBox1.Text;
            if (radioButton1.Checked)
            {
                sequence=sequence.Replace('u', 't').Replace('U', 'T');
                translator.DNAtoAA(sequence.ToLower(), richTextBox2);
            }
                
            else if (radioButton2.Checked)
            {
                sequence=sequence.Replace('u', 't').Replace('U', 'T');
                translator.DNAtoProtein(sequence.ToLower(), richTextBox2);
            }
            else if (radioButton3.Checked)
            {
                translator.AAtoDNA(sequence.ToUpper(), richTextBox2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = ofd.CheckPathExists = true;
            string path;
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                path = ofd.FileName;
                string[] temp = path.Split('.');
                if (temp[temp.Count()-1] != "fasta")
                {
                    MessageBox.Show("File Format Must Be '.fasta'");
                }
                else
                {
                    FileOperations.ReadFasta(path, richTextBox1);
                }
            }
        }
    }
}
