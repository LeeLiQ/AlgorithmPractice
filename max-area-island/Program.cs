using System;

namespace max_area_island
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new int[,] { { 1, 1, 1, 1 } };
            var result = MaxAreaOfIsland(grid);
            System.Console.WriteLine(result);
        }

        private static int MaxAreaOfIsland(int[,] grid)
        {
            if (grid == null || grid.GetLength(0) == 0)
                return 0;

            var trace = new int[grid.GetLength(0), grid.GetLength(1)];
            var maxArea = 0;

            for (var i = 0; i < grid.GetLength(0); i++)
                for (var j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] != 0 && trace[i, j] != 1)
                    {
                        var curIsland = DFS(grid, trace, i, j);
                        maxArea = Math.Max(maxArea, curIsland);
                    }
                }

            return maxArea;
        }

        private static int DFS(int[,] grid, int[,] trace, int i, int j)
        {
            trace[i, j] = 1;
            var maxArea = 1;

            var dirs = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

            for (var k = 0; k < 4; k++)
            {
                var nx = i + dirs[k, 0];
                var ny = j + dirs[k, 1];
                if (nx >= 0 && ny >= 0 && nx < grid.GetLength(0) && ny < grid.GetLength(1) && grid[nx, ny] == 1 && trace[nx, ny] == 0)
                    maxArea += DFS(grid, trace, nx, ny);
            }

            return maxArea;
        }
    }
}
