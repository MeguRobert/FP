using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_CURS_02_GenerareSir
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreiNPlus1();
            //Coins();
            //Stars();
            BlackHole();
        }

        /// <summary>
        /// ********
        /// ***  ***
        /// **    **
        /// *      *
        /// **    **
        /// ***  ***
        /// ********
        /// </summary>
        private static void BlackHole()
        {
            int n = 4;
            for (int i = 1; i <= 2*n; i++)
            {
                for (int j = 1; j <= 2*n; j++)
                {

                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Stars()
        {
            int n = 4;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            
        }

        private static void Coins()
        {
            int times = 1000;
            int stake = 50;
            int goal = 100;
            int loses = 0;
            int wins = 0;
            Random rnd = new Random();


            for (int i = 0; i < times; i++)
            {
                stake = 50;
                goal = 100;
                while (!(stake == 0 || stake == goal))
                {
                    if (rnd.Next(2) == 0)
                    {
                        stake++;
                    }
                    else
                    {
                        stake--;
                    }
                }
                if (stake == 0) loses++;
                else wins++;


            }

            Console.WriteLine("wins: " + wins + " loses: " + loses);
        }

        private static void TreiNPlus1()
        {
            int a = 7;
            (int lungime, int max) result = TreiNPlus1(a);
            Console.WriteLine(result.lungime);
            Console.WriteLine(result.max);
        }

        private static (int,int) TreiNPlus1(int a)
        {
            
            int x = a;
            Console.Write(x);
            int contor = 1;
            int maxim = 0;
            while (x != 1)
            {
                if (x % 2 == 0)
                {
                    x /= 2;
                }
                else
                {
                    x = x * 3 + 1;
                }
                Console.Write(" " + x);
                contor++;
                if (x > maxim) maxim = x;
            }
            Console.WriteLine();
            //Tuple<int, int> result = new Tuple<int, int>(contor, maxim);
            return (contor, maxim);
        }
    }
}
