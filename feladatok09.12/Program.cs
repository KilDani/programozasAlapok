using System;

namespace feladatok09._12
{
    internal class Program
    {
        static void F1()
        {
            Console.WriteLine("Hello world!");
        }
        static void F2() 
        {
            Console.Write("Ird be a neved: ");
            string nev = Console.ReadLine()!;

            Console.WriteLine($"Szia {nev}");
        }

        static void F3() 
        {
            Console.Write("Irj be egy számot: ");
            int? number = null;

            do
            {
                try
                {
                    number = int.Parse(Console.ReadLine()!);
                    Console.WriteLine($"A megadott szám kétszerese:{number * (long)2}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("A megadott érték nem alakítható át számmá");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {int.MinValue} és {int.MaxValue} közti értéknek kell lennie, add meg újra: ");
                }
            }
            while (number is null);
        }

        static void F4()
        {
            int? szam1 = null;
            int? szam2 = null;

            while(szam1 is null || szam2 is null)
            {
                try
                {
                    Console.Write("Adj meg egy számot: ");
                    szam1 = int.Parse(Console.ReadLine()!);
                    Console.Write("Adj meg egy másik számot: ");
                    szam2 = int.Parse(Console.ReadLine()!);

                    Console.WriteLine($"összegük:{szam1 + szam2}");
                    Console.WriteLine($"különbségük:{szam1 - szam2}");
                    Console.WriteLine($"szorzatuk:{szam1 * szam2}");
                    Console.WriteLine($"hányadosa:{szam1 / szam2}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("A megadott érték nem alakítható át számmá");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {int.MinValue} és {int.MaxValue} közti értéknek kell lennie, add meg újra: ");
                }
            }

            
        }

