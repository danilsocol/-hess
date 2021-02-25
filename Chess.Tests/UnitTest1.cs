using NUnit.Framework;
using System;

namespace Chess.Tests
{
    public class Tests
    {
        [TestCase("A2","A3",ExpectedResult=true)]

        public bool IsPawnCorrect_Test(string start,string end)
        {
            return  FigureMove.IsPawnCorrect( start,  end);
        }
        
        
        [TestCase("A1", "B3", ExpectedResult = true)]

        public bool IsKnightCorrect_Test(string start, string end)
        {
            return FigureMove.IsKnightCorrect(start, end);
        }


        [TestCase("A1", "A4", ExpectedResult = true)]

        public bool IsRookCorrect_Test(string start, string end)
        {
            return FigureMove.IsRookCorrect(start, end);
        }


        [TestCase("A1", "C3", ExpectedResult = true)]

        public bool IsBishopCorrect_Test(string start, string end)
        {
            return FigureMove.IsBishopCorrect(start, end);
        }


        [TestCase("A1", "C3", ExpectedResult = true)]
        [TestCase("A1", "A4", ExpectedResult = true)]
        public bool IsQueenCorrect_Test(string start, string end)
        {
            return FigureMove.IsQueenCorrect(start, end);
        }


        [TestCase("A2", "B3", ExpectedResult = true)]

        public bool IsKingCorrect_Test(string start, string end)
        {
            return FigureMove.IsKingCorrect(start, end);
        }

    }
}