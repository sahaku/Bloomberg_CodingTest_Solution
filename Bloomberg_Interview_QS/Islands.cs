using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
    public class Islands
    {
        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int count = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            for(int i=0;i<rows;i++)
                for(int j = 0; j < cols; j++)
                {
                    if (grid[i][j]=='1')
                    {
                        count++;
                        DFS(grid, i, j, rows, cols);
                    }
                }

            return count;
        }

        public void DFS(char[][] grid, int row, int col, int rows, int cols)
        {
            if (row < 0 || col < 0 || row >= rows || col >= cols || grid[row][col] == '0')
            {
                return;
            }
            grid[row][col] = '0'; // Mark as visited
            DFS(grid, row + 1, col, rows, cols);
            DFS(grid, row - 1, col, rows, cols);
            DFS(grid, row, col + 1, rows, cols);
            DFS(grid, row, col - 1, rows, cols);

        }
    }
}
