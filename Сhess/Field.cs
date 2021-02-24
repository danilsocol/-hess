using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Field
    {
        public void CreateField()
        {
            string[,] cell = new string[8, 8];

            PlacementOfFigure(cell);

            int[] select = { 0, 0 };
            int[] pastSelect = { 0, 0 };
            string[] move = new string[2];

            while (true)
            {
                //string[] move = WorkConsole.WriteField(cell);
                WorkConsole.WriteField(cell);

                SelectCell(select,cell, pastSelect, move);


                FigureMove.SelectingFigure(move, cell);
            }

        }

        void PlacementOfFigure(string[,] cell)
        {

            for(int i = 0; i < 8; i++)
            {
                cell[i, 1] = "P";// пешка
                cell[i, 6] = "P";
            }

            cell[0, 0] = "R";// Башня
            cell[0, 7] = "R";
            cell[7, 0] = "R";// Башня
            cell[7, 7] = "R";

            cell[1, 0] = "H";// конь
            cell[1, 7] = "H";
            cell[6, 0] = "H";// конь
            cell[6, 7] = "H";

            cell[2, 0] = "B";// слон
            cell[2, 7] = "B";
            cell[5, 0] = "B";// слон
            cell[5, 7] = "B";

            cell[3, 0] = "Q";// КОРОЛЕВА
            cell[3, 7] = "Q";

            cell[4, 0] = "K";// КОРОЛь
            cell[4, 7] = "K";
        }


        public static void SelectCell(int[] select, string[,] cell, int[] pastSelect,string[] move)
        {
            bool start = true;

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.DownArrow && select[1] < 7) select[1]++;
                if (key == ConsoleKey.UpArrow && select[1] > 0) select[1]--;
                if (key == ConsoleKey.RightArrow && select[0] < 7) select[0]++;
                if (key == ConsoleKey.LeftArrow && select[0] > 0) select[0]--;

                WorkConsole.WriteChoiceCell(select, cell, pastSelect);


                if (key == ConsoleKey.Enter && !start)
                {
                    move[1] = $"{select[0]}{select[1]}";
                    break;
                }

                if (key == ConsoleKey.Enter && start)
                {
                    move[0] = $"{select[0]}{select[1]}";
                    start = false;
                }
            }
        }
    }
}
