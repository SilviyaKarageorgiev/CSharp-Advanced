using System;

namespace Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int sRow = 0;
            int sCol = 0;
            int money = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        sRow = row;
                        sCol = col;
                    }
                }
            }

            while (money < 50)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    matrix[sRow, sCol] = '-';
                    sRow--;
                    if (!ValidationIndeces(matrix, sRow, sCol))
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(matrix[sRow, sCol]))
                    {
                        money += matrix[sRow, sCol] - 48;

                    }
                    else if (matrix[sRow, sCol] == 'O')
                    {
                        matrix[sRow, sCol] = '-';

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    sRow = row;
                                    sCol = col;
                                }
                            }
                        }
                    }
                    matrix[sRow, sCol] = 'S';
                }
                else if (command == "down")
                {
                    matrix[sRow, sCol] = '-';
                    sRow++;
                    if (!ValidationIndeces(matrix, sRow, sCol))
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(matrix[sRow, sCol]))
                    {
                        money += matrix[sRow, sCol] - 48;

                    }
                    else if (matrix[sRow, sCol] == 'O')
                    {
                        matrix[sRow, sCol] = '-';

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    sRow = row;
                                    sCol = col;
                                }
                            }
                        }
                    }
                    matrix[sRow, sCol] = 'S';
                }
                else if (command == "left")
                {
                    matrix[sRow, sCol] = '-';
                    sCol--;
                    if (!ValidationIndeces(matrix, sRow, sCol))
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(matrix[sRow, sCol]))
                    {
                        money += matrix[sRow, sCol] - 48;

                    }
                    else if (matrix[sRow, sCol] == 'O')
                    {
                        matrix[sRow, sCol] = '-';

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    sRow = row;
                                    sCol = col;
                                }
                            }
                        }
                    }
                    matrix[sRow, sCol] = 'S';
                }
                else if (command == "right")
                {
                    matrix[sRow, sCol] = '-';
                    sCol++;
                    if (!ValidationIndeces(matrix, sRow, sCol))
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        break;
                    }

                    if (char.IsDigit(matrix[sRow, sCol]))
                    {
                        money += matrix[sRow, sCol] - 48;

                    }
                    else if (matrix[sRow, sCol] == 'O')
                    {
                        matrix[sRow, sCol] = '-';

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
                                {
                                    sRow = row;
                                    sCol = col;
                                }
                            }
                        }
                    }
                    matrix[sRow, sCol] = 'S';
                }
            }

            if (money >= 50)
            {
                Console.WriteLine($"Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {money}");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }

        private static bool ValidationIndeces(char[,] matrix, int sRow, int sCol)
        {
            if (sRow >= 0 && sRow < matrix.GetLength(0) && sCol >= 0 && sCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
