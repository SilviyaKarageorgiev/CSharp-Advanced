using System;

namespace P07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int rows = int.Parse(Console.ReadLine());

            long[][] pascal = new long[rows][];
            pascal[0] = new long[1] { 1 };

            for (int row = 1; row < pascal.GetLength(0); row++)
            {
                pascal[row] = new long[pascal[row - 1].Length + 1];
                pascal[row][0] = 1;

                for (int col = 1; col < pascal[row].Length; col++)
                {
                    if (pascal[row - 1].Length > col)
                    {
                        pascal[row][col] = pascal[row - 1][col - 1] + pascal[row - 1][col];
                    }
                    else
                    {
                        pascal[row][col] = 1;
                    }
                }
            }

            for (int row = 0; row < pascal.GetLength(0); row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write(pascal[row][col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
