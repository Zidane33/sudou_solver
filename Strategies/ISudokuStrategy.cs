namespace sudoku_solver.Strategies
{
    interface ISudokuStrategy
    {
        int[,] Solve(int[,] board);
    }
}
