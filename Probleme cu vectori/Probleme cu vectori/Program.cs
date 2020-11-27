using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Probleme_cu_vectori
{
    class Program
    {
        static void Main(string[] args)
        {
            //IndiceMaxSiMin();
            //SumaElemente();
            //MaiMareDecatMa();
            //InafaraIntervalului();

            //Problema_Incepatori1();
            //Problema_Incepatori2();

            //Stergere_Element();
            //StergereNrPrim();
            //StergereNrPar();
            //ElimRep();
            //Inserare();
            //InserareDupa();
            //InserareInainte();
            //Inserare_AceeasiParitate();
            //Inserare_AceeasiParitate2();
            //PermCirc();
            GigelElimRep();

            for (int i = 0; i < 31; i++)
            {
                Console.WriteLine();
            }
            
           
        }

        /// <summary>
        /// Gigel a găsit un șir cu n numere naturale. 
        /// În fiecare zi Gigel parcurge șirul 
        /// și când găsește o pereche de elemente consecutive egale
        /// o elimină din șir și se oprește.
        /// Determinați în câte zile va elimina Gigel
        /// elemente din șir și care sunt valorile din șir după eliminări.
        /// </summary>
        private static void GigelElimRep()
        {
            (int n, int[] v) = GetVector();
            int[] u = new int[n];
            int z = 0;
            bool repeat = true; 
            while (repeat) 
            {
                repeat = false;
                bool stop = false;
                int k = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!stop && v[i] == v[i + 1])
                    {
                        stop = true;
                        if (i + 2 < n) i += 2;
                        else break;
                    }
                    u[k] = v[i];
                    k++;
                }
                v = u;
                n = k;
                for (int i = 0; i < n; i++)
                {
                    if ( v[i] == v[i + 1])
                        repeat = true;
                }
                z++;
            }
            Console.WriteLine(z);
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Determinați toate permutările circulare
        /// spre stânga ale unui vector dat.
        /// </summary>
        private static void PermCirc()
        {
            (int n, int[] v) = GetVector();
            
            int x = 0;
            do
            {
                int k = v[0], i;
                for (i = 1; i < n; i++)
                {
                    v[i - 1] = v[i];
                }
                v[n - 1] = k;
                for (i = 0; i < n; i++)
                {
                    Console.Write($"{v[i]} ");
                }
                Console.WriteLine();
                x++;
            } while (x < n-1);
        }
        /// <summary>
        /// Se dau n numere întregi. Să se insereze
        /// între oricare două numere de aceeași paritate media lor aritmetică. 
        /// Să se realizeze acest procedeu
        /// până nu se mai pot adăuga noi elemente.
        /// </summary>
        private static void Inserare_AceeasiParitate2()
        {
            (int n, int[] v) = GetVector();
            bool ok = false;
            do
            {
                int[] u = new int[n * 2];
                u[0] = v[0];
                int k = 1, i;
                for (i = 1; i < n; i++)
                {
                    if (v[i - 1] != v[i])
                        if (v[i - 1] % 2 == v[i] % 2)
                        {
                            u[k] = (v[i - 1] + v[i]) / 2;
                            k++;
                        }
                    u[k] = v[i];  k++;
                }
                Console.WriteLine();
                n = k;  v = u; ok = false;
                for (i = 0; i < n; i++)
                {
                    Console.Write($"{v[i]} ");
                    if (i != 0)
                        if (v[i - 1] % 2 == v[i] % 2 && v[i - 1] != v[i]) ok = true;
                }
                Console.WriteLine();
            } while (ok);
        }
        /// <summary>
        /// Se dau n numere întregi. Să se insereze 
        /// între oricare două numere de aceeași paritate
        /// media lor aritmetică.
        /// </summary>
        private static void Inserare_AceeasiParitate()
        {
            (int n, int[] v) = GetVector();

            int[] u = new int[n * 2];
            u[0] = v[0];
            int k = 1, i;
            for (i = 1; i < n; i++)
            {
                
                if (v[i - 1] % 2 == v[i] % 2)
                {
                    u[k] = (v[i - 1] + v[i] ) / 2;
                    k++;
                }
                u[k] = v[i];
                k++;

            }
            Console.WriteLine();
            v = u;
            for (i = 0; i < k; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Să se insereze într-un șir 
        /// înaintea fiecărui element pătrat perfect rădăcina sa pătrată.
        /// </summary>
        private static void InserareInainte()
        {
            (int n, int[] v) = GetVector();
            int[] u = new int[n * 2];
            int k = 0, i;
            for (i = 0; i < n; i++)
            {
                if (PatratPerfect(v[i]))
                {
                    u[k] = (int)Math.Sqrt(v[i]);
                    k++;
                }
                u[k] = v[i];
                k++;
            }
            Console.WriteLine();
            v = u;
            for (i = 0; i < k; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }

        private static bool PatratPerfect(int x)
        {
            for (int j = 2; j < x; j++)
            {
                if (j * j == x)return true;
            }
            return false;
        }
        /// <summary>
        /// Să se insereze într-un șir după fiecare element par dublul său.
        /// </summary>
        private static void InserareDupa()
        {
            (int n, int[] v) = GetVector();

            int[] u = new int[n * 2];

            int k = 0,i;
            for (i = 0; i < n; i++)
            {
                u[k] = v[i];
                k++;
                if (v[i]%2==0)
                {
                    u[k] = v[i]*2;
                    k++;
                }
            }
            Console.WriteLine();
            v = u;
            for (i = 0; i < k; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Să se insereze pe o poziție dată într-un șir o valoare precizată.
        /// </summary>
        private static void Inserare()
        {
            (int n, int[] v) = GetVector();
            Console.Write("Inseram un nr k pe pozitia k. k=");
            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                if (i==k-1)
                {
                    n++;
                    for (int j = n - 1; j > i; j--)
                    {
                        v[j] = v[j-1];
                    }
                    v[k-1] = k;
                }
            }
            for (int i = 0; i < n; i++)
                Console.Write($"{v[i]} ");
            
            Console.WriteLine();
        }
        /// <summary>
        /// Se citește un șir cu n elemente, numere întregi.
        /// Să se șteargă elementele care se repetă, 
        /// păstrându-se doar primul de la stânga la dreapta.
        /// </summary>
        private static void ElimRep()
        {
            (int n, int[] v) = GetVector();
            int[] u = new int[n];
            int k = 0;
            u[0] = v[0];
            for (int i = 0; i < n; i++)
            {
                bool ok = true;
                for (int j = 0; j < k; j++)
                {
                    if (v[i] == u[j])
                        ok = false;
                }
                if (ok)
                {
                    u[k] = v[i];
                    k++;
                }
            }
            v = u;
            for (int i = 0; i < k; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }

        private static bool SeRepeta(int[] v, int a, int n, int j)
        {
            for (int i = j + 1 ; i < n; i++)
            {
                if (v[i]==a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Să se șteargă dintr-un vector toate elementele pare.
        /// </summary>
        private static void StergereNrPar()
        {
            (int n, int[] v) = GetVector();

            for (int i = 0; i <= n; i++)
            {
                do
                {
                    if (v[i]%2==0)
                    {
                        for (int j = i; j < n - 1; j++)
                        {
                            v[j] = v[j + 1];
                        }
                        n--;
                    }
                } while (v[i] % 2==0 && n != i);
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Să se șteargă dintr-un vector toate elementele
        /// care sunt numere prime.
        /// </summary>
        private static void StergereNrPrim()
        {
            (int n, int[] v) = GetVector();
            
            for (int i = 0; i <= n; i++)
            {
                do
                {
                    if (Prim(v[i]))
                    {
                        for (int j = i; j < n - 1; j++)
                        {
                            v[j] = v[j + 1];
                        }
                        n--;
                    }
                } while (Prim(v[i]) && n!=i);
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Să se șteargă dintr-un șir elementul aflat pe o poziție dată.
        /// </summary>
        private static void Stergere_Element()
        {
            (int n, int[] v) = GetVector();//folosire Tuple
            int idx;
            Console.Write("Sa fie sters elementul de la pozitia:");
            idx = int.Parse(Console.ReadLine());
            //idx++;
            for (int i = idx; i < n; i++)
            {
                v[i - 1] = v[i];
            }
            n--;
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} "); 
            }
            Console.WriteLine();
        }

        private static (int n,int[] v) GetVector()
        {
            int n, i;
            n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            //adaugare un spatiu liber in memorie
            //pentru numarul inserat
            
            
            for (i = 0; i < n; i++)
            {
                Console.Write($"v[{i}]=");
                v[i] = int.Parse(Console.ReadLine());
            }

            for (i = 0; i < n; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
            return (n, v);

        }

        private static void Problema_Incepatori2()
        {
            
        }

        /// <summary>
        /// se da un vector si se cere inserarea dupa fiecare valoare prima, suma cifrelor acesteia
        /// IN: 1 12 31 45 51 6
        /// OUT: 1 12 31 4 45 51 6 6
        /// </summary>
        private static void Problema_Incepatori1()
        {
            int n, i;
            n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            int[] u = new int[2*n];
            for (i = 0; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
            }
            int k = 0;
            for (i = 0; i < n; i++)
            {

                u[k] = v[i];
                k++;
                if (Prim(v[i]))
                {
                    u[k] = SumaCifre(v[i]);
                    k++;
                }
                
               
            }
            Console.WriteLine();

            for (i = 0; i < 2 * n ; i++)
            {
                Console.Write($"{u[i]} ");
            }
            Console.WriteLine();
        }

        private static int SumaCifre(int n)
        {
            int s = 0;
            while (n!=0)
            {
                s += n % 10;
                n /= 10;
            }
            return s;
        }

        private static bool Prim(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (int i = 3; i * i <= n; i+=2)
            {
                if (n%i==0)
                    return false;
            }
            return true;
        }

        private static void InafaraIntervalului()
        {
            
        }

        private static void MaiMareDecatMa()
        {
            int n, i, s = 0;
            double ma;
            n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            for (i = 0; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
                s += v[i];
            }
            ma = s / v.Length;
            s = 0;
            foreach (int k in v)
            {
                if (k>ma)
                {
                    s++;
                }
            }
            Console.WriteLine(s); 
        }

        private static void SumaElemente()
        {
            int n, i, s=0,poz1=0,poz2=0;
            n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            for (i = 0; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
            }

            for (i = 0; i < n; i++)
            {
                if (v[i] % 2 == 0) { poz1 = i;break; }
                
            }
            for (i = n-1; i > 0; i--)
            {
                if (v[i] % 2 == 0) { poz2 = i; break; }
            }
            
            for (i = poz1; i <= poz2; i++)
            {
                s += v[i];
            }

            Console.WriteLine($"Suma valorilor elementelor cuprinse între primul si ultimul element par al vectorului: {s} ");
        }

        private static void IndiceMaxSiMin()
        {
            int n, i, minIndex, maxIndex;
            n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            for ( i = 0; i < n; i++)
            {
                v[i] = int.Parse(Console.ReadLine());
            }

            for (i = 0; i < n; i++)
            {
                Console.Write($"{v[i]}  ");  
            }
            minIndex = 0;
            maxIndex = 0;
            for (i = 1; i < n; i++)
            {
                if (v[minIndex] > v[i]) minIndex = i;
                if (v[maxIndex] < v[i]) maxIndex = i;
            }
            Console.WriteLine($"indicele maximului: {maxIndex} si cel al minimului: {minIndex}");
        }
    }
}
