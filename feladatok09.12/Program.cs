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
            string[] s = csv.Split(',');
            return new Pixel
            {
                X = int.Parse(s[0]),
                Y = int.Parse(s[1]),
                Foreground = (ConsoleColor)int.Parse(s[2]),
                Background = (ConsoleColor)int.Parse(s[3]),
                Symbol = s[4][0]
            };
        }
    }

    internal class Program
    {
        static ConsoleColor currentBackground = ConsoleColor.White;

        static void Main(string[] args)
        {
            Console.BackgroundColor = currentBackground;
            Console.Clear();
            DrawBottomBar();
            Console.CursorSize = 100;

            List<Pixel> pixels = new List<Pixel>();

            int color = 0;
            int theme = 0;
            int mode = 0;
            bool r = false;
            bool f = false;
            bool showHelp = true;

            while (true)
            {
                Console.BufferWidth = Console.WindowWidth;
                Console.BufferHeight = Console.WindowHeight;

                if (!showHelp)
                {
                    (int x, int y) = Console.GetCursorPosition();

                    Console.SetCursorPosition(0, 0);
                    Console.BackgroundColor = currentBackground;
                    Console.Write(new string(' ', Console.WindowWidth));

                    if (f)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.Black;

                        if (r)
                            Console.Write("RADÍR  ║ KÖV.HÁTTÉR: ");
                        else if (mode == 0)
                            Console.Write("SZÍN   ║ KÖV.HÁTTÉR: ");
                        else
                            Console.Write("MOZGÁS ║ KÖV.HÁTTÉR: ");

                        Console.SetCursorPosition(21, 0);
                        if (theme == 15) theme = 0;
                        Console.ForegroundColor = (ConsoleColor)(theme + 1);
                        Console.Write('█');

                        if (mode == 0 && !r)
                        {
                            Console.SetCursorPosition(7, 0);
                            Console.ForegroundColor = (ConsoleColor)color;
                            Console.Write('█');
                        }
                    }

                    Console.SetCursorPosition(x, y);
                    if (y == 1) Console.CursorTop++;
                }
                else
                {
                    ShowHelpMenu();
                }

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                {
                    showHelp = !showHelp;
                    if (!showHelp)
                    {
                        Console.BackgroundColor = currentBackground;
                        Console.Clear();
                        DrawBottomBar();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    }
                    continue;
                }

                (int cx, int cy) = Console.GetCursorPosition();

                switch (key)
                {
                    case ConsoleKey.Q:
                        mode++;
                        if (mode == 2) mode = 0;
                        break;

                    case ConsoleKey.R:
                        r = !r;
                        break;

                    case ConsoleKey.E:
                        color++;
                        if (color == 16) color = 0;
                        break;

                    case ConsoleKey.F1:
                        f = !f;
                        break;

                    case ConsoleKey.Spacebar:
                        theme++;
                        if (theme == 16) theme = 0;
                        currentBackground = (ConsoleColor)theme;
                        Console.BackgroundColor = currentBackground;
                        Console.Clear();
                        DrawBottomBar();
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        break;

                    case ConsoleKey.DownArrow:
                        HandleDraw(cx, cy, 0, 1, mode, r, color, pixels);
                        break;

                    case ConsoleKey.UpArrow:
                        HandleDraw(cx, cy, 0, -1, mode, r, color, pixels);
                        break;

                    case ConsoleKey.RightArrow:
                        HandleDraw(cx, cy, 1, 0, mode, r, color, pixels);
                        break;

                    case ConsoleKey.LeftArrow:
                        HandleDraw(cx, cy, -1, 0, mode, r, color, pixels);
                        break;

                    case ConsoleKey.S:
                        {
                            Console.SetCursorPosition(0, Console.WindowHeight - 1);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = currentBackground;
                            Console.Write("Mentés neve: ");
                            string saveName = Console.ReadLine();
                            Save(saveName + ".csv", pixels);
                            Console.SetCursorPosition(0, Console.WindowHeight - 1);
                            Console.Write("Mentett fájl: " + saveName);
                            DrawBottomBar();
                        }
                        break;

                    case ConsoleKey.L:
                        {
                            Console.BackgroundColor = currentBackground;
                            Console.ForegroundColor = ConsoleColor.Black;
                            DrawBottomBar();
                            Console.SetCursorPosition(0, Console.WindowHeight - 1);
                            Console.Write("Betöltés neve: ");
                            string loadName = Console.ReadLine();
                            if (File.Exists(loadName + ".csv"))
                            {
                                pixels = Load(loadName + ".csv");
                                DrawPixels(pixels);
                            }
                        }
                        break;
                }
            }
        }

        static void HandleDraw(int x, int y, int dx, int dy, int mode, bool r, int color, List<Pixel> pixels)
        {
            if (r)
            {
                Console.ForegroundColor = currentBackground;
                Console.Write('█');
                pixels.RemoveAll(p => p.X == x && p.Y == y);
            }
            else
            {
                char sym = '█';
                Console.ForegroundColor = (ConsoleColor)color;

                if (mode == 1)
                {
                    Console.SetCursorPosition(x + dx, y + dy);
                    return;
                }

                Console.BackgroundColor = currentBackground;
                Console.Write(sym);

                pixels.Add(new Pixel
                {
                    X = x,
                    Y = y,
                    Foreground = Console.ForegroundColor,
                    Background = currentBackground,
                    Symbol = sym
                });
            }

            Console.SetCursorPosition(x + dx, y + dy);
        }

        static void ShowHelpMenu()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            int c = Console.WindowWidth / 2;

            string title = "SEGÍTSÉG";
            Console.SetCursorPosition(c - title.Length / 2, 2);
            Console.Write(title);

            string[] help =
            {
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
                Console.SetCursorPosition(c - help[i].Length / 2, 5 + i);
                Console.Write(help[i]);
            }

            string esc = "ESC a folytatáshoz";
            Console.SetCursorPosition(c - esc.Length / 2, 5 + help.Length + 2);
            Console.Write(esc);
        }

        static void DrawBottomBar()
        {
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = currentBackground;
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write("▄");
        }

        static void Save(string file, List<Pixel> pixels)
        {

            List<string> lines = new List<string>();

            lines.Add(((int)currentBackground).ToString());

            for (int i = 0; i < pixels.Count; i++)
                lines.Add(pixels[i].ToCsv());

            File.WriteAllLines(file, lines.ToArray());

        }

        static List<Pixel> Load(string file)
        {
            List<Pixel> list = new List<Pixel>();

            string[] lines = File.ReadAllLines(file);
            currentBackground = (ConsoleColor)int.Parse(lines[0]);
            Console.BackgroundColor = currentBackground;
            Console.Clear();
            DrawBottomBar();

            for(int i = 1; i < lines.Length; i++)
                list.Add(Pixel.FromCsv(lines[i]));

            return list;
        }

        static void DrawPixels(List<Pixel> pixels)
        {
            for (int i = 0; i < pixels.Count; i++)
            {
                Pixel p = pixels[i];
                if (p.X >= Console.WindowWidth || p.Y >= Console.WindowHeight) continue;
                Console.SetCursorPosition(p.X, p.Y);
                Console.ForegroundColor = p.Foreground;
                Console.BackgroundColor = p.Background;
                Console.Write(p.Symbol);
            }
        }
    }
}