        static void F5()
        {
            int? szam1 = null;
            int? szam2 = null;

            while (szam1 is null || szam2 is null)
            {
                try
                {
                    Console.Write("Adj meg egy számot: ");
                    szam1 = int.Parse(Console.ReadLine()!);
                    Console.Write("Adj meg egy másik számot: ");
                    szam2 = int.Parse(Console.ReadLine()!);

                    if (szam1 > szam2)
                    {
                        Console.WriteLine($"A nagyobb szám: {szam1}");
                    }
                    else if (szam1 < szam2)
                    {
                        Console.WriteLine($"A nagyobb szám: {szam2}");
                    }
                    else
                    {
                        Console.WriteLine("Egyenlő");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("A megadott érték nem alakítható át számmá");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {int.MinValue} és {int.MaxValue} közti értéknek kell lennie, add meg újra: ");
                }
            }
                
        }

        static void F6() 
        {
            int? szam1 = null;
            int? szam2 = null;
            int? szam3 = null;

            while (szam1 is null || szam2 is null || szam3 is null)
            {
                try
                {
                    Console.Write("Adj meg egy számot: ");
                    szam1 = int.Parse(Console.ReadLine()!);
                    Console.Write("Adj meg egy másik számot: ");
                    szam2 = int.Parse(Console.ReadLine()!);
                    Console.Write("Adj meg egy harmadik számot: ");
                    szam3 = int.Parse(Console.ReadLine()!);

                    int?[] tomb = { szam1, szam2, szam3 };

                    Console.WriteLine(tomb.Min());
                }
                catch (FormatException)
                {
                    Console.WriteLine("A megadott érték nem alakítható át számmá");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {int.MinValue} és {int.MaxValue} közti értéknek kell lennie, add meg újra: ");
                }
            }
        }

        static void F7()
        {
            int? a = null;
            int? b = null;
            int? c = null;

            while(a is null || b is null || c is null)
            {
                try {
                    Console.Write("Adj meg egy számot: ");
                    a = int.Parse(Console.ReadLine()!);
                    Console.Write("Adj meg egy másik számot: ");
                    b = int.Parse(Console.ReadLine()!);
                    Console.Write("Adj meg egy harmadik számot: ");
                    c = int.Parse(Console.ReadLine()!);

                    if (a < b + c && b < a + c && c < a + b)
                    {
                        Console.WriteLine("A háromszög szerkezthető");
                    }
                    else
                    {
                        Console.WriteLine("A háromszög nem szerkezthető");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("A megadott érték nem alakítható át számmá");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {int.MinValue} és {int.MaxValue} közti értéknek kell lennie, add meg újra: ");
                }
            }
            
        }

        static void F8()
        {
            try
            {
                Console.Write("Adj meg egy számot: ");
                int a = int.Parse(Console.ReadLine()!);
                Console.Write("Adj meg egy másik számot: ");
                int b = int.Parse(Console.ReadLine()!);

                Console.WriteLine($"Számtani közepe: {(a + b) / 2}");
                Console.WriteLine($"Mértani közepe: {Math.Sqrt(a * b)}");
            }
            catch (FormatException)
            {
                Console.WriteLine("A megadott érték nem alakítható át számmá");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"A megadott számnak {int.MinValue} és {int.MaxValue} közti értéknek kell lennie, add meg újra: ");
            }
        }

        static void F9()
        {
            try
            {
                Console.Write("Adj meg egy számot: ");
                double a = double.Parse(Console.ReadLine()!);
                Console.Write("Adj meg egy másik számot: ");
                double b = double.Parse(Console.ReadLine()!);
                Console.Write("Adj meg egy harmadik számot: ");
                double c = double.Parse(Console.ReadLine()!);

                double eredmeny = Math.Sqrt(b * b - (4 * a * c));

                if (eredmeny > 0)
                {
                    Console.WriteLine("Van megoldás");
                }
                else
                {
                    Console.WriteLine("Nincs megoldás");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("A megadott érték nem alakítható át számmá");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Hiba");
            }
        }

        static void F10()
        {
            try
            {
                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine()!);
                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine()!);
                Console.Write("c = ");
                double c = double.Parse(Console.ReadLine()!);

                double megoldhato = Math.Sqrt((b * b) - (4 * a * c));
                double eredmeny1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                double eredmeny2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

                if (megoldhato > 0)
                {
                    Console.WriteLine($"x1: {eredmeny1}");
                    Console.WriteLine($"x2: {eredmeny2}");
                }
                else
                {
                    Console.WriteLine("Nincs megoldás");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("A megadott érték nem alakítható át számmá");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Hiba");
            }
        }

        static void F11()
        {
            try
            {
                Console.Write("Add meg az egyik befogót: ");
                double a = double.Parse(Console.ReadLine()!);
                Console.Write("Add meg a másik befogót: ");
                double b = double.Parse(Console.ReadLine()!);

                double c = Math.Sqrt((b * b) + (a * a));

                Console.WriteLine($"{c:f2}");
            }
            catch (FormatException)
            {
                Console.WriteLine("A megadott érték nem alakítható át számmá");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Hiba");
            }
        }

        static void F12()
        {
            try
            {
                Console.Write("Add meg az x tengelyt: ");
                int x = int.Parse(Console.ReadLine()!);
                Console.Write("Add meg az y tengelyt: ");
                int y = int.Parse(Console.ReadLine()!);
                Console.Write("Add meg a z tengelyt: ");
                int z = int.Parse(Console.ReadLine()!);

                int felszin = 2 * (x * y + y * z + z * x);
                int terfogat = x * y * z;

                Console.WriteLine($"Felszín: {felszin} \nTérfogat: {terfogat}");
            }
            catch (FormatException)
            {
                Console.WriteLine("A megadott érték nem alakítható át számmá");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"A megadott számnak {int.MinValue} és {int.MaxValue} közti értéknek kell lennie, add meg újra: ");
            }
        }

        static void F13()
        {
            try
            {
                Console.Write("Add meg a kör átmérőjét: ");
                int atmero = int.Parse(Console.ReadLine()!);

                double kerulet = atmero * Math.PI;
                double sugar = atmero / 2.0;
                double terulet = Math.PI * (sugar * sugar);

                Console.WriteLine($"Kerülete: {kerulet} \nTerület: {terulet}");
            }
            catch (FormatException)
            {
                Console.WriteLine("A megadott érték nem alakítható át számmá");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Hiba");
            }
        }

        static void F14() 
        {
            try
            {
                Console.Write("Add meg a körív sugarát: ");
                double sugar = double.Parse(Console.ReadLine()!);
                Console.Write("Add meg a körív középponti szögét: ");
                double kozepSzog = double.Parse(Console.ReadLine()!);

                double hossz = (kozepSzog / 360) * 2 * sugar * Math.PI;
                double terulet = (kozepSzog / 360) * sugar * sugar * Math.PI;
                Console.WriteLine($"hossza: {hossz}");
                Console.WriteLine($"területe: {terulet}");
            }
            catch (FormatException)
            {
                Console.WriteLine("A megadott érték nem alakítható át számmá");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Hiba");
            }

        }

        static void Main(string[] args)
        {

        }
    }
}