using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Biyoenformatik_Odev_1
{
    class FileOperations
    {
        public static Dictionary<string,string> ReadFile(string path)
        {
            StreamReader txt = new StreamReader(path);
            string temp;
            string[] keyVal;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            while (!txt.EndOfStream)
            {
                temp = txt.ReadLine();
                keyVal=temp.Split(' ');
                dict[keyVal[0]] = keyVal[1];
            }
            return dict;
        }
        public static void ReadFasta(string path,RichTextBox input)
        {
            input.Text = "";
            StreamReader txt = new StreamReader(path);
            string temp;
            while (!txt.EndOfStream)
            {
                temp = txt.ReadLine();
                if(temp[0]!=';' && temp[0]!='>')
                    input.AppendText(temp);
            }
        }
    }
}
