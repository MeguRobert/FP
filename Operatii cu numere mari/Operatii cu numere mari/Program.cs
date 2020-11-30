using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Operatii_cu_numere_mari
{
    class Program
    {
        static int[] v1,v2;
        static char operation;
        static int n,x;
        static string line;
        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            /* GetData();
             MakeVector(ref v1, n);

             GetData();
             MakeVector(ref v2, n);

             Console.WriteLine("******suma celor doua numere******");
             View(GestionareSuma(v1, v2));

             Console.WriteLine("vectorul 1 * vectorul 2 =");
             View(InmultireVectori(v1,v2));*/

            
            Fact();
            

        }

        private static void Fact()
        {
            Console.WriteLine("FACTORIAL");
            Console.WriteLine("Calculam factorialul numarului x.");
            Console.Write("x=");
            x = int.Parse(Console.ReadLine());
            //x = 5000;
            sw.Start();
            View(Factorial(x));
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine($"Runtime " + elapsedTime);
            Console.WriteLine();
        }

        private static int[] Factorial(int n)
        {
            int nrZerouriLaFinal=0,index;

            int[] fact = { 1 };
            int[] vidx;
            for (int i = 1; i <= n ; i++)
            {
                //Console.WriteLine(i);
                index = i;
                if (i%10==0)
                {
                    nrZerouriLaFinal++;
                    index /= 10;
                    if (i%100==0)
                    {
                        nrZerouriLaFinal++;
                        index /= 10;
                        if (i%1000==0)
                        {
                            nrZerouriLaFinal++;
                            index /= 10;
                        } 
                    }
                }
                vidx = MakeVectorFromIndex(index);
                fact = InmultireVectori(fact, vidx);

            }
            fact = AdaugaZero(fact, nrZerouriLaFinal);
            Console.Write($"{x}! = ");
            return fact;
        }

        private static int[] MakeVectorFromIndex(int index)
        {
            int lenght = 0;
            int aux = index;
            int[] vtemp;
            while (aux != 0)
            {
                lenght++;
                aux /= 10;
            }
            vtemp = new int[lenght];
            while (index != 0)
            {
                vtemp[--lenght] = index % 10;
                index /= 10;
            }
            
            return vtemp;
        }

        private static int[] InmultireVectori(int[] v1, int[] v2)
        {
            int j = 1, scalar = v2[v2.Length - 1];
            int[] vSum = InmultireCuScalar(v1, scalar ); 
            for (int i = v2.Length - 2; i >= 0; i--)
            {
                scalar = v2[i]; 
                
                vSum = GestionareSuma(vSum , AdaugaZero(InmultireCuScalar(v1, scalar) , j));
                j++;
            }
            return vSum;
        }

        private static int[] AdaugaZero(int[] v1, int nrZerouri)
        {
            int[] vtemp = new int[v1.Length + nrZerouri];
            for (int i = 0; i < vtemp.Length; i++)
            {
                if (i < v1.Length)
                {
                    vtemp[i] = v1[i];
                }
                else
                {
                    vtemp[i] = 0;
                }
            }
            return vtemp;
        }

        private static int[] InmultireCuScalar(int[] v1, int scalar)
        {
            int[] v;
            if (scalar!=0)
            {
                v = v1;
                for (int i = 1; i < scalar; i++)
                {
                    v = Suma(v, v1);
                }
            }
            else
            {
                v = new int[1];
                v[0] = 0;
            }
            return v;
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
            int max, min, sum, k;
            max = v1.Length;
            min = v2.Length;
            k = min;//contorul pentru v2
            int[] v = new int[max + 1];
            int[] vtemp = new int[max];
            int trans = 0;
            for (int i = max - 1; i >= 0; i--)
            {
                k--;
                sum = v1[i];
                if (k >= 0)
                    sum += v2[k];      //adaugam elementele vectorului pana cand avem ce adauga :) (Exclude overflow)
                sum += trans;          //adaugam transportul acumulat din pozitia anterioara
                v[i + 1] = sum;        //punem suma elementelor in vectorul final
                trans = v[i + 1] / 10; //transportul va fi intotdeauna egal cu cifra zecilor
                v[i + 1] %= 10;        //eliminam valoarea transportul din pozitia curenta a vetorului
            }
            v[0] = trans;              //adaugam ultimul transport, daca este 
            if (v[0]==0)
            {
                for (int i = 1; i < v.Length; i++)
                {
                    vtemp[i - 1] = v[i];
                }
                v = vtemp;
            }
            return v;
        }

        private static void GetData()
        {
            line = Console.ReadLine();
            n = line.Length;
        }

        private static void View(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write($"{v[i]}");
            }
            Console.WriteLine("");
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
