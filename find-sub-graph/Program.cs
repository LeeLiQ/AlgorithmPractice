using System;

namespace find_sub_graph
{
    class Program
    {
        #region [Initialization]
        private static int[,] map = new int[10, 10]
            {
                {1,2,1,0,0,0,0,0,2,3},
                {3,0,2,0,1,2,1,0,1,2},
                {4,0,1,0,1,2,3,2,0,1},
                {3,2,0,0,0,1,2,4,0,0},
                {0,0,0,0,0,0,1,5,3,0},
                {0,1,2,1,0,1,5,4,3,0},
                {0,1,2,3,1,3,6,2,1,0},
                {0,0,3,4,8,9,7,5,0,0},
                {0,0,0,3,7,8,6,0,1,2},
                {0,0,0,0,0,0,0,0,1,0}
            };
        private static int[,] next = new int[4, 2]
        {
                {0,1},
                {1,0},
                {0,-1},
                {-1,0}
        };
        #endregion
        static void Main(string[] args)
        {
            var num = 0;
            var book = new int[10, 10];
            for (var i = 0; i < map.GetLength(0); i++)
                for (var j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] > 0)
                    {
                        book[i, j] = 1;
                        num--;
                        Dfs(map, book, i, j, num);
                    }
                }
            System.Console.WriteLine($"There are {Math.Abs(num)} islands.");
            for (var i = 0; i < map.GetLength(0); i++)
            {
                for (var j = 0; j < map.GetLength(1); j++)
                {
                    System.Console.Write(map[i, j] + "\t");
                }
                System.Console.WriteLine();
            }
        }

        private static void Dfs(int[,] map, int[,] book, int x, int y, int color)
        {
            map[x, y] = color; //This is important. Otherwise, this point doesn't have the correct color.
            for (var k = 0; k < 4; k++)
            {
                var tx = x + next[k, 0];
                var ty = y + next[k, 1];
                if (tx < 0 || tx >= map.GetLength(0) || ty < 0 || ty >= map.GetLength(1))
                    continue;
                if (map[tx, ty] > 0 && book[tx, ty] == 0)
                {
                    book[tx, ty] = 1;
                    map[tx, ty] = color;
                    Dfs(map, book, tx, ty, color);
                }
            }
            return;
        }
    }
}
