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
        public static void WriteField(string[,] figure)
        {
            WriteFieldLine("┌", "─", "┬", "┐", 8);
            Console.WriteLine();

            for (int y = 0; y < 8; y++)
            {
                Console.Write('│');
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(" ");

                    if(figure[x, y] == null)
                    {
                        figure[x, y] = " ";
                    }

                    Console.Write(figure[x, y] + " │");
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
    }
}
