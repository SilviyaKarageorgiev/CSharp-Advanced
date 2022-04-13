using System;
using System.Linq;

namespace P02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] inputRowsCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = inputRowsCols[0];
            int cols = inputRowsCols[1];
            string[,] matrix = new string[rows, cols];
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {                    
                    if (matrix[row, col].CompareTo(matrix[row, col + 1]) == 0 && matrix[row, col + 1].CompareTo(matrix[row + 1, col]) == 0 && matrix[row + 1, col].CompareTo(matrix[row + 1, col + 1]) == 0)
                    {
                        counter++;
                    }

                }
            }

            Console.WriteLine(counter);
        }
    }
}
