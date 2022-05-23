using System;
using System.Linq;
using System.Numerics;

namespace P06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                jagged[row] = new double[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    jagged[row][col] = input[col];
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

            string inputCmds;
            while ((inputCmds = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = inputCmds.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                int index1 = int.Parse(cmdArgs[1]);
                int index2 = int.Parse(cmdArgs[2]);
                double value = double.Parse(cmdArgs[3]);

                if (!ValidateIndeces(jagged, index1, index2))
                {
                    continue;
                }
                else
                {
                    if (command == "Add")
                    {
                        jagged[index1][index2] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jagged[index1][index2] -= value;
                    }
                }
            }
            PrintJaggedArray(jagged);
        }

        private static void PrintJaggedArray(double[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool ValidateIndeces(double[][] jagged, int index1, int index2)
        {
            if (index1 >= 0 && index1 < jagged.GetLength(0) && index2 >= 0 && index2 < jagged[index1].Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
