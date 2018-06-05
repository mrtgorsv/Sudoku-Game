using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1κο20.Utils.Sudoku
{
    internal class BoardSolver
    {
        protected Board GameBoard;
        protected int Solutions;
        protected List<Tuple<int, int>> EmptyCells;

        public BoardSolver(Board partialBoard)
        {
            GameBoard = partialBoard;
        }

        public bool CanBeSolved()
        {
            return (CountSolutions(true) > 0);
        }

        public int CountSolutions(bool stopAtOne = false)
        {
            Solutions = 0;

            int index = 0;
            EmptyCells = new List<Tuple<int, int>>();
            // find the empty cells
            for (int y = 0; y < 9; y += 1)
            {
                for (int x = 0; x < 9; x += 1)
                {
                    int num = GameBoard.GetNumber(x, y);
                    if (num == 0)
                    {
                        Tuple<int, int> empty = new Tuple<int, int>(x, y);
                        EmptyCells.Add(empty);
                    }
                }
            }

            if (EmptyCells.Count <= 0)
            {
                return Solutions;
            }

            TryPoint(index);

            return Solutions;
        }

        private void TryPoint(int index)
        {
            Tuple<int, int> point = EmptyCells[index];
            int x = point.Item1;
            int y = point.Item2;
            for (int num = 1; num <= 9; num += 1)
            {
                if (GameBoard.CanBePlacedAtPosition(x, y, num))
                {
                    int subX = (int) Math.Floor((double) x / 3);
                    int subY = (int) Math.Floor((double) y / 3);
                    int relX = x - (subX * 3);
                    int relY = y - (subY * 3);
                    if (GameBoard.CanPlaceAtSubGrid(subX, subY, relX, relY, num))
                    {
                        GameBoard.SetNumber(x, y, num);
                        if (index == (EmptyCells.Count - 1))
                        {
                            Solutions += 1;
                        }
                        else
                        {
                            TryPoint(index + 1);
                        }

                        GameBoard.SetNumber(x, y, 0);
                    }
                }
            }

            GameBoard.SetNumber(x, y, 0);
        }
    }
}