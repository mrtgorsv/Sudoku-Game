using System;

namespace WindowsFormsApplication1кп20.Utils.Sudoku
{
    internal class MirrorBoardCreator : BoardCreator
    {
        private int _toRemove;

        public MirrorBoardCreator(ref Board pBoard) : base(ref pBoard)
        {
            _toRemove = 4;
        }

        public override void Process()
        {
            Random rnd = new Random();
            while (_toRemove > 0)
            {
                int rx = rnd.Next(0, 9);
                int ry = rnd.Next(0, 9);
                int testNum = GameBoard.GetNumber(rx, ry);
                if (testNum == 0)
                {
                    continue;
                }

                int mx = 8 - rx;
                int my = 8 - ry;
                GameBoard.SetNumber(rx, ry, 0);
                GameBoard.SetNumber(mx, my, 0);
                _toRemove -= 2;
            }
        }
    }
}