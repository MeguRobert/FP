using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Operatii_cu_numere_mari
{
    class Program
    {
        static int[] v1,v2,v;
        static char operation;
        static int n,x,rest,nrZecimale;
        static string bigNumber;
        static Stopwatch sw = new Stopwatch();
        private static bool rIsgreater;
        private static int[] vrest;

        static void Main(string[] args)
        {
            Write();
            Console.Write("Primul numar: ");
            bigNumber = ValidInput();
            v1 = MakeVectorFrom(bigNumber);
            Console.Write("Operatia care doresti sa fie executat: ");
            operation = char.Parse(Console.ReadLine());
            Switch(operation);
            Console.WriteLine();
        }

        private static void Switch(char operation)
        {
            if (operation == 'f')
            {
                Fact();
            }
            else if (operation == 'r')
            {
                SquareRoot();
            }
            else
            {
                Console.Write("Al doilea numar: ");
                bigNumber = ValidInput();
                v2 = MakeVectorFrom(bigNumber);
                switch (operation)
                {
                    case '+':
                        Addition();
                        break;
                    case '-':
                        Subtraction();
                        break;
                    case '*':
                        Multiplication();
                        break;
                    case '/':
                        Division();
                        break;
                    case 'p':
                        Power();
                        break;
                    default:

                        break;
                }
            }
            
        }

        private static void SquareRoot()
        {
            Console.WriteLine("****** Radacina patrata al numarului ******");
            
        }

        private static void Power()
        {
            Console.WriteLine("****** Puterea celor doua numere ******");
            View(Putere(v1, v2));
        }

        private static void Division()
        {
            Console.WriteLine("Cu ce aproximare sa fie calculata impartirea?");
            Console.Write("Numarul maxim a zecimalelor:");
            nrZecimale = int.Parse(Console.ReadLine());
            Console.WriteLine("****** Catul impartiri ******");
            
            v = Impartire(v1, v2);
            View(v);
            if (rest!=0 && nrZecimale!=0)
            {
                Console.Write(".");
                v=Decimal(MakeVectorFrom(rest),x);
                View(v);
            }
        }

        private static int[] Impartire(int[] v1, int[] v2)
        {
            int len1 = v1.Length;
            int len2 = v2.Length;
            int[] v;
            int[] vtemp;
            if ( v1[0]!= 0)
            {
                v = new int[len1];
                int s;
                int[] r = new int[len1];

                int j = 0;

                for (int i = 0; i < v1.Length; i++)
                {
                    s = 0;
                    r = GestionareSuma(r, v1);

                    while (Isgreater(r,v2))
                    {
                        r = Diferenta(r,v2);
                        s++;
                    }
                    if (v[0]==0)
                    {
                        v = GestionareSuma(v, MakeVectorFrom(s));
                    }
                    else
                    {
                        v = GestionareSuma(AdaugaZero(v, 1), MakeVectorFrom(s));
                    }
                    
                    j++;

                    if (i==v1.Length-1)
                    {
                        vrest = r;
                    }
                    r = AdaugaZero(r,1);
                }
                
            }
            else
            {
                v = null;
                Console.WriteLine("Nu putem divide cu zero");
            }

            return v;
        }

        private static bool Isgreater(int[] v1, int[] v2)
        {
            for (int i = 0; i < v2.Length; i++)
            {
                if (v1[i] >= v2[i])
                {
                    return true;
                }
            }
            return false;
        }

        private static int[] Decimal(int[] v1, int n)
        {
            int lenght = v1.Length;
            int[] v = new int[nrZecimale];
            int[] vtemp = new int[nrZecimale];
            int s;
            int r = 0;
            int j = 0;

            int i = 0;
            while (i < nrZecimale + lenght)
            {
                s = 0;
                if (i<v1.Length)
                {
                    r += v1[i];
                }
                if (r >= n)
                {
                    while (r >= n)
                    {
                        r -= n; s++;
                    }
                    v[j] = s; j++;
                }
                else if (r == 0)
                {
                    while (vtemp[nrZecimale - 1]==0)
                    {
                        vtemp = new int[--nrZecimale];
                        for (int idx = 0; idx < vtemp.Length; idx++)
                        {
                            vtemp[idx] = v[idx];
                        }
                        v = vtemp;
                    }

                    break;
                }
                r *= 10;
                i++;
            }

            return v;
        }
       
        private static void Multiplication()
        {
            Console.WriteLine("****** Produsul celor doua numere ******");
            View(InmultireVectori(v1, v2));
        }

        private static void Subtraction()
        {
            Console.WriteLine("****** Diferenta celor doua numere ******");
            View(GestionareDiferenta(v1, v2));
        }

        private static void Addition()
        {
            Console.WriteLine("****** suma celor doua numere ******");
            View(GestionareSuma(v1, v2));
        }

        private static void Write()
        {
            Console.WriteLine("Acesta este un program care poate efectua operatii cu numere mari.");
            Console.WriteLine("Operatiile valide sunt:");
            Console.WriteLine("+   adaugare");
            Console.WriteLine("-   scadere                (Almost works)");
            Console.WriteLine("*   inmultire ");
            Console.WriteLine("/   impartie               (Coming soon)");
            Console.WriteLine("p   ridicare la putere");
            Console.WriteLine("r   radacina patrata       (Coming soon) ");
            Console.WriteLine("f   factorial");
        }

        private static string ValidInput()
        {
            string onlyNumbers = @"^\d+$";
            string line;
            Match result;
            do
            {
                line = Console.ReadLine();
                result = Regex.Match(line, onlyNumbers);
            } while (!result.Success);
            return result.Value;
        }

        private static void Fact()
        {
            Console.WriteLine("\n FACTORIAL");
            x = int.Parse(bigNumber);
            sw.Start();
            View(Factorial(x));
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine();
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
                vidx = MakeVectorFrom(index);
                fact = InmultireVectori(fact, vidx);

            }
            fact = AdaugaZero(fact, nrZerouriLaFinal);
            Console.Write($"{x}! = ");
            return fact;
        }

        private static int[] MakeVectorFrom(int num)
        {
            int lenght = 0;
            int aux = num;
            int[] vtemp;
            while (aux != 0)
            {
                lenght++;
                aux /= 10;
            }
            vtemp = new int[lenght];
            while (num != 0)
            {
                vtemp[--lenght] = num % 10;
                num /= 10;
            }
            
            return vtemp;
        }

        private static int[] Putere(int[] v1, int[] v2)
        {
            int[] vPutere = PutereScalar(v1, v2[v2.Length-1]);
            int scalar, j = 1;
            
            for (int i = v2.Length - 2; i >= 0; i--)
            {
                scalar = v2[i];
                vPutere = InmultireVectori(vPutere, PutereScalar(v1, scalar * (int)Math.Pow(10,j)));
                j++;
            }
            return vPutere;
        }

        private static int[] PutereScalar(int[] v1, int n)
        {
            int[] putere;
            if (n==0)
            {
                putere = new int[1];
                putere[0] = 1;
            }
            else
            {
                putere = v1;
            }
            
            for (int i = 2; i <= n; i++)
            {
                putere = InmultireVectori(putere, v1);
            }
            return putere;
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

        private static int[] ImpartireScalar(int[] v1, int n)
        {
            int lenght=v1.Length;
            int[] v;
            int[] vtemp;
            if (n != 0)
            {
                v = new int[lenght];
                int s = 0;
                int r = 0;
                int j = 0;
                
                for (int i = 0; i < v1.Length; i++)
                {
                    s = 0;
                    r += v1[i];
                    if (r >= n)
                    {
                        while (r>=n)
                        {
                            r -= n; s++;
                        }
                        v[j] = s;  j++;
                    }
                    else if (r==0)
                    {
                        v[j] = 0;  j++;
                    }
                    else
                    {
                        if (i+1!=v1.Length)
                        {
                            vtemp = new int[--lenght];
                            for (int idx = 0; idx < vtemp.Length; idx++)
                            {
                                vtemp[idx] = v[idx];
                            }
                            v = vtemp;
                        }
                        
                    }
                    r *= 10;
                }
                rest = r/10; 
            }
            else
            {
                v = null;
                Console.WriteLine("Nu putem divide cu zero");
            }

            return v;
            
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

        private static int[] GestionareDiferenta(int[] v1, int[] v2)
        {
            if (v1.Length > v2.Length)
            {
                return Diferenta(v1, v2);
            }
            else if (v1.Length == v2.Length)
            {
                return NumarulMaiMare(ref v1, ref v2);
            }
            else
            {
                return Diferenta(v2, v1);
            }
        }

        private static int[] NumarulMaiMare(ref int[] v1, ref int[] v2)
        {
            
            int i;
            for (i = 0; i < v1.Length; i++)
            {
                if (v1[i]>v2[i])
                {
                    return Diferenta(v1, v2);
                }
                else if (v1[i]<v2[i])
                {
                    int[] aux = v1;
                    v1 = v2;
                    v2 = aux;
                    return Diferenta(v1, v2);
                }
            }
            int[] v = new int[1];
            v[0] = 0;
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
        private static int[] Diferenta(int[] v1, int[] v2)
        {
            int max,min;
            max = v1.Length;
            min = v2.Length;    
            int k;    //contorul pentru v2
            int[] v = new int[max];
            int[] vtemp;

            if (operation=='-')
            {
                k = min;
                for (int i = max - 1; i >= 0; i--)
                {
                    k--;
                    if (k >= 0)
                    {
                        if (v1[i] < v2[k])
                        {
                            v1[i - 1]--;  //imprumut
                            v1[i] += 10;
                        }
                        v[i] = v1[i] - v2[k];
                    }
                    else
                    {
                        v[i] = v1[i];
                    }
                }
            }
            else
            {
                k = 0;
                for (int i = 0; i < min+k; i++)
                {
                    if (v1[i] < v2[i])
                    {
                        v1[i - 1]--;  
                        v1[i] += 10;
                    }
                    if (v1[i] - v2[i]>0)
                    {
                        v[i] = v1[i] - v2[i];
                    }
                    else
                    {
                        k++;
                    } 
                }
            }
           
            /******** eliminarea 0-urilor de la inceputul vectorului ********/
            while (v.Length>1 && v[0]==0)
            {
                vtemp = new int[--max];
                for (int i = 1; i < v.Length; i++)
                {
                    vtemp[i - 1] = v[i];
                }
                v = vtemp;
            }
            return v;
        }
        private static int[] Suma(int[] v1, int[] v2)
        {
            int max, k;
            max = v1.Length;
            k = v2.Length;    //contorul pentru v2
            int[] v = new int[max + 1];
            int[] vtemp = new int[max];
            int trans = 0;
            for (int i = max - 1; i >= 0; i--)
            {
                k--;
                v[i + 1] = trans+v1[i];           //adaugam transportul acumulat din pozitia anterioara 
                                            // si elementele vectorului 2
                if (k >= 0)
                    v[i + 1] += v2[k];      //adaugam elementele vectorului 2 pana cand avem ce adauga :) (Exclude overflow)     
                                       
                trans = v[i + 1] / 10; //transportul va fi intotdeauna egal cu cifra zecilor
                v[i + 1] %= 10;        //eliminam valoarea transportului din pozitia curenta a vetorului
            }
                          
            if (trans==0)
            {
                for (int i = 1; i < v.Length; i++)
                {
                    vtemp[i - 1] = v[i];
                }
                v = vtemp;
                //daca transportul final este 0 trebuie eliminat 0-ul de la inceputul vectorului
                //si lungimea vectorului devine mai mic cu 1 

            }
            else
            {
                v[0] = trans;   //adaugam ultimul transport, daca nu este 0
            }
            return v;
        }

        private static void View(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write($"{v[i]}");
            }
        }

        private static int[] MakeVectorFrom(string bigNumber)
        {
            v = new int[bigNumber.Length];
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = Convert.ToInt32(bigNumber[i]-'0');
            }
            return v;
        }
    }
}
