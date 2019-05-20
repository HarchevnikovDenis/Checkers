using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCheckers
{
    class Field
    {
        public static bool[,] field = new bool[8, 8];
        public static byte countBlue = 12;
        public static byte countRed = 12;
        private static int m = 8;
        private static int n = 8;
        public static int step = 1;


        public Field()
        {
            field[0, 0] = false;
            field[0, 1] = true;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        j = 2;
                    }
                    if (j != 0)
                    {
                        if (!field[i, j - 1])
                        {
                            field[i, j] = true;
                        }
                        else field[i, j] = false;
                    }
                    else
                    {
                        if (!field[i - 1, j])
                        {
                            field[i, j] = true;
                        }
                        else field[i, j] = false;
                    }

                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < 3 && field[i, j])
                    {
                        Player.kill[i, j] = 1;
                    }
                    if (i > 4 && field[i, j])
                    {
                        Player.kill[i, j] = -1;
                    }
                }
            }
            GameProcess();
        }

        public static void GameProcess()
        {
            PrintField(Player.kill);
            while (countRed != 0 && countBlue != 0 || Player.TestStep(step))
            {
                if (!Player.TestStep(step))
                {
                    if (step % 2 != 0)
                    {
                        if (!WhitePlayer.WhiteTestKill())
                        {
                            step--;
                            break;
                        }
                    }
                    else
                    {
                        if (!BlackPlayer.BlackTestKill())
                        {
                            step--;
                            break;
                        }
                    }
                }
                if (step % 2 != 0) WhitePlayer.WhiteStepFrom();
                else BlackPlayer.BlackStepFrom();
                step++;
            }
            if (countRed == 0 && countBlue != 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Синие победили");
                Console.ResetColor();
            }
            if (countRed != 0 && countBlue == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Красные победили");
                Console.ResetColor();
            }
            if (!Player.TestStep(step) && countRed != 0 && countBlue != 0)
            {
                if (step % 2 == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Красные победили");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Синие победили");
                    Console.ResetColor();
                }
            }
        }

        public static void PrintField(int[,] kill)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("  Количество синих : " + countBlue);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t    Количество красных : " + countRed);
            Console.ResetColor();
            if (step % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t     Ход Красных");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\t\t\t     Ход Синих");
                Console.ResetColor();
            }
            for (byte i = 0; i < m; i++)
            {
                if (kill[0, i] == -1)
                {
                    kill[0, i] = -2;
                }
                if (kill[7, i] == 1)
                {
                    kill[7, i] = 2;
                }
            }
            Console.WriteLine();
            Console.Write("\t\t   ");
            for (int i = 0; i < 8; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                switch (i)
                {
                    case 0:
                        Console.Write("    A ");
                        break;
                    case 1:
                        Console.Write(" B ");
                        break;
                    case 2:
                        Console.Write(" C ");
                        break;
                    case 3:
                        Console.Write(" D ");
                        break;
                    case 4:
                        Console.Write(" E ");
                        break;
                    case 5:
                        Console.Write(" F ");
                        break;
                    case 6:
                        Console.Write(" G ");
                        break;
                    case 7:
                        Console.Write(" H   ");
                        break;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            for (int i = 0; i < m; i++)
            {
                Console.Write("\t\t   ");
                for (int j = 0; j < n; j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (j == 0) Console.Write(" " + (i + 1) + "|");
                    if ((Player.kursX == j && Player.kursY == i) || Player.posx[i, j] == 1 || Player.posx[i, j] == 2)
                    {
                        if (Player.posx[i, j] == 1) Console.BackgroundColor = ConsoleColor.Green;
                        if (Player.posx[i, j] == 2) Console.BackgroundColor = ConsoleColor.Red;
                        if (Player.kursX == j && Player.kursY == i) Console.BackgroundColor = ConsoleColor.Yellow;
                        if (j < n - 1)
                        {
                            if (kill[i, j] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" о ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                            }
                            else if (field[i, j])
                            {
                                Console.Write("   ");
                            }
                            else
                            {
                                Console.Write("   ");
                                Console.ResetColor();
                            }

                        }
                        else
                        {
                            if (kill[i, j] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == 2)
                            {
                                //Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == -1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == -2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (!field[i, j])
                            {
                                Console.Write("   ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("   ");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ResetColor();
                            }
                        }
                    }
                    else
                    {
                        if (j < n - 1)
                        {
                            if (kill[i, j] == 1)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" о ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == 2)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -2)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -1)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                            }
                            else if (field[i, j])
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("   ");
                            }
                            else
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("   ");
                                Console.ResetColor();
                            }

                        }
                        else
                        {
                            if (kill[i, j] == 1)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == 2)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == -1)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == -2)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (!field[i, j])
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("   ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("   ");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ResetColor();
                            }
                        }
                    }
                }
            }
            Console.Write("\t\t   ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

        }

        public static void PrintKillField(int[,] kill)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("  Количество синих : " + countBlue);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t    Количество красных : " + countRed);
            Console.ResetColor();
            if (step % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t     Ход Красных");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\t\t\t     Ход Синих");
                Console.ResetColor();
            }
            for (byte i = 0; i < m; i++)
            {
                if (kill[0, i] == -1)
                {
                    kill[0, i] = -2;
                }
                if (kill[7, i] == 1)
                {
                    kill[7, i] = 2;
                }
            }
            Console.WriteLine();
            Console.Write("\t\t   ");
            for (int i = 0; i < 8; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                switch (i)
                {
                    case 0:
                        Console.Write("    A ");
                        break;
                    case 1:
                        Console.Write(" B ");
                        break;
                    case 2:
                        Console.Write(" C ");
                        break;
                    case 3:
                        Console.Write(" D ");
                        break;
                    case 4:
                        Console.Write(" E ");
                        break;
                    case 5:
                        Console.Write(" F ");
                        break;
                    case 6:
                        Console.Write(" G ");
                        break;
                    case 7:
                        Console.Write(" H   ");
                        break;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            for (int i = 0; i < m; i++)
            {
                Console.Write("\t\t   ");
                for (int j = 0; j < n; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    if (j == 0) Console.Write(" " + (i + 1) + "|");
                    if ((Player.kursX == j && Player.kursY == i) || Player.posx[i, j] == 1 || Player.posx[i, j] == 2)
                    {
                        if (Player.kursX == j && Player.kursY == i) Console.BackgroundColor = ConsoleColor.Yellow;
                        if (j < n - 1)
                        {
                            if (kill[i, j] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" о ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                            }
                            else if (field[i, j])
                            {
                                Console.Write("   ");
                            }
                            else
                            {
                                Console.Write("   ");
                                Console.ResetColor();
                            }

                        }
                        else
                        {
                            if (kill[i, j] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == 2)
                            {
                                //Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else if (!field[i, j])
                            {
                                Console.Write("   ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("   ");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                        }
                    }
                    else
                    {
                        if (j < n - 1)
                        {
                            if (kill[i, j] == 1)
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" о ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == 2)
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -2)
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -1)
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                            }
                            else if (field[i, j])
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.Write("   ");
                            }
                            else
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("   ");
                                Console.ResetColor();
                            }

                        }
                        else
                        {
                            if (kill[i, j] == 1)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == 2)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -1)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -2)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else if (!field[i, j])
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("   ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("   ");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.ResetColor();
                            }
                        }
                    }
                }
            }
            Console.Write("\t\t   ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

        }

        public static void PrintAfterStep(int[,] kill, int step)
        {
            step = step++;
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("  Количество синих : " + countBlue);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t    Количество красных : " + countRed);
            Console.ResetColor();
            if (step % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\t\t     Ход Красных");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\t\t\t     Ход Синих");
                Console.ResetColor();
            }
            for (byte i = 0; i < m; i++)
            {
                if (kill[0, i] == -1)
                {
                    kill[0, i] = -2;
                }
                if (kill[7, i] == 1)
                {
                    kill[7, i] = 2;
                }
            }
            Console.WriteLine();
            Console.Write("\t\t   ");
            for (int i = 0; i < 8; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                switch (i)
                {
                    case 0:
                        Console.Write("    A ");
                        break;
                    case 1:
                        Console.Write(" B ");
                        break;
                    case 2:
                        Console.Write(" C ");
                        break;
                    case 3:
                        Console.Write(" D ");
                        break;
                    case 4:
                        Console.Write(" E ");
                        break;
                    case 5:
                        Console.Write(" F ");
                        break;
                    case 6:
                        Console.Write(" G ");
                        break;
                    case 7:
                        Console.Write(" H   ");
                        break;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            for (int i = 0; i < m; i++)
            {
                Console.Write("\t\t   ");
                for (int j = 0; j < n; j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (j == 0) Console.Write(" " + (i + 1) + "|");
                    if ((Player.kursX == j && Player.kursY == i) || Player.posx[i, j] == 1)
                    {
                        if (Player.posx[i, j] == 1) Console.BackgroundColor = ConsoleColor.Green;
                        if (Player.kursX == j && Player.kursY == i) Console.BackgroundColor = ConsoleColor.Yellow;
                        if (j < n - 1)
                        {
                            if (kill[i, j] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" о ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                            }
                            else if (field[i, j])
                            {
                                Console.Write("   ");
                            }
                            else
                            {
                                Console.Write("   ");
                                Console.ResetColor();
                            }

                        }
                        else
                        {
                            if (kill[i, j] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == 2)
                            {
                                //Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == -1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == -2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (!field[i, j])
                            {
                                Console.Write("   ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("   ");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ResetColor();
                            }
                        }
                    }
                    else
                    {
                        if (j < n - 1)
                        {
                            if (kill[i, j] == 1)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" о ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == 2)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -2)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                            }
                            else if (kill[i, j] == -1)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                            }
                            else if (field[i, j])
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("   ");
                            }
                            else
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("   ");
                                Console.ResetColor();
                            }

                        }
                        else
                        {
                            if (kill[i, j] == 1)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == 2)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == -1)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" o ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (kill[i, j] == -2)
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" 0 ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else if (!field[i, j])
                            {
                                //Console.Write("|");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("   ");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("   ");
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("| ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ResetColor();
                            }
                        }
                    }
                }
            }
            Console.Write("\t\t   ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

        }
    }
}
