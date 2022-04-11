using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace P05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] inputRowsCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = inputRowsCols[0];
            int cols = inputRowsCols[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sum = 0;
            int maxSum = int.MinValue;
            int startRowIndexMaxSum = 0;
            int startColIndexMaxSum = 0;
            int currIndexRow = 0;
            int currIndexCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currIndexRow = row;
                    currIndexCol = col;

                    sum = matrix[row,col] + matrix[row,col + 1] + matrix[row + 1, col] + matrix [row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRowIndexMaxSum = currIndexRow;
                        startColIndexMaxSum = currIndexCol;
                    }
                }
            }

            for (int i = startRowIndexMaxSum; i <= startRowIndexMaxSum + 1; i++)
            {
                for (int j = startColIndexMaxSum; j <= startColIndexMaxSum + 1; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
