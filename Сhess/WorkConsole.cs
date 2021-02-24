using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class WorkConsole
    {
        public static void ReadMenu(int select)
        {
            int counter = 0;

            ReadFream("   Chess   ", select, counter);
            Console.WriteLine("\n");
            counter++;

            ReadFream(" Новая игра ", select, counter);
            Console.WriteLine("");
            counter++;

            ReadFream(" Продолжить ", select, counter);
            Console.WriteLine("");
            counter++;

            ReadFream(" Рейтинг    ", select, counter);
            Console.WriteLine("");
            counter++;

            ReadFream(" Выход      ", select, counter);
            Console.WriteLine("");
        }
        public static void ReadFream(string text, int select, int counter)
        {
            int numSpace = 50;

            string line = "";
            for (int i = 0; i < text.Length; i++)
                line += '═';

            CreateSpace(numSpace, select, counter);
            Сell('╔', line, '╗');

            CreateSpace(numSpace, select, counter);
            Сell('║', text, '║');

            CreateSpace(numSpace, select, counter);
            Сell('╚', line, '╝');
        }

        public static void Сell(char oneChar, string text, char twoChar)
        {
            Console.Write(oneChar);
            Console.Write(text);
            Console.WriteLine(twoChar);

            Console.ResetColor();
        }
        public static void CreateSpace(int numSpace, int select, int counter)
        {
            for (int i = 0; i < numSpace; i++)
                Console.Write(" ");

            if (select == counter)
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

           // return ReadСoordinates(select);
        }
        static void WriteFieldLine(string char1, string char2, string char3, string char4, int num)
        {
            Console.Write(char1 + char2 + char2 + char2);

            for (int i = 0; i < num - 1; i++)
                Console.Write(char3 + char2 + char2 + char2);

            Console.Write(char4);
        }
        static string[] ReadСoordinates(int[] select)
        {
            string[] move = new string[2];

            while (true)
            {
                // Console.SetCursorPosition(select[0] * 4 + 3, select[1] * 2 + 1);


                Console.SetCursorPosition(34, 1);
                Console.Write("Введите координаты фигуры (А5): ");
                move[0] = Console.ReadLine();
                // move[0] = $"{ select[0] - 1}{select[1] - 1}";


                Console.SetCursorPosition(34, 3);
                Console.Write("Введите координаты куда хотите сходить (А6): ");
                move[1] = Console.ReadLine();

                if (FigureMove.IsCorrectCoordinate(move[0]) && FigureMove.IsCorrectCoordinate(move[1]))
                {
                    return move;
                }
            }
        }
        public static void Error()
        {
            Console.Clear();
            Console.WriteLine("Ошибка");
        }

        public static void WriteChoiceCell(int[] select, string[,] cell, int[] pastSelect)
        {
            Console.SetCursorPosition(pastSelect[0] * 4 + 1, pastSelect[1] * 2 + 1);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($" {cell[pastSelect[0], pastSelect[1]]}");
            Console.ResetColor();



            Console.SetCursorPosition(select[0] * 4 + 1, select[1] * 2 + 1);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($" {cell[select[0], select[1]]}");
            Console.ResetColor();

            pastSelect[0] = select[0];
            pastSelect[1] = select[1];
        }
    }
}
