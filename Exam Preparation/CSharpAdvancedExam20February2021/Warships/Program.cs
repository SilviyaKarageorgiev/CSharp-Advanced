using System;
using System.Linq;

namespace Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int shipsOfPlayerOne = 0;
            int shipsOfPlayerTwo = 0;

            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < n; row++)
            {
                char[] inputMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputMatrix[col];
                    if (matrix[row, col] == '<')
                    {
                        shipsOfPlayerOne++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        shipsOfPlayerTwo++;
                    }
                }
            }

            int shipsFirst = shipsOfPlayerOne;
            int shipsSecond = shipsOfPlayerTwo;

            int rowIndex = 0;
            int colIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] indeces = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                rowIndex = int.Parse(indeces[0]);
                colIndex = int.Parse(indeces[1]);


                if (!ValidationIndeces(matrix, rowIndex, colIndex))
                {
                    continue;
                }
                if (matrix[rowIndex, colIndex] == '>')
                {
                    matrix[rowIndex, colIndex] = 'X';
                    shipsSecond--;
                    if (shipsSecond == 0)
                    {
                        break;
                    }
                }
                else if (matrix[rowIndex, colIndex] == '<')
                {
                    matrix[rowIndex, colIndex] = 'X';
                    shipsFirst--;
                    if (shipsFirst == 0)
                    {
                        break;
                    }
                }
                else if (matrix[rowIndex, colIndex] == '#')
                {
                    matrix[rowIndex, colIndex] = 'X';

                    if (ValidationIndeces(matrix, rowIndex - 1, colIndex))
                    {
                        if (matrix[rowIndex - 1, colIndex] == '>')
                        {
                            shipsSecond--;

                        }
                        if (matrix[rowIndex - 1, colIndex] == '<')
                        {
                            shipsFirst--;

                        }
                        matrix[rowIndex - 1, colIndex] = 'X';
                    }
                    if (ValidationIndeces(matrix, rowIndex - 1, colIndex - 1))
                    {
                        if (matrix[rowIndex - 1, colIndex - 1] == '>')
                        {
                            shipsSecond--;

                        }
                        if (matrix[rowIndex - 1, colIndex - 1] == '<')
                        {
                            shipsFirst--;

                        }
                        matrix[rowIndex - 1, colIndex - 1] = 'X';
                    }
                    if (ValidationIndeces(matrix, rowIndex, colIndex - 1))
                    {
                        if (matrix[rowIndex, colIndex - 1] == '>')
                        {
                            shipsSecond--;

                        }
                        if (matrix[rowIndex, colIndex - 1] == '<')
                        {
                            shipsFirst--;

                        }
                        matrix[rowIndex, colIndex - 1] = 'X';
                    }
                    if (ValidationIndeces(matrix, rowIndex + 1, colIndex - 1))
                    {
                        if (matrix[rowIndex + 1, colIndex - 1] == '>')
                        {
                            shipsSecond--;

                        }
                        if (matrix[rowIndex + 1, colIndex - 1] == '<')
                        {
                            shipsFirst--;

                        }
                        matrix[rowIndex + 1, colIndex - 1] = 'X';
                    }
                    if (ValidationIndeces(matrix, rowIndex + 1, colIndex))
                    {
                        if (matrix[rowIndex + 1, colIndex] == '>')
                        {
                            shipsSecond--;

                        }
                        if (matrix[rowIndex + 1, colIndex] == '<')
                        {
                            shipsFirst--;

                        }
                        matrix[rowIndex + 1, colIndex] = 'X';
                    }
                    if (ValidationIndeces(matrix, rowIndex + 1, colIndex + 1))
                    {
                        if (matrix[rowIndex + 1, colIndex + 1] == '>')
                        {
                            shipsSecond--;

                        }
                        if (matrix[rowIndex + 1, colIndex + 1] == '<')
                        {
                            shipsFirst--;

                        }
                        matrix[rowIndex + 1, colIndex + 1] = 'X';
                    }
                    if (ValidationIndeces(matrix, rowIndex, colIndex + 1))
                    {
                        if (matrix[rowIndex, colIndex + 1] == '>')
                        {
                            shipsSecond--;

                        }
                        if (matrix[rowIndex, colIndex + 1] == '<')
                        {
                            shipsFirst--;

                        }
                        matrix[rowIndex, colIndex + 1] = 'X';
                    }
                    if (ValidationIndeces(matrix, rowIndex - 1, colIndex + 1))
                    {
                        if (matrix[rowIndex - 1, colIndex + 1] == '>')
                        {

                        }
                        if (matrix[rowIndex - 1, colIndex + 1] == '<')
                        {
                            shipsFirst--;

                        }
                        matrix[rowIndex - 1, colIndex + 1] = 'X';
                    }
                    if (shipsFirst == 0 || shipsSecond == 0)
                    {
                        break;
                    }
                }


            }

            if (shipsFirst <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {(shipsOfPlayerOne + shipsOfPlayerTwo) - (shipsFirst + shipsSecond)} ships have been sunk in the battle.");
            }
            else if (shipsSecond <= 0)
            {
                Console.WriteLine($"Player One has won the game! {(shipsOfPlayerOne + shipsOfPlayerTwo) - (shipsFirst + shipsSecond)} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {shipsFirst} ships left. Player Two has {shipsSecond} ships left.");
            }
        }

        private static bool ValidationIndeces(char[,] matrix, int rowIndex, int colIndex)
        {
            if (rowIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex >= 0 && colIndex < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
