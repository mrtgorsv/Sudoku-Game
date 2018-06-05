namespace WindowsFormsApplication1��20.Utils.Sudoku {

	abstract class BoardPoker {

		protected Board PuzzleBoard;

	    protected BoardPoker(ref Board pBoard) {
			PuzzleBoard = pBoard;
		}

		public virtual void Process() {
			
		}

	}

}