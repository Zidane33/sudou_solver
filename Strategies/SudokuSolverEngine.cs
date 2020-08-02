using System.Collections.Generic;
using System.Linq;
using sudoku_solver.Workers;

namespace sudoku_solver.Strategies
{
    class SudokuSolverEngine
    {
        private readonly SudokuStateManger _sudokuStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuSolverEngine(SudokuStateManger sudokuStateManager, SudokuMapper sudokuMapper)
        {
            _sudokuStateManager = sudokuStateManager;
            _sudokuMapper = sudokuMapper;
        }

        public bool Solve(int[,] board)
        {
            List<ISudokuStrategy> strategies = new List<ISudokuStrategy>()
            {
                new SimpleMarkUpStrategy(_sudokuMapper),
                new NakedPairStrategy(_sudokuMapper)
            };

            var currentState = _sudokuStateManager.GenerateState(board);
            var nextState = _sudokuStateManager.GenerateState(strategies.First().Solve(board));
            while(!_sudokuStateManager.IsSolved(board) && currentState != nextState)
            {
                currentState = nextState;
                foreach(var strategy in strategies) nextState = _sudokuStateManager.GenerateState(strategy.Solve(board));
            }
            return _sudokuStateManager.IsSolved(board);
        }
    }
}
