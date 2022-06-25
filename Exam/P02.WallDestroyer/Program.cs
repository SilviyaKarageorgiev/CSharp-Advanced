using System;

namespace P02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int vRow = 0;
            int vCol = 0;
            int holes = 1;
            int hitRods = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'V')
                    {
                        vRow = row;
                        vCol = col;
                    }
                }
            }
            bool isElectrocuted = false;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {

                if (command == "up")
                {
                    vRow--;
                    if (!ValidationIndeces(matrix, vRow, vCol))
                    {
                        vRow++;
                        continue;
                    }

                    if (matrix[vRow, vCol] == 'R')
                    {
                        vRow++;
                        hitRods++;
                        Console.WriteLine("Vanko hit a rod!");
                        continue;
                    }
                    else if (matrix[vRow, vCol] == '*')
                    {
                        matrix[vRow + 1, vCol] = '*';
                        matrix[vRow, vCol] = 'V';
                        Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        continue;
                    }
                    else if (matrix[vRow, vCol] == '-')
                    {
                        matrix[vRow + 1, vCol] = '*';
                        matrix[vRow, vCol] = 'V';
                        holes++;
                    }
                    else if (matrix[vRow, vCol] == 'C')
                    {
                        matrix[vRow + 1, vCol] = '*';
                        matrix[vRow, vCol] = 'E';
                        holes++;
                        isElectrocuted = true;
                        break;
                    }
                    else
                    {
                        matrix[vRow + 1, vCol] = '*';
                        matrix[vRow, vCol] = 'V';
                        holes++;
                    }
                }

                else if (command == "down")
                {
                    vRow++;
                    if (!ValidationIndeces(matrix, vRow, vCol))
                    {
                        vRow--;
                        continue;
                    }

                    if (matrix[vRow, vCol] == 'R')
                    {
                        vRow--;
                        hitRods++;
                        Console.WriteLine("Vanko hit a rod!");
                        continue;
                    }
                    else if (matrix[vRow, vCol] == '*')
                    {
                        matrix[vRow - 1, vCol] = '*';
                        matrix[vRow, vCol] = 'V';
                        Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        continue;
                    }
                    else if (matrix[vRow, vCol] == '-')
                    {
                        matrix[vRow - 1, vCol] = '*';
                        matrix[vRow, vCol] = 'V';
                        holes++;
                    }
                    else if (matrix[vRow, vCol] == 'C')
                    {
                        matrix[vRow - 1, vCol] = '*';
                        matrix[vRow, vCol] = 'E';
                        holes++;
                        isElectrocuted = true;
                        break;
                    }
                    else
                    {
                        matrix[vRow - 1, vCol] = '*';
                        matrix[vRow, vCol] = 'V';
                        holes++;
                    }
                }

                else if (command == "left")
                {
                    vCol--;
                    if (!ValidationIndeces(matrix, vRow, vCol))
                    {
                        vCol++;
                        continue;
                    }

                    if (matrix[vRow, vCol] == 'R')
                    {
                        vCol++;
                        hitRods++;
                        Console.WriteLine("Vanko hit a rod!");
                        continue;
                    }
                    else if (matrix[vRow, vCol] == '*')
                    {
                        matrix[vRow, vCol + 1] = '*';
                        matrix[vRow, vCol] = 'V';
                        Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        continue;
                    }
                    else if (matrix[vRow, vCol] == '-')
                    {
                        matrix[vRow, vCol + 1] = '*';
                        matrix[vRow, vCol] = 'V';
                        holes++;
                    }
                    else if (matrix[vRow, vCol] == 'C')
                    {
                        matrix[vRow, vCol + 1] = '*';
                        matrix[vRow, vCol] = 'E';
                        holes++;
                        isElectrocuted = true;
                        break;
                    }
                    else
                    {
                        matrix[vRow, vCol + 1] = '*';
                        matrix[vRow, vCol] = 'V';
                        holes++;
                    }
                }

                else if (command == "right")
                {
                    vCol++;
                    if (!ValidationIndeces(matrix, vRow, vCol))
                    {
                        vCol--;
                        continue;
                    }

                    if (matrix[vRow, vCol] == 'R')
                    {
                        vCol--;
                        hitRods++;
                        Console.WriteLine("Vanko hit a rod!");
                        continue;
                    }
                    else if (matrix[vRow, vCol] == '*')
                    {
                        matrix[vRow, vCol - 1] = '*';
                        matrix[vRow, vCol] = 'V';
                        Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        continue;
                    }
                    else if (matrix[vRow, vCol] == '-')
                    {
                        matrix[vRow, vCol - 1] = '*';
                        matrix[vRow, vCol] = 'V';
                        holes++;
                    }
                    else if (matrix[vRow, vCol] == 'C')
                    {
                        matrix[vRow, vCol - 1] = '*';
                        matrix[vRow, vCol] = 'E';
                        holes++;
                        isElectrocuted = true;
                        break;
                    }
                    else
                    {
                        matrix[vRow, vCol - 1] = '*';
                        matrix[vRow, vCol] = 'V';
                        holes++;
                    }
                }
            }

            if (isElectrocuted == true)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {hitRods} rod(s).");
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

        private static bool ValidationIndeces(char[,] matrix, int vRow, int vCol)
        {
            if (vRow >= 0 && vRow < matrix.GetLength(0) && vCol >= 0 && vCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
