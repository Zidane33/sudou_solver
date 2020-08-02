using System;
using sudoku_solver.Workers;
using sudoku_solver.Strategies;

namespace sudoku_solver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuStateManger sudokuStateManger = new SudokuStateManger();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuStateManger, sudokuMapper);
                SudokuFileReader sudokuFileReader = new SudokuFileReader();
                SudokuBoardDisplayer sudokuBoardDisplayer = new SudokuBoardDisplayer();

                Console.WriteLine("Please enter the sudoku file name:");
                var filename = Console.ReadLine();

                var board = sudokuFileReader.ReadFile(filename);
                sudokuBoardDisplayer.Display("Initial State", board);

                bool isSudokuSolved = sudokuSolverEngine.Solve(board);
                sudokuBoardDisplayer.Display("Final State", board);

                Console.WriteLine(isSudokuSolved ? "Success!" : "Cannot solve this sudoku");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0} : {1}", "Puzzle could not be solved", ex.Message);
            }
        }
    }
}
