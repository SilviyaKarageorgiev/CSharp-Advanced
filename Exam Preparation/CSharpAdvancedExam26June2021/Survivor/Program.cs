using System;
using System.Linq;
using System.Numerics;

namespace Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            
            char[][] jagged = new char[n][];
            int tokens = 0;
            int oponentTokens = 0;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                jagged[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    jagged[row][col] = input[col];
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "Gong")
            {
                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];

                if (command == "Find")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);

                    if (!PlaceValidation(jagged, row, col))
                    {
                        continue;
                    }
                    if (jagged[row][col] == 'T')
                    {
                        tokens++;
                        jagged[row][col] = '-';
                    }
                }
                else if (command == "Opponent")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);
                    string direction = cmdArgs[3];

                    if (!PlaceValidation(jagged, row, col))
                    {
                        continue;
                    }

                    if (jagged[row][col] == 'T')
                    {
                        oponentTokens++;
                        jagged[row][col] = '-';
                    }

                    if (direction == "up")
                    {
                        oponentTokens += OponentMovesUp(jagged, row, col);
                    }
                    else if (direction == "down")
                    {
                        oponentTokens += OponentMovesDown(jagged, row, col);
                    }
                    else if (direction == "left")
                    {
                        oponentTokens += OponentMovesLeft(jagged, row, col);
                    }
                    else if (direction == "right")
                    {
                        oponentTokens += OponentMovesRight(jagged, row, col);
                    }
                }
            }

            PrintMatrix(jagged);

            Console.WriteLine($"Collected tokens: {tokens}");
            Console.WriteLine($"Opponent's tokens: {oponentTokens}");
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        private static int OponentMovesRight(char[][] matrix, int row, int col)
        {
            int oponentTokens = 0;
            int constCol = col;

            for (int i = 1; i <= 3; i++)
            {
                col = constCol + i;
                if (!PlaceValidation(matrix, row, col))
                {
                    continue;
                }
                if (matrix[row][col] == 'T')
                {
                    oponentTokens++;
                    matrix[row][col] = '-';
                }
            }
            return oponentTokens;
        }

        private static int OponentMovesLeft(char[][] matrix, int row, int col)
        {
            int oponentTokens = 0;
            int constCol = col;

            for (int i = 1; i <= 3; i++)
            {
                col = constCol - i;
                if (!PlaceValidation(matrix, row, col))
                {
                    continue;
                }
                if (matrix[row][col] == 'T')
                {
                    oponentTokens++;
                    matrix[row][col] = '-';
                }
            }
            return oponentTokens;
        }

        private static int OponentMovesDown(char[][] matrix, int row, int col)
        {
            int oponentTokens = 0;
            int constRow = row;

            for (int i = 1; i <= 3; i++)
            {
                row = constRow + i;
                if (!PlaceValidation(matrix, row, col))
                {
                    continue;
                }
                if (matrix[row][col] == 'T')
                {
                    oponentTokens++;
                    matrix[row][col] = '-';
                }
            }
            return oponentTokens;
        }

        private static int OponentMovesUp(char[][] matrix, int row, int col)
        {
            int oponentTokens = 0;
            int constRow = row;

            for (int i = 1; i <= 3; i++)
            {
                row = constRow - i;
                if (!PlaceValidation(matrix, row, col))
                {
                    continue;
                }
                if (matrix[row][col] == 'T')
                {
                    oponentTokens++;
                    matrix[row][col] = '-';
                }
            }
            return oponentTokens;
        }

        private static bool PlaceValidation(char[][] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix[row].Length)
            {
                return false;
            }
            return true;
        }
    }
}
