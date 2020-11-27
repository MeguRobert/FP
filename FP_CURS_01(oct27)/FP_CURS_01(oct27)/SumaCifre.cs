using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_CURS_01_oct27_
{
    class SumaCifra
    {
        static void Main(string[] args)
        {
            int n;
            n= GetIntFromConsole();
            //calc suma cifrelor numarului:
            Console.WriteLine($"Suma cifrelor numarului {n} este {SumaCifre(n)} ");
            Console.WriteLine($"Suma cifrelor numarului {n} este {SumaCifreRecursiva(n)} ");
        }

        public static int SumaCifreRecursiva(int n)
        {
            if (n == 0) return 0;
            else return n % 10 + SumaCifreRecursiva(n / 10);
        }

        /// <summary>
        /// Suma cifrelor.....
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int SumaCifre(int n)
        {
            int suma = 0;
            while (n>0)
            {
                suma += n % 10;
                n /= 10;
            }
            return suma;
        }

        public static int GetIntFromConsole()
        {
            int n=0;
            string line;
            bool flag;

            do
            {
                flag = true;
                Console.WriteLine("Introduceti un numar intreg");
                line = Console.ReadLine();
                try
                {
                    n = int.Parse(line);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    flag = false;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    flag = false;
                }

            } while (!flag);

            return n;
        }
    }
}
