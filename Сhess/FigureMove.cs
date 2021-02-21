using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class FigureMove
    {
        private static bool IsCorrectCoordinate(string coord)
        {
            char letter = coord[0];
            char num = coord[1];
            return coord.Length == 2 && letter >= 'A' && letter <= 'H' && num >= '1' && num <= '8';
        }
        private static string ReadCoord()
        {
            do

            {
                string input = Console.ReadLine().ToUpper();
                if (IsCorrectCoordinate(input))
                    return input;
                else
                    Console.WriteLine("Координата не корректна!");
            }
            while (true);
        }

        enum FigureType
        {
            pawn, rook, knight, bishop, queen, king
        }

        private static FigureType ReadFigureType()
        {
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {

                    case ("0"):
                    case ("pawn"):
                        return FigureType.pawn;

                    case ("1"):
                    case ("rook"):
                        return FigureType.rook;

                    case ("2"):
                    case ("knight"):
                        return FigureType.knight;

                    case ("3"):
                    case ("bishop"):
                        return FigureType.bishop;

                    case ("4"):
                    case ("queen"):
                        return FigureType.queen;

                    case ("5"):
                    case ("king"):
                        return FigureType.king;

                    default:
                        Console.WriteLine("Тип фигуры не корректен!");
                        break;
                }
            } while (true);
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



        static void SelectingFigure(string[] args)
        {
            Console.Write("Введите тип фигуры (0-pawn, 1-rook, 2-knight, 3-bishop, 4-queen, 5-king):");
            FigureType figure = ReadFigureType();

            Console.Write("Введите стартовую координату: ");
            string start = ReadCoord();

            Console.Write("Введите конечную координату: ");
            string end = ReadCoord();

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

            if (isCorrect)
                Console.WriteLine("Ваша фигура ходит правильно.");
            else
                Console.WriteLine("Такой ход не возможен для данной фигуры.");
        }
    }
}
