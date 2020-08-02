using System;
using System.IO;
using System.Linq;

namespace sudoku_solver.Workers
{
    class SudokuFileReader
    {
        public int [,] ReadFile(string filename)
        {
            int [,] board = new int[9,9];
            
            try
            {
                var boardLines = File.ReadAllLines(filename);
                int row = 0;
                foreach(var boardLine in boardLines)
                {
                    string[] boardLineElements = boardLine.Split('|').Skip(1).Take(9).ToArray();

                    int col = 0;
                    foreach(var element in boardLineElements)
                    {
                        board[row, col] = element.Equals(" ") ? 0 : Convert.ToInt16(element);
                        col++;
                    }

                    row++;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file" + ex.Message);
            }

            return board;
        }
    }
}
