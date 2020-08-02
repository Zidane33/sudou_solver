using System;
using System.Linq;
using sudoku_solver.Workers;

namespace sudoku_solver.Strategies
{
    class SimpleMarkUpStrategy : ISudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public SimpleMarkUpStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] board)
        {

            for (int row=0; row<board.GetLength(0); row++)
            {
                for (int col=0; col < board.GetLength(1); col++)
                {
                    if(board[row, col] == 0 || board[row, col].ToString().Length > 1)
                    {
                        var potentialsRowsCols = GetPotentialsRowCols(board, row, col);
                        var potentialsBlock = GetPotentialsBlock(board, row, col);
                        board[row, col] = GetIntersections(potentialsRowsCols, potentialsBlock);

                    }
                }
            }
            return board;
        }

        public int GetPotentialsRowCols(int[,] board, int givenRow, int givenCol)
        {
            int[] potentials = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for(int col = 0; col <9; col++)
            {
                if (isValidSingle(board[givenRow, col])) potentials[board[givenRow, col] - 1] = 0;
            }
            for(int row = 0; row <9; row++)
            {
                if (isValidSingle(board[row, givenCol])) potentials[board[row, givenCol] - 1] = 0;
            }
            return Convert.ToInt32(String.Join(string.Empty, potentials.Select(p => p).Where(p => p != 0)));
        }

        public int GetPotentialsBlock(int[,] board, int givenRow, int givenCol)
        {
            int[] potentials = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sudokuMap = _sudokuMapper.Find(givenRow, givenCol);

            for (int row=sudokuMap.StartRow; row<= sudokuMap.StartRow + 2; row++)
            {
                for (int col=sudokuMap.StartCol; col <= sudokuMap.StartCol +2; col++)
                {
                    if (isValidSingle(board[row, col])) potentials[board[row, col] - 1] = 0;
                }
            }

            return Convert.ToInt32(String.Join(string.Empty, potentials.Select(p => p).Where(p => p != 0)));
        }

        private int GetIntersections(int potentialsRowsCols, int potentialsBlock)
        {
            var rowsCols = potentialsRowsCols.ToString().ToCharArray();
            var blocks = potentialsBlock.ToString().ToCharArray(); 
            var potentialsSubset = rowsCols.Intersect(blocks);
            return Convert.ToInt32(string.Join(string.Empty, potentialsSubset));
        }

        private bool isValidSingle(int digit)
        {
            return digit != 0 && digit.ToString().Length == 2;
        }
    }
}
