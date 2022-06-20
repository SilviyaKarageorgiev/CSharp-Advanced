using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            List<char> list = new List<char>();
            int rowIndex = 0;
            int colIndex = 0;
            int counterWoodBranch = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = char.Parse(input[col]);
                    if (matrix[row, col] == 'B')
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                    else if (char.IsLower(matrix[row, col]))
                    {
                        counterWoodBranch++;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up")
                {
                    if (rowIndex - 1 < 0)
                    {
                        if (list.Count > 0)
                        {
                            list.Remove(list[list.Count() - 1]);
                            counterWoodBranch--;
                        }
                        matrix[rowIndex, colIndex] = 'B';
                        continue;
                    }
                    matrix[rowIndex, colIndex] = '-';
                    rowIndex = rowIndex - 1;
                    if (matrix[rowIndex, colIndex] == 'F')
                    {
                        matrix[rowIndex, colIndex] = 'B';

                        if (rowIndex == 0)
                        {
                            matrix[rowIndex, colIndex] = '-';
                            rowIndex = matrix.GetLength(0) - 1;
                            matrix[rowIndex, colIndex] = 'B';

                            if (char.IsLower(matrix[rowIndex, colIndex]))
                            {
                                list.Add(matrix[rowIndex, colIndex]);
                                matrix[rowIndex, colIndex] = 'B';
                            }
                        }
                        else
                        {
                            matrix[rowIndex, colIndex] = '-';
                            rowIndex = 0;

                            if (char.IsLower(matrix[rowIndex, colIndex]))
                            {
                                list.Add(matrix[rowIndex, colIndex]);
                                matrix[rowIndex, colIndex] = 'B';
                            }
                        }
                    }
                    else if (char.IsLower(matrix[rowIndex, colIndex]))
                    {
                        list.Add(matrix[rowIndex, colIndex]);
                        matrix[rowIndex, colIndex] = 'B';
                    }
                    else
                    {
                        matrix[rowIndex, colIndex] = 'B';
                    }
                }

                else if (command == "down")
                {

                    if (rowIndex + 1 > matrix.GetLength(0) - 1)
                    {
                        if (list.Count > 0)
                        {
                            list.Remove(list[list.Count() - 1]);
                            counterWoodBranch--;
                        }
                        matrix[rowIndex, colIndex] = 'B';
                        continue;
                    }
                    matrix[rowIndex, colIndex] = '-';
                    rowIndex = rowIndex + 1;
                    if (matrix[rowIndex, colIndex] == 'F')
                    {
                        matrix[rowIndex, colIndex] = 'B';

                        if (rowIndex == matrix.GetLength(0) - 1)
                        {
                            matrix[rowIndex, colIndex] = '-';
                            rowIndex = 0;
                            matrix[rowIndex, colIndex] = 'B';

                            if (char.IsLower(matrix[rowIndex, colIndex]))
                            {
                                list.Add(matrix[rowIndex, colIndex]);
                                matrix[rowIndex, colIndex] = 'B';
                            }

                        }
                        else
                        {
                            matrix[rowIndex, colIndex] = '-';
                            rowIndex = matrix.GetLength(0) - 1;

                            if (char.IsLower(matrix[rowIndex, colIndex]))
                            {
                                list.Add(matrix[rowIndex, colIndex]);
                                matrix[rowIndex, colIndex] = 'B';
                            }
                        }
                    }
                    else if (char.IsLower(matrix[rowIndex, colIndex]))
                    {
                        list.Add(matrix[rowIndex, colIndex]);
                        matrix[rowIndex, colIndex] = 'B';
                    }
                    else
                    {
                        matrix[rowIndex, colIndex] = 'B';
                    }
                }

                else if (command == "left")
                {

                    if (colIndex - 1 < 0)
                    {
                        if (list.Count > 0)
                        {
                            list.Remove(list[list.Count() - 1]);
                            counterWoodBranch--;
                        }
                        matrix[rowIndex, colIndex] = 'B';
                        continue;
                    }
                    matrix[rowIndex, colIndex] = '-';
                    colIndex = colIndex - 1;
                    if (matrix[rowIndex, colIndex] == 'F')
                    {
                        matrix[rowIndex, colIndex] = 'B';

                        if (colIndex == 0)
                        {
                            matrix[rowIndex, colIndex] = '-';
                            colIndex = matrix.GetLength(1) - 1;
                            matrix[rowIndex, colIndex] = 'B';

                            if (char.IsLower(matrix[rowIndex, colIndex]))
                            {
                                list.Add(matrix[rowIndex, colIndex]);
                                matrix[rowIndex, colIndex] = 'B';
                            }

                        }
                        else
                        {
                            matrix[rowIndex, colIndex] = '-';
                            colIndex = 0;

                            if (char.IsLower(matrix[rowIndex, colIndex]))
                            {
                                list.Add(matrix[rowIndex, colIndex]);
                                matrix[rowIndex, colIndex] = 'B';
                            }
                        }
                    }
                    else if (char.IsLower(matrix[rowIndex, colIndex]))
                    {
                        list.Add(matrix[rowIndex, colIndex]);
                        matrix[rowIndex, colIndex] = 'B';
                    }
                    else
                    {
                        matrix[rowIndex, colIndex] = 'B';
                    }
                }

                else if (command == "right")
                {

                    if (colIndex + 1 > matrix.GetLength(1) - 1)
                    {
                        if (list.Count > 0)
                        {
                            list.Remove(list[list.Count() - 1]);
                            counterWoodBranch--;
                        }
                        matrix[rowIndex, colIndex] = 'B';
                        continue;
                    }
                    matrix[rowIndex, colIndex] = '-';
                    colIndex = colIndex + 1;
                    if (matrix[rowIndex, colIndex] == 'F')
                    {
                        matrix[rowIndex, colIndex] = 'B';

                        if (colIndex == matrix.GetLength(1) - 1)
                        {
                            matrix[rowIndex, colIndex] = '-';
                            colIndex = 0;
                            matrix[rowIndex, colIndex] = 'B';
                            if (char.IsLower(matrix[rowIndex, colIndex]))
                            {
                                list.Add(matrix[rowIndex, colIndex]);
                                matrix[rowIndex, colIndex] = 'B';
                            }

                        }
                        else
                        {
                            matrix[rowIndex, colIndex] = '-';
                            colIndex = matrix.GetLength(1) - 1;

                            if (char.IsLower(matrix[rowIndex, colIndex]))
                            {
                                list.Add(matrix[rowIndex, colIndex]);
                                matrix[rowIndex, colIndex] = 'B';
                            }

                        }
                    }
                    else if (char.IsLower(matrix[rowIndex, colIndex]))
                    {
                        list.Add(matrix[rowIndex, colIndex]);
                        matrix[rowIndex, colIndex] = 'B';
                    }
                    else
                    {
                        matrix[rowIndex, colIndex] = 'B';
                    }
                }
                if (list.Count() == counterWoodBranch)
                {
                    break;
                }
            }


            if (list.Count() == counterWoodBranch)
            {
                Console.WriteLine($"The Beaver successfully collect {counterWoodBranch} wood branches: {string.Join(", ", list)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {counterWoodBranch - list.Count()} branches left.");
            }

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(char[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == matrix.GetLength(1) - 1)
                    {
                        Console.Write($"{matrix[row, col]}");
                    }
                    else
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
