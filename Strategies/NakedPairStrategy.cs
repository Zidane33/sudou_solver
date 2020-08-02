using System;
using System.Linq;
using sudoku_solver.Workers;

namespace sudoku_solver.Strategies
{
    class NakedPairStrategy : ISudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public NakedPairStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] board)
        {

            for (int row=0; row<board.GetLength(0); row++)
            {
                for (int col=0; col < board.GetLength(1); col++)
                {
                    EliminateNakedPairInRow(board, row, col);
                    EliminateNakedPairInCol(board, row, col);
                    EliminateNakedPairInBlock(board, row, col);
                }
            }
            return board;
        }

        private void EliminateNakedPairInRow(int[,] board, int givenRow, int givenCol)
        {
            if(!HasNakedPairInRow(board, givenRow, givenCol)) return;

            for(int col = 0; col < board.GetLength(1); col++)
            {
                if(board[givenRow, col] != board[givenRow, givenCol] && board[givenRow, col].ToString().Length > 1)
                {
                    EliminateNakedPair(board, board[givenRow, givenCol], givenRow, col);
                }
            }
        }

        private void EliminateNakedPairInCol(int[,] board, int givenRow, int givenCol)
        {
            if(!HasNakedPairInCol(board, givenRow, givenCol)) return;

            for(int row = 0; row < board.GetLength(0); row++)
            {
                if(board[row, givenCol] != board[givenRow, givenCol] && board[row, givenCol].ToString().Length > 1)
                {
                    EliminateNakedPair(board, board[givenRow, givenCol], row, givenCol);
                }
            }
        }

        private void EliminateNakedPairInBlock(int[,] board, int givenRow, int givenCol)
        {
            if(!hasNakedPairInBlock(board, givenRow, givenCol)) return;

            var sudokuMap = _sudokuMapper.Find(givenRow, givenCol);

            for (int row=sudokuMap.StartRow; row<= sudokuMap.StartRow + 2; row++)
            {
                for (int col=sudokuMap.StartCol; col <= sudokuMap.StartCol + 2; col++)
                {
                    if(board[row, col].ToString().Length > 1 && board[row, col] != board[givenRow, givenCol])
                    {
                        EliminateNakedPair(board, board[givenRow, givenCol], row, col);
                    }
                }
            }
        }

        private bool hasNakedPairInBlock(int[,] board, int givenRow, int givenCol)
        {
            for (int row=0; row<board.GetLength(0); row++)
            {
                for (int col=0; col < board.GetLength(1); col++)
                {
                    var elementSame = givenRow == row && givenCol == col;
                    var elementInSameBlock = _sudokuMapper.Find(givenRow, givenCol).StartRow == _sudokuMapper.Find(row, col).StartRow && _sudokuMapper.Find(givenRow, givenCol).StartCol == _sudokuMapper.Find(row, col).StartCol;

                    if(!elementSame && elementInSameBlock && isNakedPair(board[givenRow, givenCol], board[row, col])) return true;
                }
            }
            return false;
        }

        private bool HasNakedPairInRow(int[,] board, int givenRow, int givenCol)
        {
            for(int col = 0; col < board.GetLength(1); col++)
            {
                if(givenCol != col && isNakedPair(board[givenRow, col], board[givenRow, givenCol]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasNakedPairInCol(int[,] board, int givenRow, int givenCol)
        {
            for(int row = 0; row < board.GetLength(0); row++)
            {
                if(givenRow != row && isNakedPair(board[row, givenCol], board[givenRow, givenCol]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isNakedPair(int firstPair, int secondPair)
        {
            return firstPair.ToString().Length == 2 && firstPair == secondPair;
        }

        private void EliminateNakedPair(int[,] board, int values, int eliminatedFromRow, int eliminatedFromCol)
        {
            var valuesToEliminate = values.ToString().ToCharArray();
            foreach(var value in valuesToEliminate)
            {
                board[eliminatedFromRow, eliminatedFromCol] = Convert.ToInt32(board[eliminatedFromRow, eliminatedFromCol].ToString().Replace(value.ToString(), string.Empty));
            }
        }
    }
}
