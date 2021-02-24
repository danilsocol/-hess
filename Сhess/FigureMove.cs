using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class FigureMove
    {
        public static void MakeMove(string[] move, string[,] cell)
        {
            string start = move[0];

            if (!RecognitionFigureInCell(cell, start))
                WorkConsole.Error();

            string end = move[1];

            bool isCorrect = CheckCorrectOfTheMove(cell, start,end);

            int StartHorizontalCood = start[1] - 48;
            int StartVerticalCoord = start[0] - 48;

            int EndHorizontalCood = end[1] - 48;
            int EndVerticalCoord = end[0] - 48;

            if (isCorrect)
            {
                string pickFigure = cell[StartVerticalCoord, StartHorizontalCood];
                cell[StartVerticalCoord, StartHorizontalCood] = null;
                cell[EndVerticalCoord, EndHorizontalCood] = pickFigure;
            }
            else
                WorkConsole.Error();
        }

        static bool CheckCorrectOfTheMove(string[,] cell, string start, string end)
        {

            bool isCorrect = false;

            switch (cell[start[0] - 48, start[1] - 48])
            {
                case ("H"):
                    isCorrect = IsKnightCorrect(start, end);
                    break;

                case "P":
                    isCorrect = IsPawnCorrect(start, end);
                    break;

                case ("R"):
                    isCorrect = IsRookCorrect(start, end);
                    break;

                case ("Q"):
                    isCorrect = IsQueenCorrect(start, end);
                    break;

                case ("K"):
                    isCorrect = IsKingCorrect(start, end);
                    break;

                case ("B"):
                    isCorrect = IsBishopCorrect(start, end);
                    break;
            }
            return isCorrect;
        }

        private static bool IsKnightCorrect(string start, string end)
        {
            int dx = Math.Abs(end[0] - start[0]);
            int dy = Math.Abs(end[1] - start[1]);

            return dx + dy == 3 && dx * dy == 2;
        }

        private static bool IsPawnCorrect(string start, string end)
        {
            return (end[0] - start[0] == 0 && end[1] - start[1] == 1);
        }

        private static bool IsRookCorrect(string start, string end)
        {
            return (end[0] == start[0] && end[1] != start[1] || end[0] != start[0] && end[1] == start[1]);
        }

        private static bool IsBishopCorrect(string start, string end)
        {
            return (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]));
        }

        private static bool IsQueenCorrect(string start, string end)
        {
            return (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]) || end[0] == start[0] && end[1] != start[1] || end[0] != start[0] && end[1] == start[1]);
        }

        private static bool IsKingCorrect(string start, string end)
        {
            return (Math.Abs(start[0] - end[0]) <= 1 && Math.Abs(start[1] - end[1]) <= 1);
        }

        public static bool RecognitionFigureInCell(string[,] cell, string start)
        {
            if (cell[start[0] - 48, start[1] - 48] == " ")
                return false;
            else
                return true;
        }

    }
}
