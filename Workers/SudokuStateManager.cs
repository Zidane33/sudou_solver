using System.Text;

namespace sudoku_solver.Workers
{
    class SudokuStateManger
    {
        public string GenerateState(int[,] board)
        {
            StringBuilder key = new StringBuilder();
            for (int row=0; row < board.GetLength(0); row++)
            {
                for (int col=0; col < board.GetLength(1); col++)
                {
                    key.Append(board[row, col]);
                }
            }
            return key.ToString();
        }

        public bool IsSolved(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 0 || board[row, col].ToString().Length > 1)
                    {
                        return false;
                    }
                }
                
            }

            return true;
        }
    }
}