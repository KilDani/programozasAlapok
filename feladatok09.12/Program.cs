using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.IO;

namespace feladatok09._12
{
    class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Foreground { get; set; }

        public ConsoleColor Background { get; set; }

        public char Symbol { get; set; }
        public string ToCsv()
        {
            return $"{X},{Y},{(int)Foreground},{(int)Background},{Symbol}";
        }
        public static Pixel FromCsv(string csv)
        {
            var splits = csv.Split(',');
            return new Pixel()
            {
                X = int.Parse(splits[0]),
                Y = int.Parse(splits[1]),
                Foreground = (ConsoleColor)int.Parse(splits[2]),
                Background = (ConsoleColor)int.Parse(splits[3]),
                Symbol = splits[4][0]
            };
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.BufferHeight = Console.WindowHeight;
            Console.Title = "NE NÉZD A CÍMÉT!";
            Console.CursorSize = 100;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);

            List<Pixel> pixels = new List<Pixel>();
            int color = 0;
            int theme = 0;
            int e = 0;
            bool r = false;
            bool f = false;
            bool showHelp = false;

            while (true)
            {
                if (!showHelp)
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
                            Console.ForegroundColor = (ConsoleColor)theme + 1;
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
                                if (theme == 15)
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
                }
                else
                {
                    ShowHelpMenu();
                }

                var keyInfo = Console.ReadKey(true);
                var key = keyInfo.Key;

                if (key == ConsoleKey.Escape)
                {
                    showHelp = !showHelp;
                    if (!showHelp)
                    {
                        Console.BackgroundColor = (ConsoleColor)theme;
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    }
                }

                (int currentX, int currentY) = Console.GetCursorPosition();

