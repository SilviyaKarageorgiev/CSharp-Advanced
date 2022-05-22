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
            FillMatrix(matrix);

            int primeryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int number = matrix[row, col];

                    if (row == col)
                    {
                        primeryDiagonalSum += number;
                    }

                    if (row + col == n - 1)
                    {
                        secondaryDiagonalSum += number;
                    }
                }
            }

            int result = Math.Abs(primeryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(result);
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
