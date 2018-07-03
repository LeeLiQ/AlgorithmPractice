using System;
using System.Collections.Generic;

namespace surrounded_regions
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new char[,]
            {
                // {'X','X','X','X'},
                // {'X','O','O','X'},
                // {'X','X','O','X'},
                // {'X','X','X','X'}
                {'O','O','O'},
                {'O','O','O'},
                {'O','O','O'}
            };
            Solve(board);
        }

        public static void Solve(char[,] board)
        {
            var row = board.GetLength(0);
            var column = board.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                if (board[i, 0] == 'O')
                {
                    SolveHelper(board, i, 0);
                }

                if (board[i, column - 1] == 'O')
                {
                    SolveHelper(board, i, column - 1);
                }
            }

            for (int i = 0; i < column; i++)
            {
                if (board[0, i] == 'O')
                {
                    SolveHelper(board, 0, i);
                }
                if (board[row - 1, i] == 'O')
                {
                    SolveHelper(board, row - 1, i);
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (board[i, j] == 'O')
                    {
                        board[i, j] = 'X';
                    }
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (board[i, j] == '#')
                    {
                        board[i, j] = 'O';
                    }
                }
            }
        }
        private static void SolveHelper(char[,] board, int i, int j)
        {
            board[i, j] = '#';
            if (i - 1 > 0 && board[i - 1, j] == 'O')
            {
                SolveHelper(board, i - 1, j);
            }

            if (i + 1 < board.GetLength(0) - 1 && board[i + 1, j] == 'O')
            {
                SolveHelper(board, i + 1, j);
            }
            if (j - 1 > 0 && board[i, j - 1] == 'O')
            {
                SolveHelper(board, i, j - 1);
            }

            if (j + 1 < board.GetLength(1) - 1 && board[i, j + 1] == 'O')
            {
                SolveHelper(board, i, j + 1);
            }
        }
    }
}
