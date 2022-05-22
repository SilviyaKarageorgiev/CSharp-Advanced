using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] rowsCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char>(snake);
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = queue.Peek();
                        queue.Enqueue(queue.Dequeue());
                    }
                }
                
            }

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(char[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }

        }
    }
}
