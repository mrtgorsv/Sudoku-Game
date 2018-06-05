using System;

namespace WindowsFormsApplication1κο20.Utils.Sudoku {

	class BoardGenerator {

		protected const int MaxEmptySearchAttempts = 40;

		protected Board SolutionBoard;
		protected Board PuzzleBoard;

		protected static Random Rnd = new Random();

	    public void GeneratePuzzleBoard(string generator = "mirror") {
			bool solvable = false;
			while (!solvable) {
				Board testBoard = new Board();
				testBoard.CopyBoard(SolutionBoard);

			    MirrorBoardPoker mbp = new MirrorBoardPoker(ref testBoard);
			    mbp.Process();

                // STEP 2: test if solvable with 1 solution
                BoardSolver bs = new BoardSolver(testBoard);
				int numSolutions = bs.CountSolutions();
				if (numSolutions == 1) {
					//Console.WriteLine("Found 1 solution for board!");
					solvable = true;
				}
				// STEP 3: check
				if (solvable) {
					PuzzleBoard = testBoard;
				}
			}
		}

		public void GenerateSolutionBoard() {
			SolutionBoard = new Board();
			while (!TrySolutionGeneration()) {
				SolutionBoard.WhipeBoard();
			}
		}

		public Board GetPuzzleBoard() {
			return PuzzleBoard;
		}

		public Board GetSolutionBoard() {
			return SolutionBoard;
		}

		protected bool TrySolutionGeneration() {
			//Random rnd = new Random();
			for (int num = 1; num <= 9; num += 1) {
				for (int xq = 0; xq < 3; xq += 1) {
					for (int yq = 0; yq < 3; yq += 1) {
						int tries = 0;
						bool foundEmpty = false;
						int absX = 0;
						int absY = 0;
						while (!foundEmpty) {
							int rx, ry;
							lock(Rnd) {
								rx = Rnd.Next(0, 3);
								ry = Rnd.Next(0, 3);
							}
							absX = (xq * 3) + rx;
							absY = (yq * 3) + ry;
							if (SolutionBoard.CanPlaceAtSubGrid(xq, yq, rx, ry, num)) {
								if (SolutionBoard.CanBePlacedAtPosition(absX, absY, num)) {
									foundEmpty = true;
								}
							}
							tries += 1;
							if (!foundEmpty && (tries >= MaxEmptySearchAttempts)) {
								return false;
							}
						}
						// set number
						SolutionBoard.SetNumber(absX, absY, num);
					}
				}
			}
			return true;
		}

	}

}