

using System;
using System.Collections.Generic;



public class SudokuValidator
{
    public static void Main(string[] args)
    {
        int[][] sudoku_1 = new

int[][]
        {
            new

int[] { 7, 8, 4, 1, 5, 9, 3, 2, 6 },
            new

int[] { 5, 3, 9, 6, 7, 2, 8, 4, 1 },
            new

int[] { 6, 1, 2, 4, 3, 8, 7, 5, 9 },
            new

int[] { 9, 2, 8, 7, 1, 5, 4, 6, 3 },
            new

int[] { 3, 5, 7, 8, 4, 6, 1, 9, 2 },
            new

int[] { 4, 6, 1, 9, 2, 3, 5, 8, 7 },
            new

int[] { 8, 7, 6, 3, 9, 4, 2, 1, 5 },
            new

int[] { 2, 4, 3, 5, 6, 1, 9, 7, 8 },
            new

int[] { 1, 9, 5, 2, 8, 7, 6, 3, 4 }
        };
        int[][] sudoku_2 = new int[][]
        {
    new int[] { 7, 8, 4, 1, 5, 9, 3, 2, 6 },
    new int[] { 5, 3, 9, 6, 7, 2, 8, 4, 1 },
    new int[] { 6, 1, 2, 4, 3, 8, 7, 5, 9 },
    new int[] { 9, 2, 8, 7, 1, 5, 4, 6, 3 },
    new int[] { 3, 5, 7, 8, 4, 6, 1, 9, 2 },
    new int[] { 4, 6, 1, 9, 2, 3, 5, 8, 7 },
    new int[] { 8, 7, 6, 3, 9, 4, 2, 1, 5 },
    new int[] { 2, 4, 3, 5, 6, 1, 9, 7, 8 },
    new int[] { 0, 0, 0, 0, 0, 0, 6, 3, 4 }
        };

        bool isValidSudoku_1 = SudokuValidator.ValidateSudoku(sudoku_1);

        if (isValidSudoku_1)
        {
            Console.WriteLine("The First Sudoku puzzle is valid.");
        }
        else
        {
            Console.WriteLine("The First Sudoku puzzle is not valid.");
        }
        bool isValidSudoku_2 = SudokuValidator.ValidateSudoku(sudoku_2);

        if (isValidSudoku_2)
        {
            Console.WriteLine("The Second Sudoku puzzle is valid.");
        }
        else
        {
            Console.WriteLine("The Second Sudoku puzzle is not valid.");
        }
    }

    public static bool ValidateSudoku(int[][] sudoku)
    {
        // Check row constraints
        for (int row = 0; row < sudoku.Length; row++)
        {
            var numbers = new HashSet<int>(sudoku.Length);
            for (int col = 0; col < sudoku.Length; col++)
            {
                int number = sudoku[row][col];
                if (number < 1 || number > sudoku.Length)
                {
                    return false;
                }

                if (numbers.Contains(number))
                {
                    return false;
                }

                numbers.Add(number);
            }
        }

        // Check column constraints
        for (int col = 0; col < sudoku.Length; col++)
        {
            var numbers = new HashSet<int>(sudoku.Length);
            for (int row = 0; row < sudoku.Length; row++)
            {
                int number = sudoku[row][col];
                if (number < 1 || number > sudoku.Length)
                {
                    return false;
                }

                if (numbers.Contains(number))
                {
                    return false;
                }

                numbers.Add(number);
            }
        }

        // Check 3x3 subgrids constraints
        int subgridSize = (int)Math.Sqrt(sudoku.Length);
        for (int row = 0; row < sudoku.Length; row += subgridSize)
        {
            for (int col = 0; col < sudoku.Length; col += subgridSize)
            {
                var numbers = new HashSet<int>(subgridSize);
                for (int subgridRow = 0; subgridRow < subgridSize; subgridRow++)
                {
                    for (int subgridColumn = 0; subgridColumn < subgridSize; subgridColumn++)
                    {
                        int number = sudoku[row + subgridRow][col + subgridColumn];
                        if (number < 1 || number > sudoku.Length)
                        {
                            return false;
                        }

                        if (numbers.Contains(number))
                        {
                            return false;
                        }

                        numbers.Add(number);
                    }
                }
            }
        }

        return true;
    }
}
