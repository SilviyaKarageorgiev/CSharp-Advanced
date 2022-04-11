using System;
using System.Linq;

namespace P02.SumMatrixColumns
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
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int currSum = 0;
            for (int coll = 0; coll < matrix.GetLength(1); coll++)
            {

                for (int roww = 0; roww < matrix.GetLength(0); roww++)
                {
                    currSum += matrix[roww, coll];
                }
                Console.WriteLine(currSum);
                currSum = 0;
            }

        }
    }
}
