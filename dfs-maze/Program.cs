using System;

namespace dfs_maze
{
    class Program
    {
        private static int targetX;
        private static int targetY;
        private static int min = Int32.MaxValue;
        static void Main(string[] args)
        {
            targetX = 3;
            targetY = 2;
            int.TryParse(Console.ReadLine(), out var n);
            int.TryParse(Console.ReadLine(), out var m);
            var matrix = new int[n, m];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < m; j++)
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());

            var book = new int[n, m];
            book[0, 0] = 1;
            Dfs(matrix, book, 0, 0, 0);
            System.Console.WriteLine(min);
        }

        private static void Dfs(int[,] matrix, int[,] book, int startX, int startY, int step)
        {
            var next = new int[4, 2]
            {
                {0,1},
                {1,0},
                {0,-1},
                {-1,0}
            };
            if (startX == targetX && startY == targetY)
            {
                min = Math.Min(step, min);
                return;
            }

            for (var k = 0; k < 4; k++)
            {
                var tx = startX + next[k, 0];
                var ty = startY + next[k, 1];
                if (tx < 0 || tx >= matrix.GetLength(0) || ty < 0 || ty >= matrix.GetLength(1))
                    continue;
                if (matrix[tx, ty] == 0 && book[tx, ty] == 0)
                {
                    book[tx, ty] = 1;
                    Dfs(matrix, book, tx, ty, step + 1);
                    book[tx, ty] = 0;
                }
            }
            return;
        }

        private static void DfsCopy(int[,] matrix, int[,] book, int x, int y, int step)
        {
            var direction = new int[4, 2]
            {
                {0,1},
                {1,0},
                {0,-1},
                {-1,0}
            };
            if (x == targetX && y == targetY)
            {
                min = Math.Min(min, step);
                return;
            }

            for (var k = 0; k < 4; k++)
            {
                var nextX = x + direction[k, 0];
                var nextY = y + direction[k, 1];

                if (nextX < 0 || nextX >= matrix.GetLength(0) || nextY < 0 || nextY >= matrix.GetLength(1))
                    continue;
                if (matrix[nextX, nextY] == 0 && book[nextX, nextY] == 0)
                {
                    book[nextX, nextY] = 1;
                    DfsCopy(matrix, book, nextX, nextY, step + 1);
                    book[nextX, nextY] = 0;
                }
            }
            return;
        }
    }
}
