using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Intrinsics.Arm;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int rowIndex = 0;
            int colIndex = 0;
            int coins = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'A')
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            string command = Console.ReadLine();
            while (true)
            {
                if (command == "up")
                {
                    matrix[rowIndex, colIndex] = '-';
                    rowIndex = rowIndex - 1;
                    if (!CheckIfIsInTheArmory(matrix, rowIndex, colIndex))
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    if (matrix[rowIndex, colIndex] == 'M')
                    {
                        matrix[rowIndex, colIndex] = '-';
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'M')
                                {
                                    rowIndex = row;
                                    colIndex = col;
                                    matrix[rowIndex, colIndex] = 'A';
                                }
                            }
                        }
                    }
                    else if (char.IsDigit(matrix[rowIndex, colIndex]))
                    {
                        coins += matrix[rowIndex, colIndex] - 48;
                        matrix[rowIndex, colIndex] = 'A';
                        if (coins >= 65)
                        {
                            Console.WriteLine("Very nice swords, I will come back for more!");
                            break;
                        }
                    }
                }

                else if (command == "down")
                {
                    matrix[rowIndex, colIndex] = '-';
                    rowIndex = rowIndex + 1;
                    if (!CheckIfIsInTheArmory(matrix, rowIndex, colIndex))
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    if (matrix[rowIndex, colIndex] == 'M')
                    {
                        matrix[rowIndex, colIndex] = '-';
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'M')
                                {
                                    rowIndex = row;
                                    colIndex = col;
                                    matrix[rowIndex, colIndex] = 'A';
                                }
                            }
                        }
                    }
                    else if (char.IsDigit(matrix[rowIndex, colIndex]))
                    {
                        coins += matrix[rowIndex, colIndex] - 48;
                        matrix[rowIndex, colIndex] = 'A';
                        if (coins >= 65)
                        {
                            Console.WriteLine("Very nice swords, I will come back for more!");
                            break;
                        }
                    }
                }

                else if (command == "left")
                {
                    matrix[rowIndex, colIndex] = '-';
                    colIndex = colIndex - 1;
                    if (!CheckIfIsInTheArmory(matrix, rowIndex, colIndex))
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    if (matrix[rowIndex, colIndex] == 'M')
                    {
                        matrix[rowIndex, colIndex] = '-';
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'M')
                                {
                                    rowIndex = row;
                                    colIndex = col;
                                    matrix[rowIndex, colIndex] = 'A';
                                }
                            }
                        }
                    }
                    else if (char.IsDigit(matrix[rowIndex, colIndex]))
                    {
                        coins += matrix[rowIndex, colIndex] - 48;
                        matrix[rowIndex, colIndex] = 'A';
                        if (coins >= 65)
                        {
                            Console.WriteLine("Very nice swords, I will come back for more!");
                            break;
                        }
                    }
                }

                else if (command == "right")
                {
                    matrix[rowIndex, colIndex] = '-';
                    colIndex = colIndex + 1;
                    if (!CheckIfIsInTheArmory(matrix, rowIndex, colIndex))
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    if (matrix[rowIndex, colIndex] == 'M')
                    {
                        matrix[rowIndex, colIndex] = '-';
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'M')
                                {
                                    rowIndex = row;
                                    colIndex = col;
                                    matrix[rowIndex, colIndex] = 'A';
                                }
                            }
                        }
                    }
                    else if (char.IsDigit(matrix[rowIndex, colIndex]))
                    {
                        coins += matrix[rowIndex, colIndex] - 48;
                        matrix[rowIndex, colIndex] = 'A';
                        if (coins >= 65)
                        {
                            Console.WriteLine("Very nice swords, I will come back for more!");
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"The king paid {coins} gold coins.");
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

        private static bool CheckIfIsInTheArmory(char[,] matrix, int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= matrix.GetLength(0) || colIndex < 0 || colIndex >= matrix.GetLength(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
