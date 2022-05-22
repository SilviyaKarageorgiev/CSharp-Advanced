using System;
using System.Linq;

namespace P04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] rowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            string[,] matrix = new string[rows, cols];

            FillMatrix(matrix);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (!ValidationInput(input, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string first = matrix[int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2])];
                    string second = matrix[int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4])];

                    matrix[int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2])] = second;
                    matrix[int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4])] = first;
                }

                PrintMatrix(matrix);

            }

        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool ValidationInput(string input, int rows, int cols)
        {
            string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = cmdArgs[0];

            if (command == "swap" && cmdArgs.Length == 5)
            {
                int row1 = int.Parse(cmdArgs[1]);
                int col1 = int.Parse(cmdArgs[2]);
                int row2 = int.Parse(cmdArgs[3]);
                int col2 = int.Parse(cmdArgs[4]);

                if (row1 >= 0 && row1 < rows && row2 >= 0 && row2 < rows && col1 >= 0 && col1 < cols && col2 >= 0 && col2 < cols)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] matrixElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixElements[col];
                }
            }
        }
    }
}
