using System;
using System.Collections.Generic;
using System.Text;

namespace Bloomberg_Interview_QS
{
     
public class GridFuelPath
    {
        public class State
        {
            public int R, C, Fuel;
            public State(int r, int c, int fuel)
            {
                R = r; C = c; Fuel = fuel;
            }
        }

        public static bool CanReachTarget_NoDirectionArrays(char[][] grid, int startFuel, int fuelGain)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            // Find S
            int sr = 0, sc = 0;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    if (grid[r][c] == 'S')
                        (sr, sc) = (r, c);

            // bestFuel[r][c] = best fuel seen at this cell
            int[][] bestFuel = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                bestFuel[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                    bestFuel[i][j] = -1;
            }

            var q = new Queue<(int r, int c, int fuel)>();
            q.Enqueue((sr, sc, startFuel));
            bestFuel[sr][sc] = startFuel;

            while (q.Count > 0)
            {
                var (r, c, fuel) = q.Dequeue();

                if (grid[r][c] == 'T')
                    return true;

                // Try DOWN (r+1, c)
                TryMove(r + 1, c, fuel, grid, fuelGain, bestFuel, q);

                // Try UP (r-1, c)
                TryMove(r - 1, c, fuel, grid, fuelGain, bestFuel, q);

                // Try RIGHT (r, c+1)
                TryMove(r, c + 1, fuel, grid, fuelGain, bestFuel, q);

                // Try LEFT (r, c-1)
                TryMove(r, c - 1, fuel, grid, fuelGain, bestFuel, q);
            }

            return false;
        }

        private static void TryMove(
            int nr, int nc, int fuel,
            char[][] grid, int fuelGain,
            int[][] bestFuel,
            Queue<(int r, int c, int fuel)> q)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            // Out of bounds
            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                return;

            // Wall
            if (grid[nr][nc] == '#')
                return;

            // Moving cost
            int newFuel = fuel - 1;
            if (newFuel < 0)
                return;

            // Fuel cell
            if (grid[nr][nc] == 'F')
                newFuel += fuelGain;

            // State compression
            if (newFuel > bestFuel[nr][nc])
            {
                bestFuel[nr][nc] = newFuel;
                q.Enqueue((nr, nc, newFuel));
            }
        }

    }

}
