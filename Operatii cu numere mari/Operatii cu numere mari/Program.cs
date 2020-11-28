using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Program
    {
        static int[] v1,v2;
        static char operation;
        static int n;
        static string line;

        static void Main(string[] args)
        {
            GetData();
            MakeVector(ref v1, n);
            
            GetData();
            MakeVector(ref v2, n);

            Console.WriteLine("******suma celor doua numere******");
            View(GestionareSuma(v1, v2));
            /*Console.WriteLine("Cu cat sa fie inmultit numarul 1.? x=");
            View(InmultireCuScalar(v1,int.Parse(Console.ReadLine())));*/
            Console.WriteLine("vectorul 1 * vectorul 2 =");
            View(InmultireVectori(v1,v2));


        }

        private static int[] InmultireVectori(int[] v1, int[] v2)
        {
            int j = 1, scalar = v2[v2.Length - 1];
            int[] vSum = InmultireCuScalar(v1, scalar ); 
            for (int i = v2.Length - 2; i >= 0; i--)
            {
                scalar = v2[i] * (int)Math.Pow(10, j); //AICI TREBUIE MODIFICAT!!
                vSum = GestionareSuma(vSum , InmultireCuScalar(v1, scalar));
                j++;
            }
            return vSum;
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

        private static void in10(int[] v, int n)
        {
            for (int i = 0; i < v.Length; i++)
            {

            }
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
