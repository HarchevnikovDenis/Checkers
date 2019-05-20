using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCheckers
{
    class WhitePlayer : Player
    {
        public static void WhiteStepFrom()
        {
            //Field.PrintField(kill);
            ConsoleKey move = 0;
            byte coun = 0;
            for(byte i = 0; i < m; i++)
            {
                for(byte j = 0; j < n; j++)
                {
                    posx[i, j] = 0;
                }
            }
            if (!WhiteTestKill() && !DamTestKill(1))
            {
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
                int t = kursX;
                int k = kursY;
                int[] firstCoord = new int[2];
                firstCoord[0] = k;
                firstCoord[1] = t;
                if (kill[k, t] == 1)
                {
                    WhiteStepIn(firstCoord);
                    return;
                }
                else
                {
                    if (kill[k, t] == 2)
                    {
                        DamStepIn(k, t);
                        return;
                    }
                    else
                    {
                        WhiteStepFrom();
                        return;
                    }
                }
            }
            else
            {
                if (DamTestKill(1))
                {
                    DamKill(1);
                    return;
                }
                else
                {
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
                    int t = kursX;
                    int k = kursY;
                    for (byte j = 0; j < 12; j++)
                    {
                        if (t + 1 == killFrom[j, 0] && k + 1 == killFrom[j, 1])
                        {
                            coun = j;
                            break;
                        }
                        else if (j == 1 && (t + 1 != killFrom[j, 0] || k + 1 != killFrom[j, 1]))
                        {
                            Field.PrintKillField(kill);
                            WhiteStepFrom();
                            return;
                        }
                    }
                    posx[killIn[coun, 1] - 1, killIn[coun, 0] - 1] = 2;
                    Field.PrintField(kill);

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
                            WhiteStepFrom();
                            return;
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
                    int p = kursX + 1;
                    int v = kursY + 1;
                    if (p != killIn[coun, 0] || v != killIn[coun, 1])
                    {
                        for (byte i = 0; i < m; i++)
                        {
                            for(byte j=0; j < n; j++)
                            {
                                posx[i, j] = 0;
                            }
                        }
                        WhiteStepFrom();
                        return;
                    }
                    p--;
                    v--;
                    Kill(t, k, p, v);
                    Field.PrintField(kill);
                    for (byte i = 0; i < 4; i++)
                    {
                        for (byte j = 0; j < 4; j++)
                        {
                            resetKill[i, j] = 0;
                        }
                    }
                    while (ResetKill(v, p))
                    {
                        int[] ind = new int[4];
                        for (byte i = 0; i < 4; i++)
                        {
                            ind[i] = 0;
                        }
                        int q = 0;
                        for (byte i = 0; i < 4; i++)
                        {
                            if (resetKill[i, 0] == v && resetKill[i, 1] == p)
                            {
                                ind[q] = i;
                                q++;
                            }
                        }
                        k = v;
                        t = p;
                        v = -1;
                        p = -1;
                        for (byte i = 0; i < m; i++)
                        {
                            for (byte j = 0; j < n; j++)
                            {
                                posx[i, j] = 0;
                            }
                        }
                        for (byte i = 0; i < 4; i++)
                        {
                            if (Field.field[resetKill[ind[i], 2], resetKill[ind[i], 3]])
                            {
                                posx[resetKill[ind[i], 2], resetKill[ind[i], 3]] = 2;
                            }
                        }
                        Field.PrintField(kill);
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
                                Field.PrintAfterStep(kill, 2);
                                return;
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
                        
                        if (posx[v, p] == 2)
                        {
                            Kill(t, k, p, v, 2);
                            Field.PrintField(kill);
                        }
                        else
                        {
                            WhiteStepFrom();
                            return;
                        }
                    }
                }
                for (byte i = 0; i < m; i++)
                {
                    for (byte j = 0; j < n; j++)
                    {
                        posx[i, j] = 0;
                    }
                }
                Field.PrintAfterStep(kill, 2);
            }
        }


        private static void WhiteStepIn(int[] arr)
        {
            int k = arr[0];
            int t = arr[1];
            int status = 0;
            bool cont = false;
            int[,] around = new int[2, 2];
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
            { }
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
            
            if (status > 0)
            {
                around[0, 0] = k + 1;
                around[0, 1] = t - 1;
                around[1, 0] = k + 1;
                around[1, 1] = t + 1;
                try
                {
                    if (kill[around[0, 0], around[0, 1]] != 0)
                    {
                        around[0, 0] = -10;
                        around[0, 1] = -10;
                    }

                }
                catch (IndexOutOfRangeException)
                {

                }
                try
                {
                    if (kill[around[1, 0], around[1, 1]] != 0)
                    {
                        around[1, 0] = -10;
                        around[1, 1] = -10;
                    }
                }
                catch (IndexOutOfRangeException)
                {

                }
                if ((around[0, 0] >= 8 || around[0, 1] >= 8) || (around[0, 1] < 0 || around[0, 0] < 0))
                {
                    around[0, 0] = -10;
                    around[0, 1] = -10;
                }
                if ((around[1, 0] >= 8 || around[1, 1] >= 8) || (around[1, 1] < 0 || around[1, 0] < 0))
                {
                    around[1, 0] = -10;
                    around[1, 1] = -10;
                }
                if (around[0, 0] != -10 && around[0, 1] != -10)
                {
                    posx[around[0, 0], around[0, 1]] = 1;
                }
                if (around[1, 0] != -10 && around[1, 1] != -10)
                {
                    posx[around[1, 0], around[1, 1]] = 1;
                }
                Field.PrintField(kill);
                cont = true;
            }
            else
            {
                //Console.WriteLine("Вы не можете пойти из этой точки");
                k = -1;
                t = -1;
                WhiteStepFrom();
                return;
            }
            if (cont)
            {
                ConsoleKey move = 0;
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
                        WhiteStepFrom();
                        return;
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
                int p = kursX;
                int v = kursY;
                if ((p != around[0, 1] && p != around[1, 1]) || (v != around[0, 0] && v != around[1, 0]) || kill[v, p] != 0)
                {
                    WhiteStepIn(arr);
                    return;
                }

                kill[k, t] = 0;
                if (Field.step % 2 != 0)
                {
                    kill[v, p] = 1;
                }
                else
                {
                    kill[v, p] = -1;
                }
                for (byte i = 0; i < 8; i++)
                {
                    for (byte j = 0; j < 8; j++)
                    {
                        posx[i, j] = 0;
                    }
                }
                Field.PrintAfterStep(kill, 2);
                for (byte i = 0; i < 4; i++)
                {
                    for (byte j = 0; j < 4; j++)
                    {
                        resetKill[i, j] = 0;
                    }
                }
                return;
            }
        }
        public static bool WhiteTestKill()
        {
            bool result = false;
            byte count = 0;

            for (byte i = 0; i < 12; i++)
            {
                for (byte j = 0; j < 2; j++)
                {
                    killFrom[i, j] = -10;
                    killIn[i, j] = -10;
                }
            }
            for (byte i = 0; i < m; i++)
            {
                for (byte j = 0; j < n; j++)
                {
                    if (kill[i, j] >= 1)
                    {
                        try
                        {
                            if (kill[i + 1, j - 1] <= -1)
                            {
                                if (Field.field[i + 2, j - 2] && kill[i + 2, j - 2] == 0)
                                {
                                    result = true;
                                    count++;
                                    //Console.WriteLine("Вы можете срубить красную шашку из " + (j + 1) + " , " + (i + 1) + " в " + (j - 1) + " , " + (i + 3));
                                    killFrom[count - 1, 0] = j + 1;
                                    killFrom[count - 1, 1] = i + 1;
                                    killIn[count - 1, 0] = j - 1;
                                    killIn[count - 1, 1] = i + 3;
                                }
                            }
                            //
                        }
                        catch (IndexOutOfRangeException) { }
                        try
                        {
                            if (kill[i + 1, j + 1] <= -1)
                            {
                                if (kill[i + 2, j + 2] == 0 && Field.field[i + 2, j + 2])
                                {
                                    result = true;
                                    count++;
                                    //Console.WriteLine("Вы можете срубить красную шашку из " + (j + 1) + " , " + (i + 1) + " в " + (j + 3) + " , " + (i + 3));
                                    killFrom[count - 1, 0] = j + 1;
                                    killFrom[count - 1, 1] = i + 1;
                                    killIn[count - 1, 0] = j + 3;
                                    killIn[count - 1, 1] = i + 3;
                                }
                            }
                        }
                        catch (IndexOutOfRangeException) { }
                    }
                }
            }
            return result;
        }
    }
}
