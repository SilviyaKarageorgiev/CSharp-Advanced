using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] inputRowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = inputRowsCols[0];
            int cols = inputRowsCols[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputMatrix[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmd = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (cmd.Length > 5 || cmd.Length < 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string command = cmd[0];
                int row1 = int.Parse(cmd[1]);
                int col1 = int.Parse(cmd[2]);
                int row2 = int.Parse(cmd[3]);
                int col2 = int.Parse(cmd[4]);

                if (command != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (row1 < 0 || row1 >= matrix.GetLength(0) || col1 < 0 || col1 >= matrix.GetLength(1) || row2 < 0 || row2 >= matrix.GetLength(0) || col2 < 0 || col2 >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string element1 = matrix[row1, col1];
                string element2 = matrix[row2, col2];

                matrix[row1, col1] = element2;
                matrix[row2, col2] = element1;

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
}
