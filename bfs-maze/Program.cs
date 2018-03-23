using System;
using System.Collections.Generic;

namespace bfs_maze
{
    class Program
    {
        static void Main(string[] args)
        {
            var next = new int[4, 2]{
                {0,1},{1,0},{0,-1},{-1,0} //right, down, left, up
            };

            var que = new Queue<Note>();
            // var a = new int[51, 51];
            // var book = new int[51, 51];
            // System.Console.WriteLine("enter n and m");
            // int.TryParse(Console.ReadLine(), out var n);
            // int.TryParse(Console.ReadLine(), out var m);
            // for (var i = 0; i < n; i++)
            //     for (var j = 0; j < m; j++)
            //         a[i, j] = int.Parse(Console.ReadLine());
            int n = 5, m = 4;
            var a = new int[5, 4]
            {
                 { 0, 0, 1, 0 },
                 { 0, 0, 1, 1 },
                 { 0, 0, 1, 0 },
                 { 0, 1, 0, 0 },
                 { 0, 0, 0, 1 }
            };
            var book = new int[5, 4];
            System.Console.WriteLine("enter starting coodinations and targets");
            int.TryParse(Console.ReadLine(), out var startx);
            int.TryParse(Console.ReadLine(), out var starty);
            int.TryParse(Console.ReadLine(), out var p);
            int.TryParse(Console.ReadLine(), out var q);
            //put the starting point into the queue
            var head = new Note { x = startx, y = starty, f = 0, step = 0 };
            que.Enqueue(head);
            book[startx, starty] = 1;//mark it as visited
            var flag = false;//a flag to mark if we reach the target.

            while (que.Count != 0)
            {
                var node = que.Dequeue();
                int tx = 0, ty = 0;
                for (var k = 0; k < next.GetLength(0); k++)
                {
                    tx = node.x + next[k, 0];
                    ty = node.y + next[k, 1];

                    if (tx < 0 || tx >= n || ty < 0 || ty >= m)
                        continue;
                    if (a[tx, ty] == 0 && book[tx, ty] == 0)
                    {
                        book[tx, ty] = 1;
                        var newNode = new Note { x = tx, y = ty, f = 0, step = node.step + 1 };
                        que.Enqueue(newNode);
                    }
                    if (tx == p && ty == q)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    break;
            }

            if (que.Count == 0)
                System.Console.WriteLine("no luck");
            else
            {
                Note cur = null;
                while (que.Count != 0)
                    cur = que.Dequeue();
                System.Console.WriteLine(cur.step);
            }
        }
    }
}
