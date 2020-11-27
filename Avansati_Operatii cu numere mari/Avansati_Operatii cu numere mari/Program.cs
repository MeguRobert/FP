using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdusVectori
{
    class Program
    {
        static int[] in10(int[] v, int n)
        {
            int[] temp = new int[v.Length + n];
            for (int i = 0; i < v.Length; i++)
                temp[i] = v[i];
            return temp;
        }
        static int[] ins(int[] v, int n)
        {
            int[] result;
            int[] nv = new int[v.Length + 1];
            int produs = 0, transport = 0;
            for (int i = v.Length - 1; i >= 0; i--)
            {
                produs = v[i] * n + transport;
                nv[i] = produs % 10;
                if (produs > 9)
                    transport = produs / 10;
                else
                    transport = 0;
            }
            if (transport != 0)
            {
                result = nv;
                result[nv.Length - 1] = transport;
            }
            else
            {
                result = new int[v.Length];
                for (int i = 0; i < result.Length; i++)
                    result[i] = nv[i];
            }
            return result;
        }
        static int[] inv(int[] v, int[] vf)
        {
            int[] rez = new int[1];
            rez[0] = 0;
            
            for (int i = vf.Length - 1; i >= 0; i--)
            {
                rez = suma(rez, in10(ins(v, vf[i]), vf.Length - 1 - i));
            }
            return rez;
        }
        static int[] suma(int[] v, int[] b)
        {
            Array.Reverse(v);
            Array.Reverse(b);
            int[] rez;
            int min, max;
            min = Math.Min(v.Length, b.Length);
            max = Math.Max(v.Length, b.Length);
            int transport = 0;
            int[] temp = new int[max];
            for (int i = 0; i < min; i++)
            {
                int sum = v[i] + b[i] + transport;
                temp[i] = sum % 10;
                if (sum > 9)
                    transport = 1;
                else
                    transport = 0;
            }
            if (v.Length == max)
                for (int i = min; i < max; i++)
                {
                    int sum = v[i] + transport;
                    temp[i] = sum % 10;
                    if (sum > 9)
                        transport = 1;
                    else
                        transport = 0;
                }
            else if (b.Length == max)
                for (int i = min; i < max; i++)
                {
                    int sum = b[i] + transport;
                    temp[i] = sum % 10;
                    if (sum > 9)
                        transport = 1;
                    else
                        transport = 0;
                }
            if (transport == 1)
            {
                rez = new int[max + 1];
                int i;
                for (i = 0; i < max; i++)
                    rez[i] = temp[i];
                rez[max] = transport;
            }
            else
                rez = temp;
            Array.Reverse(v);
            Array.Reverse(b);
            Array.Reverse(rez);
            return rez;

        }
        static int[] transform(int n)
        {
            int k = 0, nCopy = n, i = 0;
            while (nCopy != 0)
            {
                k++;
                nCopy /= 10;
            }
            int[] vector = new int[k];
            while (n != 0)
            {
                vector[i] = n % 10;
                i++;
                n /= 10;
            }
            //Array.Reverse(vector);
            return vector;
        }
        static void factorial()
        {
            int[] v1 = new int[1];
            v1[0] = 1;
            for (int i = 1; i <= 7; i++)
            {
                v1 = inv(v1, transform(i));
                Array.Reverse(v1);
                view(v1);
            }
        }
        static void view(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write($"{v[i]} ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] vector = new int[] { 1, 2, 2, 3, 4, 5, 6, 3, 4, 5 };
            /*Console.WriteLine("vector");
            view(vector);
            int[] rez = in10(vector, 3);
            //view(rez);
            //view(ins(vector, 2));
            int[] test = new int[] { 1, 2, 3, 4 };
            Console.WriteLine("vector test");
            view(test);
            //view(inv(vector, test));
            Console.WriteLine("suma");
            view(suma(vector, test));
            Console.WriteLine("inmult");
            view(inv(vector, test));*/
            Console.WriteLine("factorial de 5000");
            factorial();
        }
    }
}