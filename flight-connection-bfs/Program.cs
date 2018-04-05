using System;
using System.Collections.Generic;

namespace flight_connection_bfs
{
    class Program
    {
        static void Main(string[] args)
        {
            var mx = Int32.MaxValue;
            var map = new int[5, 5]
            {
                {0,1,1,mx,mx},
                {1,0,1,1,mx},
                {1,1,0,1,1},
                {mx,1,1,0,1},
                {mx,mx,1,1,0}
            };
            // {
            //     {0,1,mx,mx,mx},
            //     {1,0,1,mx,mx},
            //     {mx,1,0,1,mx},
            //     {mx,mx,1,0,1},
            //     {mx,mx,mx,1,0}
            // }; // I made it no connection at all. Have to go through 0->1->2->3->4

            var que = new Queue<Note>();
            var head = new Note { X = 0, step = 0 };
            que.Enqueue(head);
            var book = new int[5];
            book[0] = 1;
            var flag = false;
            Note end = new Note();
            while (que.Count != 0)
            {
                var node = que.Dequeue();
                for (var j = 0; j < 5; j++)
                {
                    if (map[node.X, j] != mx && book[j] == 0)
                    {
                        var newNode = new Note { X = j, step = node.step + 1 };
                        que.Enqueue(newNode);
                        book[j] = 1;
                    }
                }
                if (node.X == 4)
                {
                    flag = true;
                    end = node;
                    break;
                }
                if (flag)
                    break;
            }

            System.Console.WriteLine(end.step);
        }
    }

    public class Note
    {
        public int X { get; set; }
        public int step { get; set; }
    }
}
