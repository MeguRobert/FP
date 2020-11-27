using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Program
    {
        static int[] v1,v2;
        static char operation;
        static int n;
        static string line;

        static void Main(string[] args)
        {
            GetData();
            MakeVector(ref v1, n);
            //View(v1);
            
            GetData();
            MakeVector(ref v2, n);
            //View(v2);
            Console.WriteLine();
            View(GestionareSuma(v1, v2));

        }

        private static int[] GestionareSuma(int[] v1, int[] v2)
        {
            if (v1.Length>=v2.Length)
            {
                return Suma(v1, v2);
            }
            else
            {
                return Suma(v2, v1);
            }
        }

        private static int[] Suma(int[] v1, int[] v2)
        {
            int max, min, s, k;
            max = v1.Length;
            min = v2.Length;
            int[] v = new int[max + 1];
            int trans = 0;
            for (int i = max - 1; i >= 0; i--)
            {
                k = i - (max - min);
                s = 0;
                s += v1[i];
                if (k >= 0)
                    s += v2[k];

                s += trans;
                v[i + 1] = s;
                trans = v[i + 1] / 10;
                v[i + 1] %= 10;
            }
            v[0] = trans;
            return v;
        }

        private static void GetData()
        {
            line = Console.ReadLine();
            n = line.Length;
        }

        private static void View(int[] v)
        {
            if (v[0]!=0)
            {
                Console.Write($"{v[0]}");
            }
            for (int i = 1; i < v.Length; i++)
            {
                Console.Write($"{v[i]}");
            }
            Console.WriteLine("");
        }

        private static void in10(int[] v, int n)
        {
            for (int i = 0; i < v.Length; i++)
            {

            }
        }

        private static void MakeVector(ref int[] v,int n)
        {
            v = new int[n];
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = Convert.ToInt32(line[i]-'0');
            }
        }
    }
}
