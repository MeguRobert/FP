using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimi
{

    class Program
    {
        static void Main(string[] args)
        {

            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int[] v1 = new int[n1];
            int[] v2 = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                v1[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("///////////////");

            for (int i = 0; i < n2; i++)
            {
                v2[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("///////////////");

            Console.Write("("+v1[0]);
            for (int i = 1; i < n1; i++)
            {
                Console.Write(","+v1[i]);
            }
            Console.Write(")");







            /* n1 = int.Parse(Console.ReadLine());
             n2 = int.Parse(Console.ReadLine());
             int[] A = new int[n1]; 
             int[] B = new int[n2];
             int[] Rez = new int[n1 + n2];
             int k = 0;
             for (int i=0; i< n1; i++)
             {
                 A[i]=
             }*/
        }
    }
}
