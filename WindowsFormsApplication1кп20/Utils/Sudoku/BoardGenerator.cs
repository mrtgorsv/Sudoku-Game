using System;

namespace WindowsFormsApplication1кп20.Utils.Sudoku
{
    internal class BoardGenerator
    {
        protected const int MaxEmptySearchAttempts = 40;

        protected Board SolutionBoard;
        protected Board GameBoard;

        protected static Random Rnd = new Random();

        public void GenerateGameBoard()
        {
            bool valid = false;
            while (!valid)
            {
                Board testBoard = new Board();
                testBoard.Copy(SolutionBoard);

                MirrorBoardCreator mbp = new MirrorBoardCreator(ref testBoard);
                mbp.Process();
                BoardSolver bs = new BoardSolver(testBoard);
                if (bs.CountSolutions() == 1)
                {
                    valid = true;
                }
                if (valid)
                {
                    GameBoard = testBoard;
                }
            }
        }

        public void GenerateSolutionBoard()
        {
            SolutionBoard = new Board();
            while (!TryGenerateSolution())
            {
                SolutionBoard.ClearBoard();
            }
        }

        public Board GetGameBoard()
        {
            return GameBoard;
        }

        public Board GetSolutionBoard()
        {
            return SolutionBoard;
        }

        protected bool TryGenerateSolution()
        {
            for (int num = 1; num <= 9; num += 1)
            {
                for (int xq = 0; xq < 3; xq += 1)
                {
                    for (int yq = 0; yq < 3; yq += 1)
                    {
                        int tries = 0;
                        bool foundEmpty = false;
                        int absX = 0;
                        int absY = 0;
                        while (!foundEmpty)
                        {
                            int rx, ry;
                            lock (Rnd)
                            {
                                rx = Rnd.Next(0, 3);
                                ry = Rnd.Next(0, 3);
                            }
                            absX = xq * 3 + rx;
                            absY = yq * 3 + ry;
                            if (SolutionBoard.CanPlaceAtSubGrid(xq, yq, rx, ry, num))
                            {
                                if (SolutionBoard.CanBePlacedAtPosition(absX, absY, num))
                                {
                                    foundEmpty = true;
                                }
                            }
                            tries += 1;
                            if (!foundEmpty && tries >= MaxEmptySearchAttempts)
                            {
                                return false;
                            }
                        }
                        SolutionBoard.SetNumber(absX, absY, num);
                    }
                }
            }
            return true;
        }
    }
}