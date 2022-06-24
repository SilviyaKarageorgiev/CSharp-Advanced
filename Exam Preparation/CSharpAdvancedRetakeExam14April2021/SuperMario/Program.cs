using System;
using System.Collections.ObjectModel;

namespace SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            int row = 0;
            int col = 0;

            string input = Console.ReadLine();
            char[,] maze = new char[rows, input.Length];

            for (int r = 0; r < rows; r++)
            {
                if (r > 0)
                {
                    input = Console.ReadLine();
                }

                for (int c = 0; c < input.Length; c++)
                {
                    maze[r, c] = input[c];
                    if (maze[r, c] == 'M')
                    {
                        row = r;
                        col = c;
                    }
                }
            }

            int dRow = 0;
            int dCol = 0;
            bool isWon = false;

            while (lives > 0)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                char direction = char.Parse(cmdArgs[0]);
                int rowEnemy = int.Parse(cmdArgs[1]);
                int colEnemy = int.Parse(cmdArgs[2]);

                maze[rowEnemy, colEnemy] = 'B';

                if (direction == 'W') //up
                {
                    maze[row, col] = '-';
                    row--;
                    lives--;
                    if (!ValidationIndeces(maze, row, col))
                    {
                        row++;
                        maze[row, col] = 'M';
                    }
                    else
                    {
                        if (maze[row, col] == 'B')
                        {
                            lives -= 2; ;
                            if (lives > 0)
                            {
                                maze[row, col] = 'M';
                            }
                            else
                            {
                                maze[row, col] = 'X';
                                dRow = row;
                                dCol = col;
                                isWon = false;
                                break;
                            }
                        }
                        else if (maze[row, col] == 'P')
                        {
                            maze[row, col] = '-';                            
                            isWon = true;
                            break;
                        }
                        else
                        {
                            maze[row, col] = 'M';
                        }
                    }
                }
                else if (direction == 'S') //down
                {
                    maze[row, col] = '-';
                    row++;
                    lives--;
                    if (!ValidationIndeces(maze, row, col))
                    {
                        row--;
                        maze[row, col] = 'M';
                    }
                    else
                    {
                        if (maze[row, col] == 'B')
                        {
                            lives -= 2;
                            if (lives > 0)
                            {
                                maze[row, col] = 'M';
                            }
                            else
                            {
                                maze[row, col] = 'X';
                                dRow = row;
                                dCol = col;
                                isWon = false;
                                break;
                            }
                        }
                        else if (maze[row, col] == 'P')
                        {
                            maze[row, col] = '-';                            
                            isWon = true;
                            break;
                        }
                        else
                        {
                            maze[row, col] = 'M';
                        }
                    }
                }
                else if (direction == 'A') //left
                {
                    maze[row, col] = '-';
                    col--;
                    lives--;
                    if (!ValidationIndeces(maze, row, col))
                    {
                        col++;
                        maze[row, col] = 'M';
                    }
                    else
                    {
                        if (maze[row, col] == 'B')
                        {
                            lives -= 2;
                            if (lives > 0)
                            {
                                maze[row, col] = 'M';
                            }
                            else
                            {
                                maze[row, col] = 'X';
                                dRow = row;
                                dCol = col;
                                isWon = false;
                                break;
                            }
                        }
                        else if (maze[row, col] == 'P')
                        {
                            maze[row, col] = '-';                            
                            isWon= true;
                            break;
                        }
                        else
                        {
                            maze[row, col] = 'M';
                        }
                    }
                }
                else if (direction == 'D') //right
                {
                    maze[row, col] = '-';
                    col++;
                    lives--;
                    if (!ValidationIndeces(maze, row, col))
                    {
                        col--;
                        maze[row, col] = 'M';
                    }
                    else
                    {
                        if (maze[row, col] == 'B')
                        {
                            lives -= 2;
                            if (lives > 0)
                            {
                                maze[row, col] = 'M';
                            }
                            else
                            {
                                maze[row, col] = 'X';
                                dRow = row;
                                dCol = col;
                                isWon = false;
                                break;
                            }
                        }
                        else if (maze[row, col] == 'P')
                        {
                            maze[row, col] = '-';
                            isWon = true;
                            break;
                        }
                        else
                        {
                            maze[row, col] = 'M';
                        }
                    }
                }
            }
            if (isWon == true)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else if(isWon = false || lives <= 0)
            {
                Console.WriteLine($"Mario died at {dRow};{dCol}.");
            }
            PrintMaze(maze);
        }

        private static void PrintMaze(char[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    Console.Write(maze[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool ValidationIndeces(char[,] maze, int row, int col)
        {
            if (row >= 0 && row < maze.GetLength(0) && col >= 0 && col < maze.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
