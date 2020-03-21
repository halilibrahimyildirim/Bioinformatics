using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Biyoenformatik_Odev_1
{
    class Translator
    {
        Dictionary<string, string> DNA;
        Dictionary<string, string> AA;
        public Translator(Dictionary<string, string> DNA, Dictionary<string, string> AA)
        {
            this.DNA = DNA;
            this.AA = AA;
        }
        public void AAtoDNA(string sequence, RichTextBox box)
        {
            string key;
            Color defBack = box.SelectionBackColor;
            Color defFore = box.SelectionColor;
            for (int i = 0; i < sequence.Length; i++)
            {
                key = sequence[i].ToString();
                if (AA.ContainsKey(key))
                {
                    box.AppendText(AA[key]);
                }
                else
                {
                    box.SelectionColor = Color.Red;
                    box.AppendText(key);
                    box.SelectionColor = defFore;
                }
            }
        }
        public void DNAtoAA(string sequence, RichTextBox box)
        {
            string key;
            Color defBack = box.SelectionBackColor;
            Color defFore = box.SelectionColor;
            for (int i = 0; i < sequence.Length-2; i += 3)
            {
                key = sequence[i] + "" + sequence[i + 1] + "" + sequence[i + 2];
                if (DNA.ContainsKey(key))
                {
                    box.AppendText(DNA[key]);
                }
                else
                {
                    box.SelectionColor = Color.Red;
                    box.AppendText(key);
                    box.SelectionColor = defFore;
                }
            }
            int mod = sequence.Length % 3;
            if (mod != 0)
            {
                key = "";
                for (int i = sequence.Length - mod; i < sequence.Length; i++)
                    key += sequence[i];
                box.SelectionColor = Color.Red;
                box.AppendText(key);
                box.SelectionColor = defFore;
            }
        }
        public void DNAtoProtein(string sequence, RichTextBox box)
        {
            string key;
            Color defBack = box.SelectionBackColor;
            Color defFore = box.SelectionColor;
            for (int i = 0; i < sequence.Length - 2; i += 3)
            {
                key = sequence[i] + "" + sequence[i + 1] + "" + sequence[i + 2];
                if (DNA.ContainsKey(key))
                {
                    if(DNA[key]=="M")
                    {
                        box.SelectionColor = Color.Green;
                        defFore = Color.Green;
                    }
                    if (DNA[key] == "*")
                    {
                        defFore = Color.Black;
                        box.SelectionColor = defFore;
                    }
                    box.AppendText(DNA[key]);
                }
                else
                {
                    box.SelectionColor = Color.Red;
                    box.AppendText(key);
                    box.SelectionColor = defFore;
                }
            }
            int mod = sequence.Length % 3;
            if (mod != 0)
            {
                key = "";
                for (int i = sequence.Length - mod; i < sequence.Length; i++)
                    key += sequence[i];
                box.SelectionColor = Color.Red;
                box.AppendText(key);
                box.SelectionColor = defFore;
            }
        }
    }
}
