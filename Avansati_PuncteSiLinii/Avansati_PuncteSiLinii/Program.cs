using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriunghiMinim
{
    class Program
    {
        static Random rnd = new Random();
        static int resx = 1000;
        static int resy = 1000;
        struct Point
        {
            public float x, y;
            public void init()
            {
                x = rnd.Next(resx);
                y = rnd.Next(resy);
            }
            public void view()
            {
                Console.Write("(" + x + "," + y + ")");
            }
        }

        static float Aria(Point A, Point B, Point C)
        {
            return 0.5f * Math.Abs((A.x * B.y) + (B.x * C.y) + (C.x * A.y) - (C.x * B.y) - (A.x * C.y) - (A.y - B.x));
        }

        static void Main(string[] args)
        {
            int n = 23;
            Point[] p = new Point[n];
            for (int i = 0; i < n; i++)
            {
                p[i].init();
            }
            for (int i = 0; i < n; i++)
            {
                // p[i].view();
            }
            float aria, ariaMinima = Aria(p[0], p[1], p[2]);
            int x1 = 0, x2 = 1, x3 = 2;
            for (int i1 = 0; i1 < n - 2; i1++)
            {
                for (int i2 = i1 + 1; i2 < n - 1; i2++)
                {
                    for (int i3 = i2 + 1; i3 < n; i3++)
                    {
                        aria = Aria(p[i1], p[i2], p[i3]);
                        if (aria < ariaMinima)
                        {
                            ariaMinima = aria;
                            x1 = i1; x2 = i2; x3 = i3;
                        }
                    }
                }
            }
            Console.WriteLine($"Area minima: {ariaMinima}");
            Console.ReadKey();
        }
    }
}