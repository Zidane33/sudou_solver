using sudoku_solver.Data;

namespace sudoku_solver.Workers
{
    class SudokuMapper
    {
        public SudokuMap Find(int givenRow, int givenCol)
        {
            SudokuMap sudokuMap = new SudokuMap();

            if((givenRow >= 0 && givenCol <= 2) && (givenCol >=0 && givenCol <=2))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartCol = 0;
            }

            if((givenRow >= 0 && givenCol <= 2) && (givenCol >=3 && givenCol <=5))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartCol = 3;
            }

            if((givenRow >= 0 && givenCol <= 2) && (givenCol >=6 && givenCol <=8))
            {
                sudokuMap.StartRow = 0;
                sudokuMap.StartCol = 6;
            }

            if((givenRow >= 3 && givenCol <= 5) && (givenCol >=0 && givenCol <=2))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartCol = 0;
            }

            if((givenRow >= 3 && givenCol <= 5) && (givenCol >=3 && givenCol <=5))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartCol = 3;
            }

            if((givenRow >= 3 && givenCol <= 5) && (givenCol >=6 && givenCol <=8))
            {
                sudokuMap.StartRow = 3;
                sudokuMap.StartCol = 6;
            }

            if((givenRow >= 6 && givenCol <= 8) && (givenCol >=0 && givenCol <=2))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartCol = 0;
            }

            if((givenRow >= 6 && givenCol <= 8) && (givenCol >=3 && givenCol <=5))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartCol = 3;
            }

            if((givenRow >= 6 && givenCol <= 8) && (givenCol >=6 && givenCol <=8))
            {
                sudokuMap.StartRow = 6;
                sudokuMap.StartCol = 6;
            }

            return sudokuMap;
        }

    }
}
