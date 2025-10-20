using System;

namespace feladatok09._12
{
    internal class Program
    {
        static int askForInt()
        {
            int? number = null;
            do
            {
                try
                {
                    number = int.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {
                    Console.Write("A megadott érték nem alakítható számmá, kérlek add meg újra: ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {int.MinValue} és {int.MaxValue} között kell lennie, kérlek próbáld újra: ");
                }
            }
            while (number is null);

            return number.Value;
        }

        static double askForDouble()
        {
            double? number = null;
            do
            {
                try
                {
                    number = double.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {
                    Console.Write("A megadott érték nem alakítható számmá, kérlek add meg újra: ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {double.MinValue} és {double.MaxValue} között kell lennie, kérlek próbáld újra: ");
                }
            }
            while (number is null);

            return number.Value;
        }
        static string askForString()
        {
            string? input = null;
            do
            {
                try
                {
                    input = Console.ReadLine()!;
                }
                catch (Exception)
                {
                    Console.WriteLine("Próbáld újra:");
                }

            }
            while (input is null);
            return input;
        }

        static void F1()
        {
            Console.WriteLine("Hello world!");
        }
        static void F2()
        {
            Console.Write("Ird be a neved: ");
            string nev = Console.ReadLine()!;

            Console.WriteLine($"Szia {nev}!");
        }

        static void F3()
        {
            Console.Write("Írj be egy számot: ");
            int number = askForInt();
            Console.WriteLine($"A megadott szám kétszerese:{number * (long)2}");

        }

        static void F4()
        {
            Console.Write("Adj meg egy számot: ");
            int szam1 = askForInt();
            Console.Write("Adj meg egy másik számot: ");
            int szam2 = askForInt();

            Console.WriteLine($"összegük:{szam1 + szam2}");
            Console.WriteLine($"különbségük:{szam1 - szam2}");
            Console.WriteLine($"szorzatuk:{szam1 * szam2}");
            Console.WriteLine($"hányadosa:{szam1 / szam2}");
        }

        static void F5()
        {
            Console.Write("Adj meg egy számot: ");
            int szam1 = askForInt();
            Console.Write("Adj meg egy másik számot: ");
            int szam2 = askForInt();

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

        static void F6()
        {
            Console.Write("Adj meg egy számot: ");
            int szam1 = askForInt();
            Console.Write("Adj meg egy másik számot: ");
            int szam2 = askForInt();
            Console.Write("Adj meg egy harmadik számot: ");
            int szam3 = askForInt();

            int?[] tomb = { szam1, szam2, szam3 };

            Console.WriteLine(tomb.Min());
        }

        static void F7()
        {
            Console.Write("Adj meg egy számot: ");
            int a = askForInt();
            Console.Write("Adj meg egy másik számot: ");
            int b = askForInt();
            Console.Write("Adj meg egy harmadik számot: ");
            int c = askForInt();

            if (a < b + c && b < a + c && c < a + b)
            {
                Console.WriteLine("A háromszög szerkezthető");
            }
            else
            {
                Console.WriteLine("A háromszög nem szerkezthető");
            }
        }

        static void F8()
        {
            Console.Write("Adj meg egy számot: ");
            int a = askForInt();
            Console.Write("Adj meg egy másik számot: ");
            int b = askForInt();

            Console.WriteLine($"Számtani közepe: {(a + b) / 2}");
            Console.WriteLine($"Mértani közepe: {Math.Sqrt((double)(a * b))}");
        }

        static void F9()
        {
            Console.Write("Adj meg egy számot: ");
            double a = askForDouble();
            Console.Write("Adj meg egy másik számot: ");
            double b = askForDouble();
            Console.Write("Adj meg egy harmadik számot: ");
            double c = askForDouble();

            double eredmeny = Math.Sqrt((double)(b * b - (4 * a * c)));

            if (eredmeny >= 0)
            {
                Console.WriteLine("Van megoldás");
            }
            else
            {
                Console.WriteLine("Nincs megoldás");
            }
        }

        static void F10()
        {
            Console.Write("a = ");
            double a = askForDouble();
            Console.Write("b = ");
            double b = askForDouble();
            Console.Write("c = ");
            double c = askForDouble();

            double megoldhato = Math.Sqrt((b * b) - (4 * a * c));
            double eredmeny1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            double eredmeny2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

            if (megoldhato >= 0)
            {
                Console.WriteLine($"x1: {eredmeny1}");
                Console.WriteLine($"x2: {eredmeny2}");
            }
            else
            {
                Console.WriteLine("Nincs megoldás");
            }
        }

        static void F11()
        {
            Console.Write("Add meg az egyik befogót: ");
            double a = askForDouble();
            Console.Write("Add meg a másik befogót: ");
            double b = askForDouble();

            double c = Math.Sqrt((b * b) + (a * a));

            Console.WriteLine($"{c:f2}");
        }

        static void F12()
        {
            Console.Write("Add meg az a oldalt: ");
            int x = askForInt();
            Console.Write("Add meg a b oldalt: ");
            int y = askForInt();
            Console.Write("Add meg a c oldalt: ");
            int z = askForInt();

            int felszin = 2 * (x * y + y * z + z * x);
            int terfogat = x * y * z;

            Console.WriteLine($"Felszín: {felszin} \nTérfogat: {terfogat}");
        }

        static void F13()
        {
            Console.Write("Add meg a kör átmérőjét: ");
            int atmero = askForInt();

            double kerulet = atmero * Math.PI;
            double sugar = atmero / 2.0;
            double terulet = Math.PI * (sugar * sugar);

            Console.WriteLine($"Kerülete: {kerulet} \nTerület: {terulet}");
        }

        static void F14()
        {
            Console.Write("Add meg a körív sugarát: ");
            double sugar = askForDouble();
            Console.Write("Add meg a körív középponti szögét: ");
            double kozepSzog = askForDouble();

            double hossz = (kozepSzog / 360) * 2 * sugar * Math.PI;
            double terulet = (kozepSzog / 360) * sugar * sugar * Math.PI;
            Console.WriteLine($"hossza: {hossz}");
            Console.WriteLine($"területe: {terulet}");
        }

        static void F15()
        {
            Console.Write("Adj meg egy pozitív egész számot: ");
            int num = askForInt();

            if (num > 0)
            {
                for (global::System.Int32 i = 1; i < num + 1; i++)
                {
                    Console.Write(i + " ");
                }
            }
            else
            {
                Console.WriteLine("A szám nem pozitív egész szám");
            }

        }

        static void F16()
        {
            Console.Write("Adj meg egy pozitív egész számot: ");
            int num = askForInt();

            if (num > 0)
            {
                for (global::System.Int32 i = 1; i < num + 1; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("A szám nem pozitív egész szám");
            }
        }

        static void F17()
        {
            Console.Write("Adj meg egy pozitív egész számot: ");
            int num = askForInt();

            if (num > 0)
            {
                for (global::System.Int32 i = 1; i < num + 1; i++)
                {
                    if (num % i == 0)
                    {
                        Console.Write($"{i}, ");
                    }
                }
            }
            else
            {
                Console.WriteLine("A szám nem pozitív egész szám");
            }
        }

        static void F18()
        {
            Console.Write("Adj meg egy pozitív egész számot: ");
            int num = askForInt();
            int n = 0;

            if (num > 0)
            {
                for (global::System.Int32 i = 1; i < num + 1; i++)
                {
                    if (num % i == 0)
                    {
                        n += i;
                    }
                }
            }
            else
            {
                Console.WriteLine("A szám nem pozitív egész szám");
            }
            Console.WriteLine($"A szám osztóinak összege: {n}");
        }

        static void F19()
        {
            Console.Write("Adj meg egy pozitív egész számot: ");
            int num = askForInt();
            int n = 0;

            if (num > 0)
            {
                for (global::System.Int32 i = 1; i < num + 1; i++)
                {
                    if (num % i == 0)
                    {
                        n += i;
                    }
                }
            }
            else
            {
                Console.WriteLine("A szám nem pozitív egész szám");
            }
            if (n == num * 2)
            {
                Console.WriteLine("Tökéletes szám");
            }
            else
            {
                Console.WriteLine("Nem tökéletes szám");
            }
        }

        static void F20()
        {
            Console.Write("Hatványalap: ");
            int num1 = askForInt();
            Console.Write("Kitevő: ");
            int num2 = askForInt();
            int result = 1;

            for (int i = 0; i < num2; i++)
            {
                result *= num1;
            }
            Console.WriteLine($"Hatványérték: {result}");
        }

        static void F21()
        {
            int num = 1;
            while (num > 0)
            {
                Console.Write("Írj be egy pozitív számot: ");
                num = askForInt();
            }
        }

        static void F22()
        {
            int num = 0;
            int result = 0;
            while (num < 10)
            {
                Console.Write("Írj be egy számot: ");
                num = askForInt();
                result += num;
            }
            Console.WriteLine($"A számok összege: {result}");
        }

        static void F23()
        {
            Console.Write("Írj be egy számot: ");
            int num = askForInt();

            int result = 0;
            int end = num;

            while (end % 2 == 0)
            {
                result++;
                end /= 2;
            }

            string sum = "";
            for (int i = 0; i < result; i++)
            {
                sum += "2*";
            }
            Console.Write($"{num} = {sum}{end}");

        }

        static void F24()
        {
            string input = "";
            while (input != "alma")
            {
                Console.Write("Írj be egy szót: ");
                input = askForString();
            }

            Console.WriteLine("Az alma gyümölcs!");
        }

        static void F25()
        {
            Console.Write("Írj be egy egész számot: ");
            int num = askForInt();

            int original = num;
            int n = 0;

            while (num >= 3)
            {
                num -= 3;
                n++;
            }

            Console.WriteLine($"{original} = {n}*3 + {num}");
        }

        static void F26()
        {
            Console.Write("Írj be egy számot: ");
            int num = askForInt();

            int n = 0;

            for (int i = 1; i < num + 1; i++)
            {
                if (num % i == 0)
                {
                    n++;
                }
            }
            if (n == 2)
            {
                Console.WriteLine("Prímszám");
            }
            else
            {
                Console.WriteLine("Nem prímszám");
            }
        }

        static void F27()
        {
            Console.Write("Írj be egy számot: ");
            int num = askForInt();
            for (int i = 0; i < num; i++)
            {
                int n = 0;
                for (int j = 1; j < i + 1; j++)
                {
                    if (i % j == 0)
                    {
                        n++;
                    }
                }
                if (n == 2)
                {
                    Console.WriteLine($"{i} ");
                }
            }
        }

        static void F28()
        {
            Console.Write("Írj be egy számot: ");
            int num = askForInt();
            for (int i = 0; i < num; i++)
            {
                int n = 0;
                for (int j = 1; j < i + 1; j++)
                {
                    if (i % j == 0)
                    {
                        n++;
                    }
                }
                if (n == 2)
                {
                    if (num % i == 0)
                    {
                        Console.WriteLine($"{i} ");
                    }
                }
            }
        }

        static void F29()
        {
            Console.Write("Írj be egy számot: ");
            int num = askForInt();
            int n = 2;
            while (num > 1)
            {
                if (num % n == 0)
                {
                    Console.WriteLine($"{num} {n}");
                    num = num / n;
                }
                else
                {
                    n++;
                }
            }
        }

        static void F30()
        {
            Console.Write("Írj be egy számot: ");
            int a = askForInt();
            Console.Write("Írj be egy másik számot: ");
            int b = askForInt();

            while (b > 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            Console.WriteLine($"LNKO: {a}");

        }

        static void F31()
        {
            Console.Write("Írj be egy számot: ");
            int a = askForInt();
            Console.Write("Írj be egy másik számot: ");
            int b = askForInt();
            int lnko = 1;

            int a_original = a;
            int b_original = b;

            while (b > 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            lnko = a;

            int lkkt = (a_original * b_original) / lnko;
            Console.WriteLine($"LKKT: {lkkt}");
        }

        static void F32()
        {
            Console.Write("Írj be egy számot: ");
            int num = askForInt();
            int n = 1;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{num}*{n}={num*n}");
                n++;
            }
        }

        static void F33()
        {
            Console.Write("Írj be egy számot: ");
            int num = askForInt();
            int n = 1;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{num}+{n}={num + n}");
                n++;
            }
        }

        static void F34()
        {

        }

        static void F35() 
        {
            for (int i = 0; i < 255; i++)
            {
                if (char.IsAsciiLetterLower((char)i))
                {
                    Console.WriteLine($"{i}\t{(char)i}");
                }
            }
        }

        static void F36() 
        { 
            Console.Write("Írd be a sorok számát: ");
            int row = askForInt();
            Console.Write("Írd be az oszlopok számát: ");
            int column = askForInt();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++) 
                {
                    if (i % 2 == 0)
                    {
                        Console.Write("OX");
                    }
                    else
                    {
                        Console.Write("XO");
                    }
                }
                Console.WriteLine();
            }
        }

        static void F37()
        {
            Console.Write("Írd be a sorok számát: ");
            int row = askForInt();
            string line = "*";

            for (int i = 0; i < row ; i++)
            {
                Console.WriteLine(line);
                line += "**";
            }
        }

        static void F38()
        {
            Console.Write("Írd be a sorok számát: ");
            int row = askForInt();
            int n = row;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    Console.Write(" ");
                }
                n--;
                for (int k = 0; k < (2 * i) + 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        static void F39()
        {
            Console.Write("Írd be a sorok számát: ");
            int row = askForInt();
            Console.Write("Írd be az oszlopok számát: ");
            int col = askForInt();

            for (int N = 1; N < row+1; N++)
            {
                for (int M = 1; M < col+1; M++)
                {
                    if (N == 1 || M == 1 || N == row || M == col)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void F40()
        {
            Console.Write("Írj be egy számot: ");
            int num = askForInt();  

            for (int i = 1; i < num + 1; i++)
            {
                int n = 0;
                for (int j = 1; j < i + 1; j++)
                {
                    if (i % j == 0)
                    {
                        
                        n++;
                    }
                }
                if (num == n*2)
                {
                    Console.WriteLine($"{n*2} ");
                }
            }
        }
        /*Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            while (Console.ReadKey().Key == ConsoleKey.DownArrow) 
            {
                Console.Write('|');
                Console.CursorTop++;
                Console.CursorLeft--;
            }*/


        /*
         Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        Console.Write('v');
                        Console.CursorTop++;
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Write('˄');
                        Console.CursorTop--;
                        Console.CursorLeft--;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.Write('>');
                        Console.CursorLeft++;
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.Write('<');
                        Console.CursorLeft--;
                        Console.CursorLeft--;
                        break;
                }
            }
         */

        /*while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Spacebar:
                    Console.Write(' ');
                    break;
                }
            }
         */

        /*case ConsoleKey.Spacebar:
                        if (theme == false)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                            theme = true;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Clear();
                            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                            theme = false;
                        }
                        break;
         */

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.BufferHeight = Console.WindowHeight;
            Console.Title = "NE NÉZD A CÍMÉT!";
            Console.CursorSize = 100;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);

            int color = 0;
            int theme = 0;
            int e = 0;
            bool r = false;
            bool f = false;

            while (true)
            {
                (int x, int y) = Console.GetCursorPosition();

                Console.SetCursorPosition(0, Console.WindowTop + 1);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("▄");
                }
                Console.SetCursorPosition(0, Console.WindowTop);
                Console.BackgroundColor = ConsoleColor.White;
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write(" ");
                }


                if (f == true)
                {
                    if (r == true)
                    {
                        Console.CursorTop = 0;
                        Console.CursorLeft = 0;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("RADÍR   ║ KÖV.HÁTTÉR: ");
                        Console.CursorTop = 0;
                        Console.CursorLeft = 21;
                        if (theme == 15)
                        {
                            theme = 0;
                        }
                        Console.ForegroundColor = (ConsoleColor)theme+1;
                        Console.Write('█');

                    }
                    else
                    {
                        if (e == 0)
                        {
                            Console.CursorTop = 0;
                            Console.CursorLeft = 0;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("MINTA  ║ KÖV.HÁTTÉR: ");
                            Console.CursorTop = 0;
                            Console.CursorLeft = 21;
                            if(theme == 15)
                            {
                                theme = 0;
                            }
                            Console.ForegroundColor = (ConsoleColor)theme + 1;
                            Console.Write('█');

                        }
                        else if (e == 1)
                        {
                            Console.CursorTop = 0;
                            Console.CursorLeft = 0;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("SZÍN:  ║ KÖV.HÁTTÉR: ");
                            Console.CursorTop = 0;
                            Console.CursorLeft = 21;
                            if (theme == 15)
                            {
                                theme = 0;
                            }
                            Console.ForegroundColor = (ConsoleColor)theme + 1;
                            Console.Write('█');
                            Console.CursorTop = 0;
                            Console.CursorLeft = 5;
                            Console.ForegroundColor = (ConsoleColor)color;
                            Console.Write('█');
                            
                        }
                        else
                        {
                            Console.CursorTop = 0;
                            Console.CursorLeft = 0;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("MOZGÁS ║ KÖV.HÁTTÉR: ");
                            Console.CursorTop = 0;
                            Console.CursorLeft = 21;
                            if (theme == 15)
                            {
                                theme = 0;
                            }
                            Console.ForegroundColor = (ConsoleColor)theme + 1;
                            Console.Write('█');

                        }
                    }
                }
                else
                {
                    Console.CursorTop = 0;
                    Console.CursorLeft = 0;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("       ");
                    Console.SetCursorPosition(x, y);
                }
                Console.SetCursorPosition(x, y);
                if (y == 1)
                {
                    Console.CursorTop++;
                }

                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (r == true)
                        {
                            Console.Write(' ');
                            Console.CursorTop++;
                            Console.CursorLeft--;
                        }
                        else
                        {
                            if (e == 0)
                            {
                                Console.BackgroundColor = (ConsoleColor)theme;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('♥');
                                Console.CursorTop++;
                                Console.CursorLeft--;
                            }
                            else if (e == 1)
                            {
                                Console.ForegroundColor = (ConsoleColor)color;
                                Console.Write('█');
                                Console.CursorTop++;
                                Console.CursorLeft--;
                            }
                            else
                            {
                                Console.CursorTop++;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (r == true)
                        {
                            Console.Write(' ');
                            Console.CursorTop--;
                            Console.CursorLeft--;
                        }
                        else
                        {
                            if (e == 0)
                            {
                                Console.BackgroundColor = (ConsoleColor)theme;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('♦');
                                Console.CursorTop--;
                                Console.CursorLeft--;
                            }
                            else if (e == 1)
                            {
                                Console.ForegroundColor = (ConsoleColor)color;
                                Console.Write('█');
                                Console.CursorTop--;
                                Console.CursorLeft--;
                            }
                            else
                            {
                                Console.CursorTop--;
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if(r == true)
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            if (e == 0)
                            {
                                Console.BackgroundColor = (ConsoleColor)theme;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write('♠');
                            }
                            else if (e == 1)
                            {
                                Console.ForegroundColor = (ConsoleColor)color;
                                Console.Write('█');
                            }
                            else
                            {
                                Console.CursorLeft++;
                            }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (r == true)
                        {
                            Console.Write(' ');
                            Console.CursorLeft--;
                            Console.CursorLeft--;
                        }
                        else
                        {
                            if (e == 0)
                            {
                                Console.BackgroundColor = (ConsoleColor)theme;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write('♣');
                                Console.CursorLeft--;
                                Console.CursorLeft--;
                            }
                            else if (e == 1)
                            {
                                Console.ForegroundColor = Console.ForegroundColor = (ConsoleColor)color;
                                Console.Write('█');
                                Console.CursorLeft--;
                                Console.CursorLeft--;
                            }
                            else
                            {
                                Console.CursorLeft--;
                                Console.CursorLeft--;
                            }
                        }
                        break;

                    case ConsoleKey.Spacebar:
                        theme++;
                        if (theme == 16)
                        {
                            theme = 0;
                        }
                        Console.BackgroundColor = (ConsoleColor)theme;
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        break;

                    case ConsoleKey.R:
                        r = !r;
                        Console.Write("\b \b");
                        break;

                    case ConsoleKey.E:
                        color++;
                        if (color == 16)
                        {
                            color = 0;
                        }
                        Console.Write("\b \b");
                        break;

                    case ConsoleKey.Q:
                        Console.Write("\b \b");
                        e++;
                        if (e == 3)
                        {
                            e = 0;
                        }
                        break;

                    case ConsoleKey.F1:
                        f = !f;
                        break;
                }
            }
        }
    }
}