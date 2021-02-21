using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Field
    {
        public void CreateField()
        {
            string[,] cell = new string[8,8];

            PlacementOfFigure(cell);

            WorkConsole.WriteField(cell);
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
    }
}
