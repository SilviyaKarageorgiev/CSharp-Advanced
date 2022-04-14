using System;
using System.Linq;

namespace P08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputMatrix[col];
                }
            }

            string[] inputBombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < inputBombs.Length; i++)
            {
                int[] currBomb = inputBombs[i].Split(",").Select(int.Parse).ToArray();
                int rowIndex = currBomb[0];
                int colIndex = currBomb[1];

                if (matrix[rowIndex, colIndex] <= 0)
                {
                    continue;
                }

                int bombPower = matrix[rowIndex, colIndex];
                matrix[rowIndex, colIndex] = 0;

                if (rowIndex - 1 >= 0 && rowIndex - 1 < matrix.GetLength(0) && colIndex >= 0 && colIndex < matrix.GetLength(0))
                {
                    if (matrix[rowIndex - 1, colIndex] > 0)
                    {
                        matrix[rowIndex - 1, colIndex] -= bombPower;
                    }
                }

                if (rowIndex - 1 >= 0 && rowIndex - 1 < matrix.GetLength(0) && colIndex - 1 >= 0 && colIndex - 1 < matrix.GetLength(0))
                {
                    if (matrix[rowIndex - 1, colIndex - 1] > 0)
                    {
                        matrix[rowIndex - 1, colIndex - 1] -= bombPower;
                    }
                }

                if (rowIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex - 1 >= 0 && colIndex - 1 < matrix.GetLength(0))
                {
                    if (matrix[rowIndex, colIndex - 1] > 0)
                    {
                        matrix[rowIndex, colIndex - 1] -= bombPower;
                    }
                }

                if (rowIndex + 1 >= 0 && rowIndex + 1 < matrix.GetLength(0) && colIndex - 1 >= 0 && colIndex - 1 < matrix.GetLength(0))
                {
                    if (matrix[rowIndex + 1, colIndex - 1] > 0)
                    {
                        matrix[rowIndex + 1, colIndex - 1] -= bombPower;
                    }
                }

                if (rowIndex + 1 >= 0 && rowIndex + 1 < matrix.GetLength(0) && colIndex >= 0 && colIndex < matrix.GetLength(0))
                {
                    if (matrix[rowIndex + 1, colIndex] > 0)
                    {
                        matrix[rowIndex + 1, colIndex] -= bombPower;
                    }
                }

                if (rowIndex + 1 >= 0 && rowIndex + 1 < matrix.GetLength(0) && colIndex + 1 >= 0 && colIndex + 1 < matrix.GetLength(0))
                {
                    if (matrix[rowIndex + 1, colIndex + 1] > 0)
                    {
                        matrix[rowIndex + 1, colIndex + 1] -= bombPower;
                    }
                }

                if (rowIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex + 1 >= 0 && colIndex + 1 < matrix.GetLength(0))
                {
                    if (matrix[rowIndex, colIndex + 1] > 0)
                    {
                        matrix[rowIndex, colIndex + 1] -= bombPower;
                    }
                }

                if (rowIndex - 1 >= 0 && rowIndex - 1 < matrix.GetLength(0) && colIndex + 1 >= 0 && colIndex + 1 < matrix.GetLength(0))
                {
                    if (matrix[rowIndex - 1, colIndex + 1] > 0)
                    {
                        matrix[rowIndex - 1, colIndex + 1] -= bombPower;
                    }
                }
                
            }

            int activeCells = 0;
            int sumActiveCells = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        activeCells++;
                        sumActiveCells += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sumActiveCells}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
