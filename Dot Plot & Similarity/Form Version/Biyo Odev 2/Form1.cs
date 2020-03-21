using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Biyo_Odev_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Similarity: ";
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            string sequence1, sequence2;
            if (richTextBox1.Text.Length > richTextBox2.Text.Length)
            {
                sequence2 = richTextBox1.Text;
                sequence1 = richTextBox2.Text;
            }
            else
            {
                sequence2 = richTextBox2.Text;
                sequence1 = richTextBox1.Text;
            }
            if (sequence1.Length != 0 && sequence2.Length != 0)
                ShowDotPlot(CalculateDotPlot(sequence1, sequence2), this);
        }
        //Benzerlik hesaplanır
        static double CalculateIdentity(char[,] dotPlot)
        {
            int count = 0;
            for (int i = 0; i < Math.Min(dotPlot.GetLength(0), dotPlot.GetLength(1)); i++)
                if (dotPlot[i, i] != '\0')
                    count++;
            double denominator = Math.Max(dotPlot.GetLength(0), dotPlot.GetLength(1));
            return count * 1.0 / denominator;
        }
        //Asal köşegen çizilir ve eşleşmeler yerleştirilir
        static void ShowDotPlot(char[,] dotPlot, Form1 form)
        {
            int x = 5;
            form.chart1.ChartAreas[0].AxisX.Minimum = 0;
            form.chart1.ChartAreas[0].AxisX.Maximum = (dotPlot.GetLength(0) == 1) ? x : (dotPlot.GetLength(0) - 1) * x;
            form.chart1.ChartAreas[0].AxisY.Minimum = 0;
            form.chart1.ChartAreas[0].AxisY.Maximum = (dotPlot.GetLength(1) == 1) ? x : (dotPlot.GetLength(1) - 1) * x;
            form.chart1.Series[1].Points.Add(new DataPoint(0, form.chart1.ChartAreas[0].AxisY.Maximum));
            form.chart1.Series[1].Points.Add(new DataPoint(form.chart1.ChartAreas[0].AxisX.Maximum, 0));
            int index;
            for (int i = 0; i < dotPlot.GetLength(0); i++)
            {
                index = 0;
                for (int j = dotPlot.GetLength(1) - 1; j >= 0; j--)
                {
                    if (dotPlot[i, index] != '\0')
                    {
                        form.chart1.Series[0].Points.AddXY(x * i, x * j);
                    }
                    index++;
                }
            }
            form.label3.Text += Math.Round((CalculateIdentity(dotPlot) * 100), 2).ToString() + "%";
        }
        //Benzerlik noktaları bulunur
        static char[,] CalculateDotPlot(string seq1, string seq2)
        {
            int len1 = seq1.Length;
            int len2 = seq2.Length;
            char[,] dotPlot = new char[len1, len2];
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    if (Char.ToUpper(seq1[i]) == char.ToUpper(seq2[j]))
                    {

                        dotPlot[i, j] = seq1[i];
                    }
                }
            }
            return dotPlot;
        }
    }
}
