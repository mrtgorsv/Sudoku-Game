namespace WindowsFormsApplication1кп20.Utils.Sudoku {
    public class BoardBox {

		protected int[,] Grid;

		public BoardBox() {
			Grid = new int[3, 3];
			ClearGrid();
		}

		public int GetNumber(int x, int y) {
			return Grid[x, y];
		}

		public void SetNumber(int x, int y, int num) {
			Grid[x, y] = num;
		}

		public void ClearGrid() {
			for (int x = 0; x < 3; x += 1) {
				for (int y = 0; y < 3; y += 1) {
					Grid[x, y] = 0;
				}
			}
		}

	}

}