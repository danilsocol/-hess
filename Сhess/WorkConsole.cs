﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class WorkConsole
    {
        public static void ReadMenu(int menuSelect)
        {
            int menuCounter = 0;

            ReadFream("   Chess   ", menuSelect, menuCounter);
            Console.WriteLine("\n");
            menuCounter++;

            ReadFream(" Новая игра ", menuSelect, menuCounter);
            Console.WriteLine("");
            menuCounter++;

            ReadFream(" Продолжить ", menuSelect, menuCounter);
            Console.WriteLine("");
            menuCounter++;

            ReadFream(" Рейтинг    ", menuSelect, menuCounter);
            Console.WriteLine("");
            menuCounter++;

            ReadFream(" Выход      ", menuSelect, menuCounter);
            Console.WriteLine("");
        }
        public static void ReadFream(string text, int menuSelect, int menuCounter)
        {
            int numSpace = 50;

            string line = "";
            for (int i = 0; i < text.Length; i++)
                line += '═';

            CreateSpace(numSpace, menuSelect, menuCounter);
            Сell('╔', line, '╗');

            CreateSpace(numSpace, menuSelect, menuCounter);
            Сell('║', text, '║');

            CreateSpace(numSpace, menuSelect, menuCounter);
            Сell('╚', line, '╝');
        }

        public static void Сell(char oneChar, string text, char twoChar)
        {
            Console.Write(oneChar);
            Console.Write(text);
            Console.WriteLine(twoChar);

            Console.ResetColor();
        }
        public static void CreateSpace(int numSpace, int menuSelect, int menuCounter)
        {
            for (int i = 0; i < numSpace; i++)
                Console.Write(" ");

            if (menuSelect == menuCounter)
                Console.BackgroundColor = ConsoleColor.Red;
        }
        public static string ReadName()
        {
            Console.WriteLine("Введите имя первого игрока, а затем второго");
            return Console.ReadLine();
        }
        public static void WriteField(string[,] cell)
        {
            Console.SetCursorPosition(0, 0);
            WriteFieldLine("┌", "─", "┬", "┐", 8);
            Console.WriteLine();

            for (int y = 0; y < 8; y++)
            {
                Console.Write('│');
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(" ");

                    if (cell[x, y] == null)
                    {
                        cell[x, y] = " ";
                    }

                    Console.Write(cell[x, y] + " │");
                }
                Console.WriteLine();

                WriteFieldLine("├", "─", "┼", "┤", 8);
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            WriteFieldLine("└", "─", "┴", "┘", 8);

        }
        static void WriteFieldLine(string char1, string char2, string char3, string char4, int num)
        {
            Console.Write(char1 + char2 + char2 + char2);

            for (int i = 0; i < num - 1; i++)
                Console.Write(char3 + char2 + char2 + char2);

            Console.Write(char4);
        }
        
        public static void Error()
        {
            Console.Clear();
            Console.WriteLine("Ошибка");
        }

        public static void WriteChoiceCell(int[] selectCell, string[,] cell, int[] pastSelectCell)
        {
            Console.SetCursorPosition(pastSelectCell[0] * 4 + 2, pastSelectCell[1] * 2 + 1);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"{cell[pastSelectCell[0], pastSelectCell[1]]}");
            Console.ResetColor();


            Console.SetCursorPosition(selectCell[0] * 4 + 2, selectCell[1] * 2 + 1);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write($"{cell[selectCell[0], selectCell[1]]}");
            Console.ResetColor();

            pastSelectCell[0] = selectCell[0];
            pastSelectCell[1] = selectCell[1];
        }
    }
}
