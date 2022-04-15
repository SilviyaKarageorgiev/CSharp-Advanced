using System;
using System.Linq;

namespace P09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            char[,] matrix = new char[n, n];
            int currRowIndex = 0;
            int currColIndex = 0;
            int coalsInField = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputMatrix[col][0];

                    if (matrix[row,col] == 's')
                    {
                        currRowIndex = row;
                        currColIndex = col;
                    }
                    if (matrix[row,col] == 'c')
                    {
                        coalsInField++;
                    }
                }
            }

            int counterCoals = 0;
            for (int i = 0; i < commands.Length; i++)
            {
                string currCommand = commands[i];

                if (currCommand == "up" && currRowIndex - 1 >= 0 && currRowIndex - 1 < matrix.GetLength(0) && currColIndex >= 0 && currColIndex < matrix.GetLength(0))
                {
                    currRowIndex = currRowIndex - 1;

                    if (matrix[currRowIndex,currColIndex] == 'c')
                    {
                        counterCoals++;
                        matrix[currRowIndex, currColIndex] = '*';
                        if (counterCoals == coalsInField)
                        {
                            Console.WriteLine($"You collected all coals! ({currRowIndex}, {currColIndex})");
                            Environment.Exit(0);
                        }
                    }
                    else if (matrix[currRowIndex, currColIndex] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                        Environment.Exit(0);
                    }
                }

                else if (currCommand == "down" && currRowIndex + 1 >= 0 && currRowIndex + 1 < matrix.GetLength(0) && currColIndex >= 0 && currColIndex < matrix.GetLength(0))
                {
                    currRowIndex = currRowIndex + 1;

                    if (matrix[currRowIndex, currColIndex] == 'c')
                    {
                        counterCoals++;
                        matrix[currRowIndex, currColIndex] = '*';
                        if (counterCoals == coalsInField)
                        {
                            Console.WriteLine($"You collected all coals! ({currRowIndex}, {currColIndex})");
                            Environment.Exit(0);
                        }
                    }
                    else if (matrix[currRowIndex, currColIndex] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                        Environment.Exit(0);
                    }
                }

                else if (currCommand == "right" && currRowIndex >= 0 && currRowIndex < matrix.GetLength(0) && currColIndex + 1 >= 0 && currColIndex + 1 < matrix.GetLength(0))
                {
                    currColIndex = currColIndex + 1;

                    if (matrix[currRowIndex, currColIndex] == 'c')
                    {
                        counterCoals++;
                        matrix[currRowIndex, currColIndex] = '*';
                        if (counterCoals == coalsInField)
                        {
                            Console.WriteLine($"You collected all coals! ({currRowIndex}, {currColIndex})");
                            Environment.Exit(0);
                        }
                    }
                    else if (matrix[currRowIndex, currColIndex] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                        Environment.Exit(0);
                    }

                }

                else if (currCommand == "left" && currRowIndex >= 0 && currRowIndex < matrix.GetLength(0) && currColIndex - 1 >= 0 && currColIndex - 1 < matrix.GetLength(0))
                {
                    currColIndex = currColIndex - 1;

                    if (matrix[currRowIndex, currColIndex] == 'c')
                    {
                        counterCoals++;
                        matrix[currRowIndex, currColIndex] = '*';
                        if (counterCoals == coalsInField)
                        {
                            Console.WriteLine($"You collected all coals! ({currRowIndex}, {currColIndex})");
                            Environment.Exit(0);
                        }
                    }
                    else if (matrix[currRowIndex, currColIndex] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currRowIndex}, {currColIndex})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{coalsInField - counterCoals} coals left. ({currRowIndex}, {currColIndex})");
        }
    }
}
