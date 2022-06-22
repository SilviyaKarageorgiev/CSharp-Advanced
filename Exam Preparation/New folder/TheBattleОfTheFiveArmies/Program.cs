using System;

namespace TheBattleОfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int cols = input.Length;
            char[,] matrix = new char[rows, cols];

            int aRow = 0;
            int aCol = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row > 0)
                {
                    input = Console.ReadLine();
                }

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'A')
                    {
                        aRow = row;
                        aCol = col;
                    }
                    
                }
            }

            while (armor > 0)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                int oRow = int.Parse(cmdArgs[1]);
                int oCol = int.Parse(cmdArgs[2]);
                matrix[oRow, oCol] = 'O';

                if (command == "up")
                {
                    if (aRow - 1 < 0)
                    {
                        armor--;
                        if (armor <= 0)
                        {
                            matrix[aRow, aCol] = 'X';
                            Console.WriteLine($"The army was defeated at {aRow};{aCol}.");
                            break;
                        }
                        continue;
                    }

                    else if (matrix[aRow - 1, aCol] == 'O')
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aRow = aRow - 1;
                        matrix[aRow, aCol] = 'A';

                        armor -= 2;
                        if (armor <= 0)
                        {
                            matrix[aRow, aCol] = 'X';
                            Console.WriteLine($"The army was defeated at {aRow};{aCol}.");
                            break;
                        }
                    }

                    else if (matrix[aRow - 1, aCol] == 'M')
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aRow = aRow - 1;
                        matrix[aRow, aCol] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        break;
                    }

                    else
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aRow = aRow - 1;
                        matrix[aRow, aCol] = 'A';
                    }
                }

                else if (command == "down")
                {
                    if (aRow + 1 >= matrix.GetLength(0))
                    {
                        armor--;
                        if (armor <= 0)
                        {
                            matrix[aRow, aCol] = 'X';
                            Console.WriteLine($"The army was defeated at {aRow};{aCol}.");
                            break;
                        }
                        continue;
                    }

                    else if (matrix[aRow + 1, aCol] == 'O')
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aRow = aRow + 1;
                        matrix[aRow, aCol] = 'A';

                        armor -= 2;
                        if (armor <= 0)
                        {
                            matrix[aRow, aCol] = 'X';
                            Console.WriteLine($"The army was defeated at {aRow};{aCol}.");
                            break;
                        }
                    }

                    else if (matrix[aRow + 1, aCol] == 'M')
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aRow = aRow + 1;
                        matrix[aRow, aCol] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        break;
                    }

                    else
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aRow = aRow + 1;
                        matrix[aRow, aCol] = 'A';
                    }
                }

                else if (command == "left")
                {
                    if (aCol - 1 < 0)
                    {
                        armor--;
                        if (armor <= 0)
                        {
                            matrix[aRow, aCol] = 'X';
                            Console.WriteLine($"The army was defeated at {aRow};{aCol}.");
                            break;
                        }
                        continue;
                    }

                    else if (matrix[aRow, aCol - 1] == 'O')
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aCol = aCol - 1;
                        matrix[aRow, aCol] = 'A';

                        armor -= 2;
                        if (armor <= 0)
                        {
                            matrix[aRow, aCol] = 'X';
                            Console.WriteLine($"The army was defeated at {aRow};{aCol}.");
                            break;
                        }
                    }

                    else if (matrix[aRow, aCol - 1] == 'M')
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aCol = aCol - 1;
                        matrix[aRow, aCol] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        break;
                    }

                    else
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aCol = aCol - 1;
                        matrix[aRow, aCol] = 'A';
                    }
                }

                else if (command == "right")
                {
                    if (aCol + 1 >= matrix.GetLength(0))
                    {
                        armor--;
                        if (armor <= 0)
                        {
                            matrix[aRow, aCol] = 'X';
                            Console.WriteLine($"The army was defeated at {aRow};{aCol}.");
                            break;
                        }
                        continue;
                    }

                    else if (matrix[aRow, aCol + 1] == 'O')
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aCol = aCol + 1;
                        matrix[aRow, aCol] = 'A';

                        armor -= 2;
                        if (armor <= 0)
                        {
                            matrix[aRow, aCol] = 'X';
                            Console.WriteLine($"The army was defeated at {aRow};{aCol}.");
                            break;
                        }
                    }

                    else if (matrix[aRow, aCol + 1] == 'M')
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aCol = aCol + 1;
                        matrix[aRow, aCol] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        break;
                    }

                    else
                    {
                        armor--;
                        matrix[aRow, aCol] = '-';
                        aCol = aCol + 1;
                        matrix[aRow, aCol] = 'A';
                    }

                }

                if (armor <= 0)
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    matrix[aRow, aCol] = 'X';
                }
            }

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
    }
}
