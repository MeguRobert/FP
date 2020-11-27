using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FP_2020_10_13_EX_1
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int pc, x;
            pc = rnd.Next(101);
            bool ok=false;
            Console.WriteLine("          ***********************************************");
            Console.WriteLine("          ******** LA CE NUMAR M-AM GANGIT EU? **********");
            Console.WriteLine("          ************* INTRE 0 SI 100 ******************");
            Console.WriteLine("          ***********************************************");

            Console.WriteLine("");
            for(int i=1;i<=10;i++)
            {
                Console.Write("INCERCAREA TA: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                if (x < pc) Console.WriteLine("Incearca mai mare!\n");
                else if (x > pc) Console.WriteLine("Incearca mai mic\n");
                else { Console.WriteLine("Ai castigat!");ok = true; break; }
            }

            if (!ok) Console.WriteLine("Ai pierdut...");

        }
    }
}
