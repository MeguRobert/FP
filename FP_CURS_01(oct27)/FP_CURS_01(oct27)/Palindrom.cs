using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_CURS_01_oct27_
{
    class Palindrom
    {
        static void Main(string[] args)
        {
            int n = SumaCifra.GetIntFromConsole();
            Console.WriteLine("<<<<Palindrom>>>>");
           

            if (IsPalindrom(n))
            {
                Console.WriteLine("PALINDROM");
            }
            else
            {
                Console.WriteLine("Nu");
            }
        }

        private static bool IsPalindrom(int n)
        {
            if (n == Reverse(n)) return true;
            else return false;
        }

        private static int Reverse(int n)
        {
            int x = 0;
            while (n > 0)
            {
                x = x * 10 + (n % 10);
                n /= 10;
            }
            return x;
        }
    }
}
