namespace WindowsFormsApplication1κο20.Utils.Sudoku {

	class BoardBox {

		protected int[,] Grid;

		public BoardBox() {
			Grid = new int[3, 3];
			WhipeGrid();
		}

		public int GetNumber(int x, int y) {
			return Grid[x, y];
		}

		public void SetNumber(int x, int y, int num) {
			Grid[x, y] = num;
		}

		public void WhipeGrid() {
			for (int x = 0; x < 3; x += 1) {
				for (int y = 0; y < 3; y += 1) {
					Grid[x, y] = 0;
				}
			}
		}

	}

}