using System;
using System.Collections.Generic;

namespace islands_search
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
        private static int sum = 0;
        static void Main(string[] args)
        {
            #region [dfs]
            // var book = new int[10, 10];
            // Dfs(map, book, 5, 7);
            #endregion

            #region [bfs]
            var que = new Queue<Note>();
            var head = new Note { X = 5, Y = 7 };
            que.Enqueue(head);
            var book = new int[10, 10];
            book[5, 7] = 1;
            sum = 1;
            while (que.Count != 0)
            {
                var node = que.Dequeue();
                for (var i = 0; i < 4; i++)
                {
                    var tx = node.X + next[i, 0];
                    var ty = node.Y + next[i, 1];
                    if (tx < 0 || tx >= map.GetLength(0) || ty < 0 || ty >= map.GetLength(1))
                        continue;
                    if (map[tx, ty] > 0 && book[tx, ty] == 0)
                    {
                        book[tx, ty] = 1;
                        sum++;
                        var newNode = new Note { X = tx, Y = ty };
                        que.Enqueue(newNode);
                    }
                }
            }
            #endregion
            System.Console.WriteLine(sum);
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                    System.Console.Write(book[i, j] + "\t");
                System.Console.WriteLine();
            }
        }

        private static void Dfs(int[,] map, int[,] book, int x, int y)
        {
            for (var k = 0; k < 4; k++)
            {
                var tx = x + next[k, 0];
                var ty = y + next[k, 1];

                if (tx < 0 || tx >= map.GetLength(0) || ty < 0 || ty >= map.GetLength(1))
                    continue;
                if (map[tx, ty] > 0 && book[tx, ty] == 0)
                {
                    book[tx, ty] = 1;
                    sum++;
                    Dfs(map, book, tx, ty);
                }
            }

            return;
        }
    }
}
