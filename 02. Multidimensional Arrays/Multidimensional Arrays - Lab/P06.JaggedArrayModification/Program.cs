using System;
using System.Linq;

namespace P06.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                int[] inputJaggedArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jagged[row] = new int[inputJaggedArr.Length];

                for (int col = 0; col < inputJaggedArr.Length; col++)
                {
                    jagged[row][col] = inputJaggedArr[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = cmdArgs[0];
                int roww = int.Parse(cmdArgs[1]);
                int coll = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (command == "Add")
                {
                    if (roww < 0 || roww >= jagged.GetLength(0) || coll < 0 || coll >= jagged[roww].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }
                    jagged[roww][coll] += value;
                }

                else if (command == "Subtract")
                {
                    if (roww < 0 || roww >= jagged.GetLength(0) || coll < 0 || coll >= jagged[roww].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }
                    jagged[roww][coll] -= value;
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
