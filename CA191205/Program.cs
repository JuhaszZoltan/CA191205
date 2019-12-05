using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CA191205
{
    class Program
    {
        static Random rnd = new Random();
        static int[] tomb = new int[100];
        static string szo = "INFORMATIKA";
        static int[] t2 = new int[10];
        static void Main()
        {
            //Feltolt();
            //Kiir();
            //KetszazCsillag();
            //RandomJelszo();
            //TombKever();
            //T2Set();
            //Intervallum();

            //------------------

            //OsztalyzoTeszt();
            //KerTer(10, 20);
            //HaromszogTeszt();
            PermutacioTeszt();

            Console.ReadKey();
        }
        #region Paraméter nélküli eljárások
        static void Feltolt()
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(10, 100);
            }
        }
        static void Kiir()
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.Write($"{tomb[i]} ");
                if ((i + 1) % 10 == 0) Console.Write("\n");
            }
        }
        static void RandomHelyreIr()
        {
            Console.CursorVisible = false;

            Console.SetCursorPosition(
                rnd.Next(Console.WindowWidth),
                rnd.Next(Console.WindowHeight));
            Console.Write('*');
        }
        static void RandomSzin()
        {
            Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 16);
        }
        static void KetszazCsillag()
        {
            for (int i = 0; i < 200; i++)
            {
                RandomSzin();
                RandomHelyreIr();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 10);
        }
        static void RandomChar()
        {
            Console.Write((char)rnd.Next(65, 91));
        }
        static void RandomJelszo()
        {
            Console.Write("\n");
            for (int i = 0; i < 6; i++)
            {
                RandomChar();
            }
            Console.Write("\n");
        }
        static void TombKever()
        {
            Console.Write("\n");
            char[] ct = szo.ToArray();
            for (int i = 0; i < ct.Length; i++)
            {
                int x = rnd.Next(ct.Length);
                int y = rnd.Next(ct.Length);

                char cs = ct[x];
                ct[x] = ct[y];
                ct[y] = cs;
            }
            Console.WriteLine(new string(ct));
        }
        static void T2Set()
        {
            Console.Write("\nt2 elemei: ");
            for (int i = 0; i < t2.Length; i++)
            {
                t2[i] = rnd.Next(500);
                Console.Write($"{t2[i]}, ");
            }
            Console.Write("\n");
        }
        static void Intervallum()
        {
            int mini = 0;
            int maxi = 0;

            for (int i = 1; i < t2.Length; i++)
            {
                if (t2[mini] > t2[i]) mini = i;
                if (t2[maxi] < t2[i]) maxi = i;
            }

            Console.WriteLine($"A tömb elemei a [{t2[mini]};{t2[maxi]}] intervallumból vannak.");
        }
        #endregion

        static string Osztalyoz01(int x)
        {
            if (x == 1) return "elégtelen";
            if (x == 2) return "elégséges";
            if (x == 3) return "közepes";
            if (x == 4) return "jó";
            return "jeles";
        }
        static string Osztalyzo02(int szam)
        {
            switch (szam)
            {
                case 1: return "elégtelen";
                case 2: return "elégséges";
                case 3: return "közepes";
                case 4: return "jó";
                case 5: return "jeles";
                default: return "HIBA";
            }
        }
        static void OsztalyzoTeszt()
        {
            Console.WriteLine("Hányas lett a dolgozat? ");
            int jegy = int.Parse(Console.ReadLine());

            string ertekeles = Osztalyoz01(jegy);
            Console.WriteLine($"értékelés: {ertekeles}");
        }

        static void KerTer(int a, int b)
        {
            Console.WriteLine($"Téglaklap kerülete: {(a + b) * 2} cm");
            Console.WriteLine($"Téglalap területe: {a * b} cm^2");
        }
        static bool HaromszogE(int a, int b, int c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
        static void HaromszogTeszt()
        {
            Console.WriteLine("3szög-e?");
            for (int i = 0; i < 10; i++)
            {
                int a = rnd.Next(20);
                int b = rnd.Next(20);
                int c = rnd.Next(20);
                Console.Write("[{0,2} - {1,2} - {2,2}]: ", a, b, c);
                if (HaromszogE(a, b, c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("IGEN");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NEM");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static int[] PermutacioN(int n)
        {
            int[] t = new int[n];

            for (int i = 0; i < t.Length; i++)
            {
                t[i] = i + 1;
            }

            for (int i = 0; i < t.Length; i++)
            {
                int x = rnd.Next(t.Length);
                int y = rnd.Next(t.Length);

                int cs = t[x];
                t[x] = t[y];
                t[y] = cs;
            }

            return t;
        }

        static void PermutacioTeszt()
        {
            Console.Write("Írd be az n-t: ");
            int x = int.Parse(Console.ReadLine());

            int[] t = PermutacioN(x);

            Console.WriteLine($"1...{x} sorozat egy permutációja: ");
            for (int i = 0; i < t.Length; i++)
            {
                Console.Write($"{t[i]} ");
            }
        }
    }
}
