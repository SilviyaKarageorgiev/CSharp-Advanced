using System;

namespace P07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            FillMatrix(matrix);

            int maxCount = 0;
            int rowIndexMaxCount = 0;
            int colIndexMaxCount = 0;
            int removedKnights = 0;

            CrawlingMatrix(matrix, maxCount, rowIndexMaxCount, colIndexMaxCount, removedKnights);            
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void CrawlingMatrix(char[,] matrix, int maxCount, int rowIndexMaxCount, int colIndexMaxCount, int removedKnights)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currElement = matrix[row, col];

                    if (currElement == '0')
                    {
                        continue;
                    }
                    int counter = CounterKnight(matrix, row, col);
                    if (counter > maxCount)
                    {
                        maxCount = counter;
                        rowIndexMaxCount = row;
                        colIndexMaxCount = col;
                    }
                }
            }
            

            if (maxCount != 0)
            {
                matrix[rowIndexMaxCount, colIndexMaxCount] = '0';
                removedKnights++;
                maxCount = 0;
                CrawlingMatrix(matrix, maxCount, rowIndexMaxCount, colIndexMaxCount, removedKnights);
            }
            else
            {
                Console.WriteLine(removedKnights);
            }

            
        }

        private static int CounterKnight(char[,] matrix, int row, int col)
        {
            int counter = 0;
            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) && col - 2 >= 0 && col - 2 < matrix.GetLength(1) && matrix[row - 1, col - 2] == 'K')
            {
                counter++;
            }
            if (row - 2 >= 0 && row - 2 < matrix.GetLength(0) && col - 1 >= 0 && col - 1 < matrix.GetLength(1) && matrix[row - 2, col - 1] == 'K')
            {
                counter++;
            }
            if (row - 2 >= 0 && row - 2 < matrix.GetLength(0) && col + 1 >= 0 && col + 1 < matrix.GetLength(1) && matrix[row - 2, col + 1] == 'K')
            {
                counter++;
            }
            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) && col + 2 >= 0 && col + 2 < matrix.GetLength(1) && matrix[row - 1, col + 2] == 'K')
            {
                counter++;
            }

            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) && col - 2 >= 0 && col - 2 < matrix.GetLength(1) && matrix[row + 1, col - 2] == 'K')
            {
                counter++;
            }
            if (row + 2 >= 0 && row + 2 < matrix.GetLength(0) && col - 1 >= 0 && col - 1 < matrix.GetLength(1) && matrix[row + 2, col - 1] == 'K')
            {
                counter++;
            }
            if (row + 2 >= 0 && row + 2 < matrix.GetLength(0) && col + 1 >= 0 && col + 1 < matrix.GetLength(1) && matrix[row + 2, col + 1] == 'K')
            {
                counter++;
            }
            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) && col + 2 >= 0 && col + 2 < matrix.GetLength(1) && matrix[row + 1, col + 2] == 'K')
            {
                counter++;
            }
            return counter;
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
