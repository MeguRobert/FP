using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme_cu_vectori_2
{
    class Program
    {
        static int n, x, i;
        static int[] v;
        static void Main(string[] args)
        {
            //GetVector();
            GetVector2();
            //Suma_3_Max(n, v);
            //ValoareCeleMaiMulteOri();
            NrMinMax();
        }

        private static void NrMinMax()
        {
            int max=0, min=0,p,a;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < v.Length; j++)
                {
                    if (v[i] <= v[j])
                    {
                        a = v[i]; v[i] = v[j]; v[j] = a;
                    }
                }
            }
            p = n;
            Wiew();
            for (i = 0; i < n; i++)
            {
                max = max * 10 + v[i];
            }
            Console.WriteLine(max);
            for (int i = n - 1; i >= 0; i--)
            {
                    if (v[i] != 0) { min = v[i]; p = i; break; }
            }
            for (int i = n - 1; i >= 0; i--)
            {
                if (p != i) 
                {
                    min = min * 10 + v[i]; 
                }
            }
            Console.WriteLine(min);
        }

        private static void GetVector2()
        {
            string line = Console.ReadLine();
            x = int.Parse(line);
            n = line.Length;
            v = new int[n];
            i = 0;
            while (x != 0)
            {
                v[i] = x % 10;
                i++;
                x /= 10;
            }

            Wiew();
        }

        private static void Wiew()
        {
            for (i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }

        private static void ValoareCeleMaiMulteOri()
        {
            int a, max = 1, x = v[0];
            for (int i = 0; i < v.Length-1; i++)
            {
                a = 1;
                for (int j = i + 1; j < v.Length; j++)
                {
                    if (v[i]==v[j])
                    {
                        a++;
                    }
                }
                if (max<a)
                {
                    max = a;
                    x = v[i];
                }
            }
            Console.WriteLine($"{x} apare de {max} ori");
        }

        private static void Suma_3_Max(int n, int[] v)
        {
            int a;
            int max1 = v[0];
            int max2 = v[1];
            int max3 = v[2];

            if (max3 > max2) { a = max3;max3 = max2; max2 = a; }
            if (max2 > max1) { a = max2;max2 = max1; max1 = a; }
            if (max3 > max1) { a = max3;max3 = max1; max1 = a; }

            for (int i = 3; i < v.Length; i++)
            {
                if (v[i] >= max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = v[i];
                }
                else if (v[i] >= max2 && v[i]<max1)
                {
                    max3 = max2;
                    max2 = v[i];
                }
                else if (max3>=v[i] && max2<v[i])
                    max3 = v[i];
                
            }
            Console.WriteLine(max1);
            Console.WriteLine(max2);
            Console.WriteLine(max3);
            int s = max1 + max2 + max3;
            Console.WriteLine(s);
        }

        private static void GetVector()
        {
            n = int.Parse(Console.ReadLine());
            v = new int[n];
            //adaugare un spatiu liber in memorie
            //pentru numarul inserat
            for (i = 0; i < n; i++)
            {
                Console.Write($"v[{i}]=");
                v[i] = int.Parse(Console.ReadLine());
            }
            for (i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }
    }
}
