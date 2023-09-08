using System;


namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sudokuBoard = {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };

        }
        public static void solveSudoku(char[,] board)
        {
            if (board == null || board.Length == 0)
                return;
            solve(board);
        }
        private static bool solve(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (isValid(board, i, j, c))
                            {
                                board[i, j] = c;

                                if (solve(board))
                                    return true;
                                else
                                    board[i, j] = '.';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool isValid(char[,] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                //comprobar fila
                if (board[i, col] != '.' && board[i, col] == c)
                    return false;
                //columna de verificación  
                if (board[row, i] != '.' && board[row, i] == c)
                    return false;
                //comprobar bloque 3*3 
                if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != '.' && board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == c)
                    return false;
            }
            return true;
        }

    }
}
