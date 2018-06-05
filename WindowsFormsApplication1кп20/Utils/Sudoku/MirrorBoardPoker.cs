using System;

namespace WindowsFormsApplication1κο20.Utils.Sudoku
{
    internal class MirrorBoardPoker : BoardPoker
    {
        private int _toRemove;

        public MirrorBoardPoker(ref Board pBoard) : base(ref pBoard)
        {
            _toRemove = 52;
        }

        public override void Process()
        {
            Random rnd = new Random();
            while (_toRemove > 0)
            {
                int rx = rnd.Next(0, 9);
                int ry = rnd.Next(0, 9);
                int testNum = PuzzleBoard.GetNumber(rx, ry);
                if (testNum == 0)
                {
                    continue;
                }

                int mx = 8 - rx;
                int my = 8 - ry;
                PuzzleBoard.SetNumber(rx, ry, 0);
                PuzzleBoard.SetNumber(mx, my, 0);
                _toRemove -= 2;
            }
        }
    }
}