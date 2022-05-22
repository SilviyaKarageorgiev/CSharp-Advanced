using System;
using System.Linq;

namespace P03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] rowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            
            int[,] matrix = new int[rows, cols];
            FillMatrix(matrix);
            int maxSum = int.MinValue;
            int startRowIndex = 0;
            int startColIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {                
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currSum = matrix[row,col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        startRowIndex = row;
                        startColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startRowIndex; row <= startRowIndex + 2; row++)
            {
                for (int col = startColIndex; col <= startColIndex + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
