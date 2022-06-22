using System;
using System.Collections.Concurrent;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = 8;

            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;

            char[,] board = new char[n, n];

            FillMatrix(board, ref blackRow, ref blackCol, ref whiteRow, ref whiteCol);

            while (true)
            {
                if (!WhitePawnMoves(board, ref whiteRow, ref whiteCol))
                {
                    return;
                }
                if (!BlackPawnMoves(board, ref blackRow, ref blackCol))
                {
                    return;
                }                
            }
        }

        private static bool BlackPawnMoves(char[,] board, ref int blackRow, ref int blackCol)
        {
            if (blackRow + 1 <= 7 && blackCol - 1 >= 0)
            {
                if (board[blackRow + 1, blackCol - 1] == 'w')
                {
                    board[blackRow, blackCol] = '-';
                    blackRow = blackRow + 1;
                    blackCol = blackCol - 1;
                    board[blackRow, blackCol] = 'b';
                    string position = GetPosition(board, blackRow, blackCol);
                    Console.WriteLine($"Game over! Black capture on {position}.");
                    return false;
                }
            }
            if (blackRow + 1 <= 7 && blackCol + 1 <= board.GetLength(1))
            {
                if (board[blackRow + 1, blackCol + 1] == 'w')
                {
                    board[blackRow, blackCol] = '-';
                    blackRow = blackRow + 1;
                    blackCol = blackCol + 1;
                    board[blackRow, blackCol] = 'b';
                    string position = GetPosition(board, blackRow, blackCol);
                    Console.WriteLine($"Game over! Black capture on {position}.");
                    return false;
                }
            }

            if (blackRow + 1 == 7)
            {
                board[blackRow, blackCol] = '-';
                blackRow = 7;
                board[blackRow, blackCol] = 'b';
                string position = GetPosition(board, blackRow, blackCol);
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {position}.");
                return false;
            }

            board[blackRow, blackCol] = '-';
            blackRow = blackRow + 1;
            board[blackRow, blackCol] = 'b';
            return true;
        }

        private static bool WhitePawnMoves(char[,] board, ref int whiteRow, ref int whiteCol)
        {
            if (whiteRow - 1 >= 0 && whiteCol - 1 >= 0)
            {
                if (board[whiteRow - 1, whiteCol - 1] == 'b')
                {
                    board[whiteRow, whiteCol] = '-';
                    whiteRow = whiteRow - 1;
                    whiteCol = whiteCol - 1;
                    board[whiteRow, whiteCol] = 'w';
                    string position = GetPosition(board, whiteRow, whiteCol);
                    Console.WriteLine($"Game over! White capture on {position}.");
                    return false;
                }                
            }

            if (whiteRow - 1 >= 0 && whiteCol + 1 < board.GetLength(1))
            {
                if (board[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    board[whiteRow, whiteCol] = '-';
                    whiteRow = whiteRow - 1;
                    whiteCol = whiteCol + 1;
                    board[whiteRow, whiteCol] = 'w';
                    string position = GetPosition(board, whiteRow, whiteCol);
                    Console.WriteLine($"Game over! White capture on {position}.");
                    return false;
                }
            }

            if (whiteRow - 1 == 0)
            {
                board[whiteRow, whiteCol] = '-';
                whiteRow = 0;
                board[whiteRow, whiteCol] = 'w';
                string position = GetPosition(board, whiteRow, whiteCol);
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {position}.");
                return false;
            }

            board[whiteRow, whiteCol] = '-';
            whiteRow = whiteRow - 1;
            board[whiteRow, whiteCol] = 'w';
            return true;
        }

        private static string GetPosition(char[,] board, int row, int col)
        {
            int winRow = row + 8 - (2 * row);
            char winCol = (char)(col + 97);

            return $"{winCol}{winRow}";
        }

        private static void FillMatrix(char[,] board, ref int blackRow, ref int blackCol, ref int whiteRow, ref int whiteCol)
        {

            for (int row = 0; row < 8; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = input[col];

                    if (board[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    if (board[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

        }
    }
}
