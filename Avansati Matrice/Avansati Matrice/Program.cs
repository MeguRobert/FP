using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansati_Matrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[5, 5]
            {
                {1,1,8,1,4 },
                {2,2,7,2,4 },
                {3,0,6,0,8 },
                {3,0,6,0,8 },
                {4,0,2,1,1 }
            };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{a[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
