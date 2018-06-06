using System;

namespace WindowsFormsApplication1кп20.Utils.Sudoku
{
    public class Board
    {
        protected BoardBox[,] BoardBox;

        public Board()
        {
            BoardBox = new BoardBox[3, 3];
            ClearBoard();
        }

        public bool CanBePlacedAtPosition(int x, int y, int num)
        {
            int current = GetNumber(x, y);
            if (current > 0)
            {
                return false;
            }

            for (int tx = 0; tx < 9; tx += 1)
            {
                if (tx == x)
                {
                    continue;
                }

                int thisNum = GetNumber(tx, y);
                if (thisNum == num)
                {
                    return false;
                }
            }

            for (int ty = 0; ty < 9; ty += 1)
            {
                if (ty == y)
                {
                    continue;
                }

                int thisNum = GetNumber(x, ty);
                if (thisNum == num)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CanPlaceAtSubGrid(int subX, int subY, int relX, int relY, int num)
        {
            BoardBox subGrid = BoardBox[subX, subY];
            int checkNum = subGrid.GetNumber(relX, relY);
            if (checkNum == 0)
            {
                bool numExists = false;
                for (int x = 0; x < 3; x += 1)
                {
                    for (int y = 0; y < 3; y += 1)
                    {
                        if (x == relX && y == relY)
                        {
                            continue;
                        }

                        checkNum = subGrid.GetNumber(x, y);
                        if (checkNum == num)
                        {
                            numExists = true;
                            break;
                        }
                    }

                    if (numExists)
                    {
                        break;
                    }
                }

                if (!numExists)
                {
                    return true;
                }
            }

            return false;
        }

        public void Copy(Board source)
        {
            for (int y = 0; y < 9; y += 1)
            {
                for (int x = 0; x < 9; x += 1)
                {
                    SetNumber(x, y, source.GetNumber(x, y));
                }
            }
        }

        public int GetNumber(int x, int y)
        {
            int row = (int) Math.Floor((double) y / 3);
            int col = (int) Math.Floor((double) x / 3);
            BoardBox bb = BoardBox[col, row];
            int minorX = x - col * 3;
            int minorY = y - row * 3;
            return bb.GetNumber(minorX, minorY);
        }

        public void SetNumber(int x, int y, int num)
        {
            int row = (int) Math.Floor((double) y / 3);
            int col = (int) Math.Floor((double) x / 3);
            BoardBox bb = BoardBox[col, row];
            int minorX = x - col * 3;
            int minorY = y - row * 3;
            bb.SetNumber(minorX, minorY, num);
        }

        public void ClearBoard()
        {
            for (int x = 0; x < 3; x += 1)
            {
                for (int y = 0; y < 3; y += 1)
                {
                    BoardBox[x, y] = new BoardBox();
                }
            }
        }
    }
}