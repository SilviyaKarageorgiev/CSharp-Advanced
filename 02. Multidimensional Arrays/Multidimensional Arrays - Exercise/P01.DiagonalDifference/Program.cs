using System;
using System.Linq;

namespace P01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sumLeftToRightDiagonal = 0;
            int sumRightToLeftDiagonal = 0;
            int absDifference = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumLeftToRightDiagonal += matrix[row, row];
                sumRightToLeftDiagonal += matrix[row, matrix.GetLength(1) - 1 - row];
            }

            absDifference = Math.Abs(sumLeftToRightDiagonal - sumRightToLeftDiagonal);
            Console.WriteLine(absDifference);
        }
    }
}
