using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class FigureMove
    {

        public static bool CheckCorrectOfTheMove(string[,] cell, string start, string end)
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

        public static bool IsKnightCorrect(string start, string end)
        {
            int dx = Math.Abs(end[0] - start[0]);
            int dy = Math.Abs(end[1] - start[1]);

            return dx + dy == 3 && dx * dy == 2;
        }

        public static bool IsPawnCorrect(string start, string end)
        {
            return (end[0] - start[0] == 0 && end[1] - start[1] == 1);
        }

        public static bool IsRookCorrect(string start, string end)
        {
            return (end[0] == start[0] && end[1] != start[1] || end[0] != start[0] && end[1] == start[1]);
        }

        public static bool IsBishopCorrect(string start, string end)
        {
            return (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]));
        }

        public static bool IsQueenCorrect(string start, string end)
        {
            return (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]) || end[0] == start[0] && end[1] != start[1] || end[0] != start[0] && end[1] == start[1]);
        }

        public static bool IsKingCorrect(string start, string end)
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
