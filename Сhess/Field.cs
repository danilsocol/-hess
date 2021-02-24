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

            int[] selectCell = { 0, 0 };
            int[] pastSelectCell = { 0, 0 };
            string[] movementOfTheFigures = new string[2];

            while (true)
            {
                WorkConsole.WriteField(cell);

                SelectCell(selectCell,cell, pastSelectCell, movementOfTheFigures);

                FigureMove.MakeMove(movementOfTheFigures, cell);
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


        public static void SelectCell(int[] selectCell, string[,] cell, int[] pastSelectCell,string[] movementOfTheFigures)
        {
            bool IsTheShapeSelected = true;

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.DownArrow && selectCell[1] < 7) selectCell[1]++;
                if (key == ConsoleKey.UpArrow && selectCell[1] > 0) selectCell[1]--;
                if (key == ConsoleKey.RightArrow && selectCell[0] < 7) selectCell[0]++;
                if (key == ConsoleKey.LeftArrow && selectCell[0] > 0) selectCell[0]--;

                WorkConsole.WriteChoiceCell(selectCell, cell, pastSelectCell);


                if (key == ConsoleKey.Enter && !IsTheShapeSelected)
                {
                    movementOfTheFigures[1] = $"{selectCell[0]}{selectCell[1]}";
                    break;
                }

                if (key == ConsoleKey.Enter && IsTheShapeSelected && FigureMove.RecognitionFigureInCell(cell, $"{selectCell[0]}{selectCell[1]}"))
                {
                    movementOfTheFigures[0] = $"{selectCell[0]}{selectCell[1]}";
                    IsTheShapeSelected = false;
                }
            }
        }
    }
}
