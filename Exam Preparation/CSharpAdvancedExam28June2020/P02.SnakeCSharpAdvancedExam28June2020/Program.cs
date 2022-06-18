using System;

namespace P02.SnakeCSharpAdvancedExam28June2020
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int positionRow = 0;
            int positionCol = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        positionRow = row;
                        positionCol = col;
                    }
                }
            }

            int food = 0;
            string command = Console.ReadLine();
            while (true)
            {
                matrix[positionRow, positionCol] = '.';
                if (CheckIfGoesOutside(command, matrix, positionRow, positionCol))
                {
                    Console.WriteLine("Game over!");
                    Print(food, matrix);
                    return;
                }
                switch (command)
                {
                    case "up":

                        positionRow = positionRow - 1;

                        if (matrix[positionRow, positionCol] == '*')
                        {
                            food++;
                            if (food == 10)
                            {
                                Console.WriteLine("You won! You fed the snake.");
                                matrix[positionRow, positionCol] = 'S';
                                Print(food, matrix);
                                return;
                            }
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            matrix[positionRow, positionCol] = '.';

                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        positionRow = row;
                                        positionCol = col;
                                        matrix[positionRow, positionCol] = 'S';
                                    }
                                }
                            }
                        }
                        matrix[positionRow, positionCol] = 'S';
                        break;

                    case "down":

                        positionRow = positionRow + 1;

                        if (matrix[positionRow, positionCol] == '*')
                        {
                            food++;
                            if (food == 10)
                            {
                                Console.WriteLine("You won! You fed the snake.");
                                matrix[positionRow, positionCol] = 'S';
                                Print(food, matrix);
                                return;
                            }
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            matrix[positionRow, positionCol] = '.';

                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        positionRow = row;
                                        positionCol = col;
                                        matrix[positionRow, positionCol] = 'S';
                                    }
                                }
                            }
                        }
                        matrix[positionRow, positionCol] = 'S';
                        break;

                    case "left":

                        positionCol = positionCol - 1;


                        if (matrix[positionRow, positionCol] == '*')
                        {
                            food++;
                            if (food == 10)
                            {
                                Console.WriteLine("You won! You fed the snake.");
                                matrix[positionRow, positionCol] = 'S';
                                Print(food, matrix);
                                return;
                            }
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            matrix[positionRow, positionCol] = '.';

                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        positionRow = row;
                                        positionCol = col;
                                        matrix[positionRow, positionCol] = 'S';
                                    }
                                }
                            }
                        }
                        matrix[positionRow, positionCol] = 'S';
                        break;

                    case "right":

                        positionCol = positionCol + 1;

                        if (matrix[positionRow, positionCol] == '*')
                        {
                            food++;
                            if (food == 10)
                            {
                                Console.WriteLine("You won! You fed the snake.");
                                matrix[positionRow, positionCol] = 'S';
                                Print(food, matrix);
                                return;
                            }
                        }
                        else if (matrix[positionRow, positionCol] == 'B')
                        {
                            matrix[positionRow, positionCol] = '.';

                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        positionRow = row;
                                        positionCol = col;
                                        matrix[positionRow, positionCol] = 'S';
                                    }
                                }
                            }
                        }
                        matrix[positionRow, positionCol] = 'S';                        
                        break;
                }
                command = Console.ReadLine();
            }
        }

        private static void Print(int food, char[,] matrix)
        {
            Console.WriteLine($"Food eaten: {food}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        
        private static bool CheckIfGoesOutside(string command, char[,] matrix, int positionRow, int positionCol)
        {
            if (command == "up" && (positionRow - 1 < 0 || positionRow - 1 >= matrix.GetLength(0)))
            {
                return true;
            }
            else if (command == "down" && (positionRow + 1 < 0 || positionRow + 1 >= matrix.GetLength(0)))
            {
                return true;
            }
            else if (command == "left" && (positionCol - 1 < 0 || positionCol - 1 >= matrix.GetLength(1)))
            {
                return true;
            }
            else if (command == "right" && (positionCol + 1 < 0 || positionCol + 1 >= matrix.GetLength(1)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
