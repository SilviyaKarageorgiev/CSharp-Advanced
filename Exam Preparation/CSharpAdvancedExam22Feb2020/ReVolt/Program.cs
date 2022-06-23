using System;
using System.Collections.Generic;
using System.Linq;

namespace ReVolt
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int pRow = 0;
            int pCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'f')
                    {
                        pRow = row;
                        pCol = col;
                    }
                }
            }
            bool isWon = false;

            while (countOfCommands > 0)
            {
                string command = Console.ReadLine();
                countOfCommands--;
                if (command == "up")
                {
                    if (MovesUp(matrix, ref pRow, ref pCol))
                    {
                        isWon = true;
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (MovesDown(matrix, ref pRow, ref pCol))
                    {
                        isWon = true;
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (MovesLeft(matrix, ref pRow, ref pCol))
                    {
                        isWon = true;
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (MovesRight(matrix, ref pRow, ref pCol))
                    {
                        isWon = true;
                        break;
                    }
                }
            }

            if (isWon == false)
            {
                Console.WriteLine("Player lost!");
            }
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

        private static bool MovesRight(char[,] matrix, ref int pRow, ref int pCol)
        {
            matrix[pRow, pCol] = '-';

            if (pCol + 1 >= matrix.GetLength(1))
            {
                pCol = 0;

                if (matrix[pRow, pCol] == 'B')
                {
                    pCol = pCol + 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'T')
                {
                    pCol = matrix.GetLength(1) - 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'F')
                {
                    matrix[pRow, pCol] = 'f';
                    Console.WriteLine("Player won!");
                    return true;
                }
            }
            else
            {
                pCol = pCol + 1;

                if (matrix[pRow, pCol] == 'B')
                {
                    if (pCol == matrix.GetLength(1) - 1)
                    {
                        pCol = 0;
                    }
                    else
                    {
                        pCol = pCol + 1;
                    }
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'T')
                {
                    pCol = pCol - 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'F')
                {
                    matrix[pRow, pCol] = 'f';
                    Console.WriteLine("Player won!");
                    return true;
                }
                matrix[pRow, pCol] = 'f';

            }
            return false;
        }

        private static bool MovesLeft(char[,] matrix, ref int pRow, ref int pCol)
        {
            matrix[pRow, pCol] = '-';

            if (pCol - 1 < 0)
            {
                pCol = matrix.GetLength(1) - 1;

                if (matrix[pRow, pCol] == 'B')
                {
                    pCol = pCol - 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'T')
                {
                    pCol = 0;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'F')
                {
                    matrix[pRow, pCol] = 'f';
                    Console.WriteLine("Player won!");
                    return true; ;
                }
            }
            else
            {
                pCol = pCol - 1;

                if (matrix[pRow, pCol] == 'B')
                {
                    if (pCol == 0)
                    {
                        pCol = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        pCol = pCol - 1;
                    }
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'T')
                {
                    pCol = pCol + 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'F')
                {
                    matrix[pRow, pCol] = 'f';
                    Console.WriteLine("Player won!");
                    return true;
                }
                matrix[pRow, pCol] = 'f';

            }
            return false;
        }

        private static bool MovesDown(char[,] matrix, ref int pRow, ref int pCol)
        {
            matrix[pRow, pCol] = '-';

            if (pRow + 1 >= matrix.GetLength(0))
            {
                pRow = 0;

                if (matrix[pRow, pCol] == 'B')
                {
                    pRow = pRow + 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'T')
                {
                    pRow = matrix.GetLength(0) - 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'F')
                {
                    matrix[pRow, pCol] = 'f';
                    Console.WriteLine("Player won!");
                    return true;
                }
            }
            else
            {
                pRow = pRow + 1;

                if (matrix[pRow, pCol] == 'B')
                {
                    if (pRow == matrix.GetLength(0) - 1)
                    {
                        pRow = 0;
                    }
                    else
                    {
                        pRow = pRow + 1;
                    }
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'T')
                {
                    pRow = pRow - 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'F')
                {
                    matrix[pRow, pCol] = 'f';
                    Console.WriteLine("Player won!");
                    return true;
                }
                matrix[pRow, pCol] = 'f';

            }
            return false;
        }

        private static bool MovesUp(char[,] matrix, ref int pRow, ref int pCol)
        {
            matrix[pRow, pCol] = '-';

            if (pRow - 1 < 0)
            {
                pRow = matrix.GetLength(0) - 1;

                if (matrix[pRow, pCol] == 'B')
                {
                    pRow = pRow - 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'T')
                {
                    pRow = 0;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'F')
                {
                    matrix[pRow, pCol] = 'f';
                    Console.WriteLine("Player won!");
                    return true; ;
                }

            }
            else
            {
                pRow = pRow - 1;

                if (matrix[pRow, pCol] == 'B')
                {
                    if (pRow == 0)
                    {
                        pRow = matrix.GetLength(0) - 1;
                    }
                    else
                    {
                        pRow = pRow - 1;
                    }                    
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'T')
                {
                    pRow = pRow + 1;
                    matrix[pRow, pCol] = 'f';
                }
                if (matrix[pRow, pCol] == 'F')
                {
                    matrix[pRow, pCol] = 'f';
                    Console.WriteLine("Player won!");
                    return true;
                }
                matrix[pRow, pCol] = 'f';

            }
            return false;
        }
    }
}
