using System;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];

            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;
            int eatenTrufflesWildBoar = 0;

            FillMatrix(matrix);

            string input;
            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];                

                if (command == "Collect")
                {
                    int rowIndex = int.Parse(cmdArgs[1]);
                    int colIndex = int.Parse(cmdArgs[2]);
                    if (!ValidationIndeces(matrix, rowIndex, colIndex))
                    {
                        continue;
                    }
                    
                    switch (matrix[rowIndex, colIndex])
                    {
                        case "B":
                            blackTruffles++;
                            matrix[rowIndex, colIndex] = "-";
                            break;
                        case "S":
                            summerTruffles++;
                            matrix[rowIndex, colIndex] = "-";
                            break;
                        case "W":
                            whiteTruffles++;
                            matrix[rowIndex, colIndex] = "-";
                            break;
                        default:
                            continue;
                    }
                }
                else if (command == "Wild_Boar")
                {
                    int rowIndex = int.Parse(cmdArgs[1]);
                    int colIndex = int.Parse(cmdArgs[2]);
                    string direction = cmdArgs[3];

                    if (direction == "up")
                    {
                        eatenTrufflesWildBoar = WildBoarMoveUp(matrix, rowIndex, colIndex, eatenTrufflesWildBoar);
                    }
                    else if (direction == "down")
                    {
                        eatenTrufflesWildBoar = WildBoarMoveDown(matrix, rowIndex, colIndex, eatenTrufflesWildBoar);
                    }
                    else if (direction == "left")
                    {
                        eatenTrufflesWildBoar = WildBoarMoveLeft(matrix, rowIndex, colIndex, eatenTrufflesWildBoar);
                    }
                    else if (direction == "right")
                    {
                        eatenTrufflesWildBoar = WildBoarMoveRight(matrix, rowIndex, colIndex, eatenTrufflesWildBoar);
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTrufflesWildBoar} truffles.");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }

        private static int WildBoarMoveRight(string[,] matrix, int rowIndex, int colIndex, int eatenTrufflesWildBoar)
        {
            for (int i = colIndex; i < matrix.GetLength(1); i += 2)
            {
                if (matrix[rowIndex, i] == "-")
                {
                    if (i == matrix.GetLength(1) - 2)
                    {
                        break;
                    }
                    continue;
                }
                eatenTrufflesWildBoar++;
                matrix[rowIndex, i] = "-";
                if (i == matrix.GetLength(0) - 2)
                {
                    break;
                }
            }
            return eatenTrufflesWildBoar;
        }

        private static int WildBoarMoveLeft(string[,] matrix, int rowIndex, int colIndex, int eatenTrufflesWildBoar)
        {
            for (int i = colIndex; i >= 0; i-=2)
            {
                if (matrix[rowIndex, i] == "-")
                {
                    if (i == 1)
                    {
                        break;
                    }
                    continue;
                }
                eatenTrufflesWildBoar++;
                matrix[rowIndex, i] = "-";
                if (i == 1)
                {
                    break;
                }
            }
            return eatenTrufflesWildBoar;
        }

        private static int WildBoarMoveDown(string[,] matrix, int rowIndex, int colIndex, int eatenTrufflesWildBoar)
        {
            for (int i = rowIndex; i < matrix.GetLength(0); i += 2)
            {
                if (matrix[i, colIndex] == "-")
                {
                    if (i == matrix.GetLength(0) - 2)
                    {
                        break;
                    }
                    continue;
                }
                eatenTrufflesWildBoar++;
                matrix[i, colIndex] = "-";
                if (i == matrix.GetLength(0) - 2)
                {
                    break;
                }
            }
            return eatenTrufflesWildBoar;
        }

        private static int WildBoarMoveUp(string[,] matrix, int rowIndex, int colIndex, int eatenTrufflesWildBoar)
        {
            for (int i = rowIndex; i >= 0; i -= 2)
            {
                if (matrix[i, colIndex] == "-")
                {
                    if (i == 1)
                    {
                        break;
                    }
                    continue;
                }
                eatenTrufflesWildBoar++;
                matrix[i, colIndex] = "-";
                if (i == 1)
                {
                    break;
                }
            }
            return eatenTrufflesWildBoar;
        }

        private static bool ValidationIndeces(string[,] matrix, int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= matrix.GetLength(0) || colIndex < 0 || colIndex >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
