using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class FigureMove
    {
        public static bool IsCorrectCoordinate(string coord)
        {
            char letter = coord[0];
            char num = coord[1] ;
            return coord.Length == 2 && letter >= 'A' && letter <= 'H' && num >= '1' && num <= '8';
        }
            enum FigureType
            {
                pawn, rook, knight, bishop, queen, king
            }

        private static FigureType ReadFigureType(string[,] cell,string start)
        {
            string input = cell[start[0] - 48, start[1] - 48];
            switch (input)
            {
                case ("P"):
                    return FigureType.pawn;

                case ("R"):
                    return FigureType.rook;

                case ("H"):
                    return FigureType.knight;

                case ("B"):
                    return FigureType.bishop;

                case ("Q"):
                    return FigureType.queen;

                case ("K"):
                    return FigureType.king;

                default:
                    return 0;
            }
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

        static bool RecognitionFigureInCell(string[,] cell,string start)
        {
            if (cell[start[0] - 48, start[1]- 48] == " ")
                return false;
            else
                return true;
        }

        public static void SelectingFigure(string[] move, string[,] cell)
        {
            string start = move[0];

            if (!RecognitionFigureInCell(cell, start))
                WorkConsole.Error();

            FigureType figure = ReadFigureType(cell,start);

            string end = move[1];


            bool isCorrect = false;
            switch (figure)
            {
                case FigureType.knight:
                    isCorrect = IsKnightCorrect(start, end);
                    break;

                case FigureType.pawn:
                    isCorrect = IsPawnCorrect(start, end);
                    break;

                case FigureType.rook:
                    isCorrect = IsRookCorrect(start, end);
                    break;

                case FigureType.queen:
                    isCorrect = IsQueenCorrect(start, end);
                    break;

                case FigureType.king:
                    isCorrect = IsKingCorrect(start, end);
                    break;

                case FigureType.bishop:
                    isCorrect = IsBishopCorrect(start, end);
                    break;
            }
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
    }
}
