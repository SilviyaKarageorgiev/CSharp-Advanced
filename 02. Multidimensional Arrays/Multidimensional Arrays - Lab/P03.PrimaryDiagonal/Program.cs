using System;
using System.Linq;

namespace P03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sum = 0;
            for (int roww = 0; roww < matrix.GetLength(0); roww++)
            {
                sum += matrix[roww, roww];
            }

            Console.WriteLine(sum);
        }
    }
}
