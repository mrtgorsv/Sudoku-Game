namespace WindowsFormsApplication1кп20.Utils.Sudoku {
    internal abstract class BoardCreator {

		protected Board GameBoard;

	    protected BoardCreator(ref Board pBoard) {
			GameBoard = pBoard;
		}

		public virtual void Process() {
			
		}

	}

}