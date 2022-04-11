using System;
using System.Linq;

namespace P04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char wantedChar = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == wantedChar)
                    {
                        Console.WriteLine($"({row}, {col})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{wantedChar} does not occur in the matrix ");
        }

        
    }
}