                if (currentX >= Console.WindowWidth)
                    Console.CursorLeft = Console.WindowWidth - 1;
                if (currentY >= Console.WindowHeight)
                    Console.CursorTop = Console.WindowHeight - 1;
                if (currentX < 0)
                    Console.CursorLeft = 0;
                if (currentY < 0)
                    Console.CursorTop = 0;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        if (r == true)
                        {
                            Console.Write(' ');
                            if (currentY < Console.WindowHeight - 1)
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
                                pixels.Add(new Pixel()
                                {
                                    X = currentX,
                                    Y = currentY,
                                    Foreground = (ConsoleColor)color,
                                    Background = (ConsoleColor)theme,
                                    Symbol = '♥'
                                });
                                if (currentY < Console.WindowHeight - 1)
                                    Console.CursorTop++;
                                Console.CursorLeft--;
                            }
                            else if (e == 1)
                            {
                                Console.ForegroundColor = (ConsoleColor)color;
                                Console.Write('█');
                                pixels.Add(new Pixel()
                                {
                                    X = currentX,
                                    Y = currentY,
                                    Foreground = (ConsoleColor)color,
                                    Background = (ConsoleColor)theme,
                                    Symbol = '█'
                                });
                                if (currentY < Console.WindowHeight - 1)
                                    Console.CursorTop++;
                                Console.CursorLeft--;
                            }
                            else
                            {
                                if (currentY < Console.WindowHeight - 1)
                                    Console.CursorTop++;
                            }
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (r == true)
                        {
                            Console.Write(' ');
                            if (currentY > 0)
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
                                pixels.Add(new Pixel()
                                {
                                    X = currentX,
                                    Y = currentY,
                                    Foreground = (ConsoleColor)color,
                                    Background = (ConsoleColor)theme,
                                    Symbol = '♦'
                                });
                                if (currentY > 0)
                                    Console.CursorTop--;
                                Console.CursorLeft--;
                            }
                            else if (e == 1)
                            {
                                Console.ForegroundColor = (ConsoleColor)color;
                                Console.Write('█');
                                pixels.Add(new Pixel()
                                {
                                    X = currentX,
                                    Y = currentY,
                                    Foreground = (ConsoleColor)color,
                                    Background = (ConsoleColor)theme,
                                    Symbol = '█'
                                });
                                if (currentY > 0)
                                    Console.CursorTop--;
                                Console.CursorLeft--;
                            }
                            else
                            {
                                if (currentY > 0)
                                    Console.CursorTop--;
                            }
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (r == true)
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
                                pixels.Add(new Pixel()
                                {
                                    X = currentX,
                                    Y = currentY,
                                    Foreground = (ConsoleColor)color,
                                    Background = (ConsoleColor)theme,
                                    Symbol = '♠'
                                });
                            }
                            else if (e == 1)
                            {
                                Console.ForegroundColor = (ConsoleColor)color;
                                Console.Write('█');
                                pixels.Add(new Pixel()
                                {
                                    X = currentX,
                                    Y = currentY,
                                    Foreground = (ConsoleColor)color,
                                    Background = (ConsoleColor)theme,
                                    Symbol = '█'
                                });
                            }
                            else
                            {
                                if (currentX < Console.WindowWidth - 1)
                                    Console.CursorLeft++;
                            }
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (r == true)
                        {
                            Console.Write(' ');
                            if (currentX > 0)
                            {
                                Console.CursorLeft--;
                                Console.CursorLeft--;
                            }
                        }
                        else
                        {
                            if (e == 0)
                            {
                                Console.BackgroundColor = (ConsoleColor)theme;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write('♣');
                                pixels.Add(new Pixel()
                                {
                                    X = currentX,
                                    Y = currentY,
                                    Foreground = (ConsoleColor)color,
                                    Background = (ConsoleColor)theme,
                                    Symbol = '♣'
                                });
                                if (currentX > 0)
                                {
                                    Console.CursorLeft--;
                                    Console.CursorLeft--;
                                }
                            }
                            else if (e == 1)
                            {
                                Console.ForegroundColor = (ConsoleColor)color;
                                Console.Write('█');
                                pixels.Add(new Pixel()
                                {
                                    X = currentX,
                                    Y = currentY,
                                    Foreground = (ConsoleColor)color,
                                    Background = (ConsoleColor)theme,
                                    Symbol = '█'
                                });
                                if (currentX > 0)
                                {
                                    Console.CursorLeft--;
                                    Console.CursorLeft--;
                                }
                            }
                            else
                            {
                                if (currentX > 0)
                                {
                                    Console.CursorLeft--;
                                    Console.CursorLeft--;
                                }
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

                    case ConsoleKey.S:
                        Save("kep.csv", pixels);
                        Console.Write("\b \b");
                        Console.SetCursorPosition(currentX, currentY);
                        break;

                    case ConsoleKey.L:
                        Console.Clear();
                        pixels = Load("kep.csv");
                        DrawPixels(pixels);
                        Console.Write("\b \b");
                        break;
                }
            }
        }

        static void ShowHelpMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            int centerX = Console.WindowWidth / 2;
            int startY = 2;

            string title = "SEGÍTSÉG";
            Console.SetCursorPosition(centerX - title.Length / 2, startY);
            Console.Write(title);

            string[] help = {
                "← ↑ ↓ →   , Kurzor mozgatás       ",
                "SPACE     , Háttérszín változtatás",
                "R         , Radír                 ",
                "E         , Szín változtatás      ",
                "Q         , Mód váltás            ",
                "S         , Mentés                ",
                "L         , Betöltés              ",
                "F1        , Infosor               ",
                "ESC       , Segítség              "
            };

            for (int i = 0; i < help.Length; i++)
            {
                int x = centerX - help[i].Length / 2;
                Console.SetCursorPosition(x, help.Length / 2 + i);
                Console.Write(help[i]);
            }

            string esc = "Nyomj ESC-et a folytatáshoz";
            Console.SetCursorPosition(centerX - esc.Length / 2, startY + help.Length + 4);
            Console.Write(esc);
        }

        static void Save(string filename, List<Pixel> pixels)
        {
            using (StreamWriter streamW = new StreamWriter(filename))
            {
                foreach (var pixel in pixels)
                {
                    streamW.WriteLine(pixel.ToCsv());
                }
            }
        }
        static List<Pixel> Load(string filename)
        {
            List<Pixel> loadedPixels = new List<Pixel>();
            if (!File.Exists(filename))
                return loadedPixels;

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                loadedPixels.Add(Pixel.FromCsv(line));
            }

            return loadedPixels;
        }
        static void DrawPixels(List<Pixel> pixels)
        {
            foreach (var pixel in pixels)
            {
                Console.SetCursorPosition(pixel.X, pixel.Y);
                Console.ForegroundColor = pixel.Foreground;
                Console.BackgroundColor = pixel.Background;
                Console.Write(pixel.Symbol);
            }
        }
    }
}