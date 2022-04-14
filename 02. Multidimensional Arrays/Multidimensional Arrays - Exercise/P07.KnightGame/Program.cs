using System;
using System.Linq;

namespace P07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            int maxCount = 0;
            int currCount = 0;
            int maxCountRow = 0;
            int maxCountCol = 0;
            int removedKnights = 0;

            while (true)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {

                    for (int col = 0; col < board.GetLength(1); col++)
                    {

                        if (board[row, col] == '0')
                        {
                            continue;
                        }

                        //up
                        if (row - 2 >= 0 && row - 2 < board.GetLength(0))
                        {
                            if (col - 1 >= 0 && col - 1 < board.GetLength(1))
                            {
                                if (board[row - 2, col - 1] == 'K')
                                {
                                    currCount++;
                                }
                            }
                            if (col + 1 >= 0 && col + 1 < board.GetLength(1))
                            {
                                if (board[row - 2, col + 1] == 'K')
                                {
                                    currCount++;
                                }
                            }
                        }

                        //down
                        if (row + 2 >= 0 && row + 2 < board.GetLength(0))
                        {
                            if (col - 1 >= 0 && col - 1 < board.GetLength(1))
                            {
                                if (board[row + 2, col - 1] == 'K')
                                {
                                    currCount++;
                                }
                            }
                            if (col + 1 >= 0 && col + 1 < board.GetLength(1))
                            {
                                if (board[row + 2, col + 1] == 'K')
                                {
                                    currCount++;
                                }
                            }
                        }

                        //left
                        if (col - 2 >= 0 && col - 2 < board.GetLength(1))
                        {
                            if (row - 1 >= 0 && row - 1 < board.GetLength(0))
                            {
                                if (board[row - 1, col - 2] == 'K')
                                {
                                    currCount++;
                                }
                            }
                            if (row + 1 >= 0 && row + 1 < board.GetLength(0))
                            {
                                if (board[row + 1, col - 2] == 'K')
                                {
                                    currCount++;
                                }
                            }
                        }

                        //right
                        if (col + 2 >= 0 && col + 2 < board.GetLength(1))
                        {
                            if (row - 1 >= 0 && row - 1 < board.GetLength(0))
                            {
                                if (board[row - 1, col + 2] == 'K')
                                {
                                    currCount++;
                                }
                            }
                            if (row + 1 >= 0 && row + 1 < board.GetLength(0))
                            {
                                if (board[row + 1, col + 2] == 'K')
                                {
                                    currCount++;
                                }
                            }
                        }

                        if (currCount > maxCount)
                        {
                            maxCount = currCount;
                            maxCountRow = row;
                            maxCountCol = col;
                        }
                        currCount = 0;
                    }
                }

                if (maxCount > 0)
                {
                    board[maxCountRow, maxCountCol] = '0';
                    removedKnights++;
                    maxCount = 0;
                    currCount = 0;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }

        }
    }
}
