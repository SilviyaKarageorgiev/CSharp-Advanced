using System;
using System.Linq;

namespace P06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[rows][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                int[] inputCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jagged[row] = new double[inputCols.Length];

                for (int col = 0; col < inputCols.Length; col++)
                {
                    jagged[row][col] = inputCols[col];

                }
            }

            for (int row = 0; row < jagged.GetLength(0) - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] = jagged[row][col] * 2;
                        jagged[row + 1][col] = jagged[row + 1][col] * 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] = jagged[row][col] / 2;
                    }
                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] = jagged[row + 1][col] / 2;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                double value = double.Parse(cmdArgs[3]);

                if (row < 0 || row >= jagged.GetLength(0) || col < 0 || col >= jagged[row].Length)
                {
                    continue;
                }

                if (command == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    jagged[row][col] -= value;
                }
            }

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
