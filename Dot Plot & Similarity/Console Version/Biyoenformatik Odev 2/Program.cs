using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biyoenformatik_Odev_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Biyoenformatik Odev 2";
            Console.WriteLine("Input 1");
            string sequence1 = Console.ReadLine();
            Console.WriteLine("Input 2");
            string sequence2 = Console.ReadLine();
            Console.WriteLine("Matrix type (1=with stars, 2=with letters(default))");
            int type = 2;
            if (Int32.TryParse(Console.ReadLine(), out int val))
                if (val == 1)
                    type = 1;
            Console.WriteLine("Add Edges (1=yes, 0=no(default))");
            int edges = 0;
            if (Int32.TryParse(Console.ReadLine(), out int num))
                if (num == 1)
                    edges = 1;
            if (edges == 0)
                ShowDotPlot(CalculateDotPlot(sequence1, sequence2, type));
            else
                ShowDotPlot(AddEdgesToDotPlot(CalculateDotPlot(sequence1, sequence2, type)));
        }
        //Benzerlik hesaplanır
        static double CalculateIdentity(char[,] dotPlot,int edge)
        {
            int count = 0;
            int start,jump;
            if (edge == 1)
            {
                start = 3;
                jump = 2;
            }
            else
            {
                start = 1;
                jump = 1;
            }
            for (int i = start; i < Math.Min(dotPlot.GetLength(0), dotPlot.GetLength(1)); i += jump)
                if (dotPlot[i, i] != '\0')
                    count++;
            double denominator = Math.Max(dotPlot.GetLength(0) / (edge + 1) - 1, dotPlot.GetLength(1) / (edge + 1) - 1);
            return count * 1.0 / denominator;
        }
        //Nokta matrisine kenarlıklar eklenir
        static char[,] AddEdgesToDotPlot(char[,] dotPlot)
        {
            char[,] resultMatrix = new char[dotPlot.GetLength(0) * 2 + 1, dotPlot.GetLength(1) * 2 + 1];
            for (int i = 0; i < resultMatrix.GetLength(1); i++)
            {
                resultMatrix[0, i] = '-';
                resultMatrix[resultMatrix.GetLength(0) - 1,i] = '-';
            }
            for (int i = 1; i < resultMatrix.GetLength(0)-1; i++)
                resultMatrix[i, 0] = '|';
            for (int i = 1; i < resultMatrix.GetLength(0)-1; i++)
            {
                for (int j = 1; j < resultMatrix.GetLength(1); j++)
                {
                    if (i % 2 == 1 && j % 2 == 1)
                        resultMatrix[i, j] = dotPlot[i / 2, j / 2];
                    if (i % 2 == 0)
                        resultMatrix[i, j] = '-';
                    if (j % 2 == 0)
                        resultMatrix[i, j] = '|';


                }
            }
            return resultMatrix;
        }
        //Nokta matrisi ve benzerlik oranı ekrana yazdırılır
        static void ShowDotPlot(char[,] dotPlot)
        {
            Console.WriteLine();
            for (int i = 0; i < dotPlot.GetLength(0); i++)
            {
                for (int j = 0; j < dotPlot.GetLength(1); j++)
                {
                    Console.Write(dotPlot[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nIdentity: " + Math.Round(100.0 * CalculateIdentity(dotPlot,(dotPlot[0,0]=='-')?1:0), 2) + "%");
        }
        //Nokta matrisi hesaplanır
        static char[,] CalculateDotPlot(string seq1, string seq2, int type)
        {
            int len1 = seq1.Length;
            int len2 = seq2.Length;
            char[,] dotPlot = new char[len1 + 1, len2 + 1];
            for (int i = 1; i < len2 + 1; i++)
                dotPlot[0, i] = seq2[i - 1];
            for (int i = 1; i < len1 + 1; i++)
                dotPlot[i, 0] = seq1[i - 1];
            char temp;
            for (int i = 1; i < len1 + 1; i++)
            {
                if (type == 1)
                    temp = '*';
                else
                    temp = seq1[i - 1];
                for (int j = 1; j < len2 + 1; j++)
                {
                    if (Char.ToUpper(seq1[i - 1]) == char.ToUpper(seq2[j - 1]))
                        dotPlot[i, j] = temp;
                }
            }
            return dotPlot;
        }
    }
}
