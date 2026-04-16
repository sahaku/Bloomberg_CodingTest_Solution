using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            int rows = board.Length;
            int cols = board[0].Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(DFS(board, word, i, j, 0, rows, cols))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DFS(char[][] board, string word, int row, int col, int index, int rows, int cols)
        {
            if (index == word.Length)
            {
                return true;
            }
            if (row < 0 || col < 0 || col >= cols || row >= rows || board[row][col] != word[index])
            {
                return false;
            }
            var temp = board[row][col];
            board[row][col] = '#';

            var found = DFS(board, word, row + 1, col, index + 1, rows, cols) ||
                    DFS(board, word, row - 1, col, index + 1, rows, cols) ||
                    DFS(board, word, row, col + 1, index + 1, rows, cols) ||
                    DFS(board, word, row, col - 1, index + 1, rows, cols);

            board[row][col] = temp;

            return found;
        }
    }
}
