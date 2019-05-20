using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCheckers
{
    abstract class Player
    {
        public static int[,] kill = new int[8, 8];
        protected static int m = 8;
        protected static int n = 8;
        public static int[,] killFrom = new int[12, 2];
        protected static int[,] killIn = new int[12, 2];
        protected static int[,] resetKill = new int[4, 4];
        public static int kursX = 0;
        public static int kursY = 0;
        public static int[,] posx = new int[8, 8];
        private static int RepeatP = 0;
        private static int RepeatV = 0;
        private static bool test = false;


        public static bool TestStep(int step)              
        {
            byte status = 0;
            if (step % 2 == 1)
            {
                for (byte i = 0; i < m; i++)
                {
                    for (byte j = 0; j < m; j++)
                    {
                        if (kill[i, j] == 1)
                        {
                            try
                            {
                                if (kill[i + 1, j - 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            { }
                            try
                            {
                                if (kill[i + 1, j + 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                        }
                        if (kill[i, j] == 2)
                        {
                            try
                            {
                                if (kill[i + 1, j - 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            try
                            {
                                if (kill[i + 1, j + 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            try
                            {
                                if (kill[i - 1, j - 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            try
                            {
                                if (kill[i - 1, j + 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                        }
                    }
                }
            }
            else
            {
                for (byte i = 0; i < m; i++)
                {
                    for (byte j = 0; j < m; j++)
                    {
                        if (kill[i, j] == -1)
                        {
                            try
                            {
                                if (kill[i - 1, j - 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            { }
                            try
                            {
                                if (kill[i - 1, j + 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                        }
                        if (kill[i, j] == -2)
                        {
                            try
                            {
                                if (kill[i + 1, j - 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            try
                            {
                                if (kill[i + 1, j + 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            try
                            {
                                if (kill[i - 1, j - 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                            try
                            {
                                if (kill[i - 1, j + 1] == 0)
                                {
                                    status++;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                            }
                        }
                    }
                }
            }
            if (status != 0) return true;
            else return false;
        }

        protected static bool SelectDamTestKill(int k, int t)
        {
            if (kill[k, t] > 1)
            {
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t - i] <= -1)
                        {
                            if (kill[k - i - 1, t - i - 1] == 0)
                            {
                                return true;
                            }
                            else break;
                        }
                        if (kill[k - i, t - i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t + i] <= -1)
                        {
                            if (kill[k - i - 1, t + i + 1] == 0)
                            {
                                return true;
                            }
                            else break;
                        }
                        if (kill[k - i, t + i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t - i] <= -1)
                        {
                            if (kill[k + i + 1, t - i - 1] == 0)
                            {
                                return true;
                            }
                            else break;
                        }
                        if (kill[k + i, t - i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t + i] <= -1)
                        {
                            if (kill[k + i + 1, t + i + 1] == 0)
                            {
                                return true;
                            }
                            else break;
                        }
                        if (kill[k + i, t + i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
            }
            else
            {
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t - i] >= 1)
                        {
                            if (kill[k - i - 1, t - i - 1] == 0)
                            {
                                return true;
                            }
                            else break;
                        }
                        if (kill[k - i, t - i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t + i] >= 1)
                        {
                            if (kill[k - i - 1, t + i + 1] == 0)
                            {
                                return true;
                            }
                            else break;
                        }
                        if (kill[k - i, t - i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t - i] >= 1)
                        {
                            if (kill[k + i + 1, t - i - 1] == 0)
                            {
                                return true;
                            }
                            else break;
                        }
                        if (kill[k + i, t - i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t + i] >= 1)
                        {
                            if (kill[k + i + 1, t + i + 1] == 0)
                            {
                                return true;
                            }
                            else break;
                        }
                        if (kill[k + i, t + i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
            }
            return false;
        }

        public static bool DamTestKill(int step)
        {
            byte diff = 0;
            if (step == 1)
            {
                for (byte i = 0; i < m; i++)
                {
                    for (byte j = 0; j < n; j++)
                    {
                        if (kill[i, j] == 2)
                        {
                            try
                            {
                                for (byte k = 1; k <= 8; k++)
                                {
                                    if (kill[i - k, j - k] < 0)
                                    {
                                        diff = k;
                                        break;
                                    }
                                }
                                if (kill[i - diff, j - diff] < 0 && kill[i - diff - 1, j - diff - 1] == 0)
                                {
                                    return true;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                for (byte k = 1; k <= 8; k++)
                                {
                                    if (kill[i - k, j + k] < 0)
                                    {
                                        diff = k;
                                        break;
                                    }
                                }
                                if (kill[i - diff, j + diff] < 0 && kill[i - diff - 1, j + diff + 1] == 0)
                                {
                                    return true;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                for (byte k = 1; k <= 8; k++)
                                {
                                    if (kill[i + k, j - k] < 0)
                                    {
                                        diff = k;
                                        break;
                                    }
                                }
                                if (kill[i + diff, j - diff] < 0 && kill[i + diff + 1, j - diff - 1] == 0)
                                {
                                    return true;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                for (byte k = 1; k <= 8; k++)
                                {
                                    if (kill[i + k, j + k] < 0)
                                    {
                                        diff = k;
                                        break;
                                    }
                                }
                                if (kill[i + diff, j + diff] < 0 && kill[i + diff + 1, j + diff + 1] == 0)
                                {
                                    return true;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                        }
                    }
                }
            }
            else
            {
                for (byte i = 0; i < m; i++)
                {
                    for (byte j = 0; j < n; j++)
                    {
                        if (kill[i, j] == -2)
                        {
                            try
                            {
                                for (byte k = 1; k <= 8; k++)
                                {
                                    if (kill[i - k, j - k] > 0)
                                    {
                                        diff = k;
                                        break;
                                    }
                                }
                                if (kill[i - diff, j - diff] > 0 && kill[i - diff - 1, j - diff - 1] == 0)
                                {
                                    return true;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                for (byte k = 1; k <= 8; k++)
                                {
                                    if (kill[i - k, j + k] > 0)
                                    {
                                        diff = k;
                                        break;
                                    }
                                }
                                if (kill[i - diff, j + diff] > 0 && kill[i - diff - 1, j + diff + 1] == 0)
                                {
                                    return true;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                for (byte k = 1; k <= 8; k++)
                                {
                                    if (kill[i + k, j - k] > 0)
                                    {
                                        diff = k;
                                        break;
                                    }
                                }
                                if (kill[i + diff, j - diff] > 0 && kill[i + diff + 1, j - diff - 1] == 0)
                                {
                                    return true;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                for (byte k = 1; k <= 8; k++)
                                {
                                    if (kill[i + k, j + k] > 0)
                                    {
                                        diff = k;
                                        break;
                                    }
                                }
                                if (kill[i + diff, j + diff] > 0 && kill[i + diff + 1, j + diff + 1] == 0)
                                {
                                    return true;
                                }
                            }
                            catch (IndexOutOfRangeException) { }
                        }
                    }
                }
            }
            return false;
        }

        protected static void DamStepIn(int k, int t)
        {
            int p = -1;
            int v = -1;
            int[,] around = new int[2, 2];
            byte status = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    around[i, j] = 0;
                }
            }
            try
            {
                if (kill[k + 1, t - 1] == 0)
                {
                    status++;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            try
            {
                if (kill[k + 1, t + 1] == 0)
                {
                    status++;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            try
            {
                if (kill[k - 1, t - 1] == 0)
                {
                    status++;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            try
            {
                if (kill[k - 1, t + 1] == 0)
                {
                    status++;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            if (status == 0)
            {
                if (kill[k, t] > 0)
                {
                    WhitePlayer.WhiteStepFrom();
                    return;
                }
                if (kill[k, t] < 0)
                {
                    BlackPlayer.BlackStepFrom();
                    return;
                }

            }
            else
            {
                for(byte i = 0; i < m; i++)
                {
                    for(byte j = 0; j < n; j++)
                    {
                        posx[i, j] = 0;
                    }
                }
                try
                {
                    for (byte i = 1; i <= 8; i++)
                    {
                        if (kill[k - i, t - i] == 0)
                        {
                            posx[k - i, t - i] = 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    for (byte i = 1; i <= 8; i++)
                    {
                        if (kill[k - i, t + i] == 0)
                        {
                            posx[k - i, t + i] = 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    for (byte i = 1; i <= 8; i++)
                    {
                        if (kill[k + i, t - i] == 0)
                        {
                            posx[k + i, t - i] = 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    for (byte i = 1; i <= 8; i++)
                    {
                        if (kill[k + i, t + i] == 0)
                        {
                            posx[k + i, t + i] = 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            Field.PrintField(kill);
            ConsoleKey move = 0;
            while (1 == 1)
            {
                move = Console.ReadKey().Key;
                if (move == ConsoleKey.Enter) break;
                if (move == ConsoleKey.Escape)
                {
                    for (byte i = 0; i < m; i++)
                    {
                        for (byte j = 0; j < n; j++) 
                        {
                            posx[i, j] = 0;
                        }
                    }
                    Field.PrintField(kill);
                    if (kill[k, t] > 0)
                    {
                        WhitePlayer.WhiteStepFrom();
                        return;
                    }
                    if (kill[k, t] < 0) 
                    {
                        BlackPlayer.BlackStepFrom();
                        return;
                    }
                }
                if (move == ConsoleKey.UpArrow)
                {
                    kursY--;
                    if (kursY < 0) kursY = 0;
                    else
                    {
                        Field.PrintField(kill);
                    }
                }
                if (move == ConsoleKey.DownArrow)
                {
                    kursY++;
                    if (kursY > 7) kursY = 7;
                    else
                    {
                        Field.PrintField(kill);
                    }
                }
                if (move == ConsoleKey.LeftArrow)
                {
                    kursX--;
                    if (kursX < 0) kursX = 0;
                    else
                    {
                        Field.PrintField(kill);
                    }
                }
                if (move == ConsoleKey.RightArrow)
                {
                    kursX++;
                    if (kursX > 7) kursX = 7;
                    else
                    {
                        Field.PrintField(kill);
                    }
                }
            }
            p = kursX;
            v = kursY;
            if (kill[v, p] != 0 || posx[v, p] != 1) 
            {
                for (byte i = 0; i < m; i++)
                {
                    for (byte j = 0; j < n; j++)
                    {
                        posx[i, j] = 0;
                    }
                }
                DamStepIn(k, t);
                return;
            }
            else
            {
                if (posx[v, p] == 1)
                {
                    if (kill[k, t] > 0)
                    {
                        kill[k, t] = 0;
                        kill[v, p] = 2;
                    }
                    if (kill[k, t] < 0) 
                    {
                        kill[k, t] = 0;
                        kill[v, p] = -2;
                    }
                }
            }
            for(byte i = 0; i < m; i++)
            {
                for(byte j = 0; j < n; j++)
                {
                    posx[i, j] = 0;
                }
            }
            if (kill[v, p] > 0)
            {
                Field.PrintAfterStep(kill, 2);
            }
            else
            {
                Field.PrintAfterStep(kill, 1);
            }
        }

        protected static void Kill(int t, int k, int p, int v)
        {
            if (kill[k, t] > 0)
            {
                if (p < t)
                {
                    kill[k + 1, t - 1] = 0;
                }
                else
                {
                    kill[k + 1, t + 1] = 0;
                }
                kill[k, t] = 0;
                kill[v, p] = 1;
                Field.countRed--;
            }
            else
            {
                if (p < t)
                {
                    kill[k - 1, t - 1] = 0;
                }
                else
                {
                    kill[k - 1, t + 1] = 0;
                }
                kill[k, t] = 0;
                kill[v, p] = -1;
                Field.countBlue--;
            }

        }
        protected static void Kill(int t, int k, int p, int v, int f)
        {
            if (f == 1)
            {
                if (t > p)
                {
                    kill[k, t] = 0;
                    kill[v, p] = -1;
                    Field.countBlue--;
                    if (k > v)
                    {
                        kill[k - 1, t - 1] = 0;
                    }
                    else
                    {

                        kill[k + 1, t - 1] = 0;
                    }
                }
                else
                {
                    kill[k, t] = 0;
                    kill[v, p] = -1;
                    Field.countBlue--;
                    if (k > v)
                    {
                        kill[k - 1, t + 1] = 0;
                    }
                    else
                    {
                        kill[k + 1, t + 1] = 0;
                    }
                }
            }
            else
            {
                if (t > p)
                {
                    kill[k, t] = 0;
                    kill[v, p] = 1;
                    Field.countRed--;
                    if (k > v)
                    {
                        kill[k - 1, t - 1] = 0;
                    }
                    else
                    {

                        kill[k + 1, t - 1] = 0;
                    }
                }
                else
                {
                    kill[k, t] = 0;
                    kill[v, p] = 1;
                    Field.countRed--;
                    if (k > v)
                    {
                        kill[k - 1, t + 1] = 0;
                    }
                    else
                    {
                        kill[k + 1, t + 1] = 0;
                    }
                }
            }
        }

        protected static bool ResetKill(int k, int t)
        {
            bool result = false;
            byte i = 1;
            if (kill[k, t] > 0)
            {
                try
                {
                    if (kill[k - 1, t - 1] < 0 && kill[k - 2, t - 2] == 0)
                    {
                        //Console.WriteLine("Вы должны продолжить и срубить красную шашку из " + (t + 1) + " , " + (k + 1) + " в " + (t - 1) + " , " + (k - 1));
                        resetKill[i, 0] = k;
                        resetKill[i, 1] = t;
                        resetKill[i, 2] = k - 2;
                        resetKill[i, 3] = t - 2;
                        i++;
                        result = true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (kill[k - 1, t + 1] < 0 && kill[k - 2, t + 2] == 0)
                    {
                        //Console.WriteLine("Вы должны продолжить и срубить красную шашку из " + (t + 1) + " , " + (k + 1) + " в " + (t + 3) + " , " + (k - 1));
                        resetKill[i, 0] = k;
                        resetKill[i, 1] = t;
                        resetKill[i, 2] = k - 2;
                        resetKill[i, 3] = t + 2;
                        i++;
                        result = true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (kill[k + 1, t - 1] < 0 && kill[k + 2, t - 2] == 0)
                    {
                        //Console.WriteLine("Вы должны продолжить и срубить красную шашку из " + (t + 1) + " , " + (k + 1) + " в " + (t - 1) + " , " + (k + 3));
                        resetKill[i, 0] = k;
                        resetKill[i, 1] = t;
                        resetKill[i, 2] = k + 2;
                        resetKill[i, 3] = t - 2;
                        i++;
                        result = true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (kill[k + 1, t + 1] < 0 && kill[k + 2, t + 2] == 0)
                    {
                        //Console.WriteLine("Вы должны продолжить и срубить красную шашку из " + (t + 1) + " , " + (k + 1) + " в " + (t + 3) + " , " + (k + 3));
                        resetKill[i, 0] = k;
                        resetKill[i, 1] = t;
                        resetKill[i, 2] = k + 2;
                        resetKill[i, 3] = t + 2;
                        i++;
                        result = true;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            else
            {
                try
                {
                    if (kill[k - 1, t - 1] > 0 && kill[k - 2, t - 2] == 0)
                    {
                        //Console.WriteLine("Вы должны продолжить и срубить синюю шашку из " + (t + 1) + " , " + (k + 1) + " в " + (t - 1) + " , " + (k - 1));
                        resetKill[i, 0] = k;
                        resetKill[i, 1] = t;
                        resetKill[i, 2] = k - 2;
                        resetKill[i, 3] = t - 2;
                        i++;
                        result = true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (kill[k - 1, t + 1] > 0 && kill[k - 2, t + 2] == 0)
                    {
                        //Console.WriteLine("Вы должны продолжить и срубить синюю шашку из " + (t + 1) + " , " + (k + 1) + " в " + (t + 3) + " , " + (k - 1));
                        resetKill[i, 0] = k;
                        resetKill[i, 1] = t;
                        resetKill[i, 2] = k - 2;
                        resetKill[i, 3] = t + 2;
                        i++;
                        result = true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (kill[k + 1, t - 1] > 0 && kill[k + 2, t - 2] == 0)
                    {
                        //Console.WriteLine("Вы должны продолжить и срубить синюю шашку из " + (t + 1) + " , " + (k + 1) + " в " + (t - 1) + " , " + (k + 3));
                        resetKill[i, 0] = k;
                        resetKill[i, 1] = t;
                        resetKill[i, 2] = k + 2;
                        resetKill[i, 3] = t - 2;
                        i++;
                        result = true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (kill[k + 1, t + 1] > 0 && kill[k + 2, t + 2] == 0)
                    {
                        //Console.WriteLine("Вы должны продолжить и срубить синюю шашку из " + (t + 1) + " , " + (k + 1) + " в " + (t + 3) + " , " + (k + 3));
                        resetKill[i, 0] = k;
                        resetKill[i, 1] = t;
                        resetKill[i, 2] = k + 2;
                        resetKill[i, 3] = t + 2;
                        i++;
                        result = true;
                    }
                }
                catch (IndexOutOfRangeException) { }

            }
            return result;
        }

        protected static void DamKill(byte step)
        {
            int k, t, v, p;
            ConsoleKey move = 0;
            while (1 == 1)
            {
                move = Console.ReadKey().Key;
                if (move == ConsoleKey.Enter) break;
                if (move == ConsoleKey.UpArrow)
                {
                    kursY--;
                    if (kursY < 0) kursY = 0;
                    else
                    {
                        Field.PrintField(kill);
                    }
                }
                if (move == ConsoleKey.DownArrow)
                {
                    kursY++;
                    if (kursY > 7) kursY = 7;
                    else
                    {
                        Field.PrintField(kill);
                    }
                }
                if (move == ConsoleKey.LeftArrow)
                {
                    kursX--;
                    if (kursX < 0) kursX = 0;
                    else
                    {
                        Field.PrintField(kill);
                    }
                }
                if (move == ConsoleKey.RightArrow)
                {
                    kursX++;
                    if (kursX > 7) kursX = 7;
                    else
                    {
                        Field.PrintField(kill);
                    }
                }
            }
            t = kursX;
            k = kursY;
            p = -1;
            v = -1;
            for (byte i = 0; i < m; i++)
            {
                for (byte j = 0; j < n; j++)
                {
                    posx[i, j] = 0;
                }
            }
            if (step == 1 && kill[k, t] != 2) 
            {
                Field.PrintKillField(kill);
                DamKill(1);
                return;
            }
            if (step == 2 && kill[k, t] != -2)
            {
                Field.PrintKillField(kill);
                DamKill(2);
                return;
            }
            if (!SelectDamTestKill(k, t))
            {
                Field.PrintKillField(kill);
                if (step == 1)
                {
                    DamKill(1);
                    return;
                }
                else
                {
                    DamKill(2);
                    return;
                }
            }
            if (step == 1)
            {
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t - i] <= -1)
                        {
                            if (kill[k - i - 1, t - i - 1] == 0)
                            {
                                posx[k - i, t - i] = 3;
                                posx[k - i - 1, t - i - 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k - i, t - i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t + i] <= -1)
                        {
                            if (kill[k - i - 1, t + i + 1] == 0)
                            {
                                posx[k - i, t + i] = 3;
                                posx[k - i - 1, t + i + 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k - i, t + i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t - i] <= -1)
                        {
                            if (kill[k + i + 1, t - i - 1] == 0)
                            {
                                posx[k + i, t - i] = 3;
                                posx[k + i + 1, t - i - 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k + i, t - i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t + i] <= -1)
                        {
                            if (kill[k + i + 1, t + i + 1] == 0)
                            {
                                posx[k + i, t + i] = 3;
                                posx[k + i + 1, t + i + 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k + i, t + i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
            }
            else
            {
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t - i] >= 1)
                        {
                            if (kill[k - i - 1, t - i - 1] == 0)
                            {
                                posx[k - i, t - i] = 3;
                                posx[k - i - 1, t - i - 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k - i, t - i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t + i] >= 1)
                        {
                            if (kill[k - i - 1, t + i + 1] == 0)
                            {
                                posx[k - i, t + i] = 3;
                                posx[k - i - 1, t + i + 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k - i, t - i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t - i] >= 1)
                        {
                            if (kill[k + i + 1, t - i - 1] == 0)
                            {
                                posx[k + i, t - i] = 3;
                                posx[k + i + 1, t - i - 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k + i, t - i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t + i] >= 1)
                        {
                            if (kill[k + i + 1, t + i + 1] == 0)
                            {
                                posx[k + i, t + i] = 3;
                                posx[k + i + 1, t + i + 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k + i, t + i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
            }
            bool fl = false;
            for(byte i = 0; i < m; i++)
            {
                for(byte j = 0; j < n; j++)
                {
                    if (posx[i, j] != 0) fl = true;
                }
                if (fl) break;
            }
            if (!fl)
            {
                Field.PrintKillField(kill);
                if (step == 1)
                {
                    DamKill(1);
                    return;
                }
                else
                {
                    DamKill(2);
                    return;
                }
            }
            Field.PrintField(kill);
            p = kursX;
            v = kursY;
            try
            {
                while (posx[v, p] != 2)
                {
                    while (1 == 1)
                    {
                        move = Console.ReadKey().Key;
                        if (move == ConsoleKey.Enter) break;
                        if (move == ConsoleKey.Escape)
                        {
                            for (byte i = 0; i < 8; i++)
                            {
                                for (byte j = 0; j < 8; j++)
                                {
                                    posx[i, j] = 0;
                                }
                            }
                            Field.PrintField(kill);
                            if (step == 1)
                            {
                                DamKill(1);
                                return;
                            }
                            else
                            {
                                DamKill(2);
                                return;
                            }
                        }
                        if (move == ConsoleKey.UpArrow)
                        {
                            kursY--;
                            if (kursY < 0) kursY = 0;
                            else
                            {
                                Field.PrintField(kill);
                            }
                        }
                        if (move == ConsoleKey.DownArrow)
                        {
                            kursY++;
                            if (kursY > 7) kursY = 7;
                            else
                            {
                                Field.PrintField(kill);
                            }
                        }
                        if (move == ConsoleKey.LeftArrow)
                        {
                            kursX--;
                            if (kursX < 0) kursX = 0;
                            else
                            {
                                Field.PrintField(kill);
                            }
                        }
                        if (move == ConsoleKey.RightArrow)
                        {
                            kursX++;
                            if (kursX > 7) kursX = 7;
                            else
                            {
                                Field.PrintField(kill);
                            }
                        }
                    }
                    p = kursX;
                    v = kursY;
                    if (posx[v, p] != 2) Field.PrintKillField(kill);
                    else break;
                }
            }
            catch (IndexOutOfRangeException) { }
            
            
            if (kill[k, t] > 1)
            {
                kill[k, t] = 0;
                kill[v, p] = 2;
                Field.countRed--;
                try
                {
                    if (posx[v - 1, p - 1] == 3)
                    {
                        kill[v - 1, p - 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v - 1, p + 1] == 3)
                    {
                        kill[v - 1, p + 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v + 1, p - 1] == 3)
                    {
                        kill[v + 1, p - 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v + 1, p + 1] == 3)
                    {
                        kill[v + 1, p + 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            if (kill[k, t] < -1)
            {
                kill[k, t] = 0;
                kill[v, p] = -2;
                Field.countBlue--;
                try
                {
                    if (posx[v - 1, p - 1] == 3)
                    {
                        kill[v - 1, p - 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v - 1, p + 1] == 3)
                    {
                        kill[v - 1, p + 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v + 1, p - 1] == 3)
                    {
                        kill[v + 1, p - 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v + 1, p + 1] == 3)
                    {
                        kill[v + 1, p + 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            for(byte i = 0; i < m; i++)
            {
                for(byte j = 0; j < n; j++)
                {
                    posx[i, j] = 0;
                }
            }
            RepeatP = p;
            RepeatV = v;
            while (SelectDamTestKill(RepeatV, RepeatP) && !test)
            {
                Field.PrintField(kill);
                if (kill[RepeatV, RepeatP] == 2)
                {
                    DamKill(RepeatV, RepeatP, 1);
                    for (byte i = 0; i < m; i++)
                    {
                        for (byte j = 0; j < n; j++)
                        {
                            posx[i, j] = 0;
                        }
                    }
                }
                if (kill[RepeatV, RepeatP] == -2)
                {
                    DamKill(RepeatV, RepeatP, 2);
                    for (byte i = 0; i < m; i++)
                    {
                        for (byte j = 0; j < n; j++)
                        {
                            posx[i, j] = 0;
                        }
                    }
                }
            }
            test = false;
            for (byte i = 0; i < m; i++)
            {
                for (byte j = 0; j < n; j++)
                {
                    posx[i, j] = 0;
                }
            }
            if (step == 1)
            {
                Field.PrintAfterStep(kill, 2);
                return;
            }
            else
            {
                Field.PrintAfterStep(kill, 1);
                return;
            }
        }

        protected static void DamKill(int k, int t, byte step)
        {
            int p = -1;
            int v = -1;
            for (byte i = 0; i < m; i++)
            {
                for (byte j = 0; j < n; j++)
                {
                    posx[i, j] = 0;
                }
            }
            if (step == 1)
            {
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t - i] <= -1)
                        {
                            if (kill[k - i - 1, t - i - 1] == 0)
                            {
                                posx[k - i, t - i] = 3;
                                posx[k - i - 1, t - i - 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k - i, t - i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t + i] <= -1)
                        {
                            if (kill[k - i - 1, t + i + 1] == 0)
                            {
                                posx[k - i, t + i] = 3;
                                posx[k - i - 1, t + i + 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k - i, t + i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t - i] <= -1)
                        {
                            if (kill[k + i + 1, t - i - 1] == 0)
                            {
                                posx[k + i, t - i] = 3;
                                posx[k + i + 1, t - i - 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k + i, t - i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t + i] <= -1)
                        {
                            if (kill[k + i + 1, t + i + 1] == 0)
                            {
                                posx[k + i, t + i] = 3;
                                posx[k + i + 1, t + i + 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k + i, t + i] > 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
            }
            else
            {
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t - i] >= 1)
                        {
                            if (kill[k - i - 1, t - i - 1] == 0)
                            {
                                posx[k - i, t - i] = 3;
                                posx[k - i - 1, t - i - 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k - i, t - i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k - i, t + i] >= 1)
                        {
                            if (kill[k - i - 1, t + i + 1] == 0)
                            {
                                posx[k - i, t + i] = 3;
                                posx[k - i - 1, t + i + 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k - i, t - i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t - i] >= 1)
                        {
                            if (kill[k + i + 1, t - i - 1] == 0)
                            {
                                posx[k + i, t - i] = 3;
                                posx[k + i + 1, t - i - 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k + i, t - i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
                try
                {
                    for (byte i = 1; i <= n; i++)
                    {
                        if (kill[k + i, t + i] >= 1)
                        {
                            if (kill[k + i + 1, t + i + 1] == 0)
                            {
                                posx[k + i, t + i] = 3;
                                posx[k + i + 1, t + i + 1] = 2;
                                break;
                            }
                            else break;
                        }
                        if (kill[k + i, t + i] < 0) break;
                    }
                }
                catch (IndexOutOfRangeException) { };
            }
            Field.PrintField(kill);
            p = kursX;
            v = kursY;
            ConsoleKey move = 0;
            try
            {
                while (posx[v, p] != 2)
                {
                    while (1 == 1)
                    {
                        move = Console.ReadKey().Key;
                        if (move == ConsoleKey.Enter) break;
                        if (move == ConsoleKey.Escape)
                        {
                            for (byte i = 0; i < 8; i++)
                            {
                                for (byte j = 0; j < 8; j++)
                                {
                                    posx[i, j] = 0;
                                }
                            }
                            if (step == 1)
                            {
                                test = true;
                                for(byte i = 0; i < m; i++)
                                {
                                    for(byte j = 0; j < n; j++)
                                    {
                                        posx[i, j] = 0;
                                    }
                                }
                                return;
                            }
                            else
                            {
                                test = true;
                                for (byte i = 0; i < m; i++)
                                {
                                    for (byte j = 0; j < n; j++)
                                    {
                                        posx[i, j] = 0;
                                    }
                                }
                                return;
                            }
                        }
                        if (move == ConsoleKey.UpArrow)
                        {
                            kursY--;
                            if (kursY < 0) kursY = 0;
                            else
                            {
                                Field.PrintField(kill);
                            }
                        }
                        if (move == ConsoleKey.DownArrow)
                        {
                            kursY++;
                            if (kursY > 7) kursY = 7;
                            else
                            {
                                Field.PrintField(kill);
                            }
                        }
                        if (move == ConsoleKey.LeftArrow)
                        {
                            kursX--;
                            if (kursX < 0) kursX = 0;
                            else
                            {
                                Field.PrintField(kill);
                            }
                        }
                        if (move == ConsoleKey.RightArrow)
                        {
                            kursX++;
                            if (kursX > 7) kursX = 7;
                            else
                            {
                                Field.PrintField(kill);
                            }
                        }
                    }
                    p = kursX;
                    v = kursY;
                    if (posx[v, p] != 2) Field.PrintKillField(kill);
                    else break;
                }
            }
            catch (IndexOutOfRangeException) { }
            Field.PrintField(kill);

            if (kill[k, t] > 1)
            {
                kill[k, t] = 0;
                kill[v, p] = 2;
                Field.countRed--;
                try
                {
                    if (posx[v - 1, p - 1] == 3)
                    {
                        kill[v - 1, p - 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v - 1, p + 1] == 3)
                    {
                        kill[v - 1, p + 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v + 1, p - 1] == 3)
                    {
                        kill[v + 1, p - 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v + 1, p + 1] == 3)
                    {
                        kill[v + 1, p + 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            if (kill[k, t] < -1)
            {
                kill[k, t] = 0;
                kill[v, p] = -2;
                Field.countBlue--;
                try
                {
                    if (posx[v - 1, p - 1] == 3)
                    {
                        kill[v - 1, p - 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v - 1, p + 1] == 3)
                    {
                        kill[v - 1, p + 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v + 1, p - 1] == 3)
                    {
                        kill[v + 1, p - 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (posx[v + 1, p + 1] == 3)
                    {
                        kill[v + 1, p + 1] = 0;
                    }
                }
                catch (IndexOutOfRangeException) { }
            }
            for (byte i = 0; i < m; i++)
            {
                for (byte j = 0; j < n; j++)
                {
                    posx[i, j] = 0;
                }
            }
            RepeatP = p;
            RepeatV = v;
        }
    }
}
