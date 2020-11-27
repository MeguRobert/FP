using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_LAB_SumaDivizori
{
    class Program
    {
        static void Main(string[] args)
        {
            //SumaDivizoriImpare();
            //DivizoriComune();
            //GenerareSir();
            //Convertire();
            Vectori();

        }
        /// <summary>
        /// 
        /// </summary>
        private static void Vectori()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            bool palindrom = true;
            for (int i = 0; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n / 2; i++)
            {
                if (v[i] != v[n - i - 1]) {palindrom = false; break;}
            }
            Console.WriteLine();
            if (palindrom)
            {
                Console.WriteLine("Palindrom");
            }
            
        }

        private static void Convertire()
        {
            int b = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int nr = 0;
            for (int i = 1; i <= n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                nr += x * (int)Math.Pow(b, n - i);
            }
            Console.WriteLine(nr);
        }

       

        private static void DivizoriComune()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int min;
            if (a <= b) min = a;
            else min = b;
            for (int i = 1; i <= min; i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    Console.WriteLine(i);
                }

            }
            
        }

        private static void SumaDivizoriImpare()
        {
            int n = int.Parse(Console.ReadLine());
            int s = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0 && i % 2 != 0)
                {
                    s += i;
                }

            }
            Console.WriteLine(s);
        }
    }
}
