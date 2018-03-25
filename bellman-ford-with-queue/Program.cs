using System;
using System.Collections.Generic;

namespace bellman_ford_with_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //# of vertice and edges
            int n, m;
            //way to store starting point, ending point, and distance between them.
            int[] start = new int[8], end = new int[8], weight = new int[8];
            //first and last are just their stupid way to iterate through all the edges.
            // first should be larger than n while last should be larger than m.
            int[] first = new int[6], next = new int[8];
            int[] dis = new int[5];
            var que = new Queue<int>();
            var mx = 9999;
            System.Console.WriteLine("# of points");
            n = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("# of points");
            m = Convert.ToInt32(Console.ReadLine());
            for (var i = 1; i < n; i++)
                dis[i] = mx;
            dis[0] = 0;
            for (var i = 0; i < n; i++)
                first[i] = -1;
            for (var i = 0; i < m; i++)
            {
                System.Console.WriteLine("start, end, weight");
                start[i] = Convert.ToInt32(Console.ReadLine());
                end[i] = Convert.ToInt32(Console.ReadLine());
                weight[i] = Convert.ToInt32(Console.ReadLine());
                next[i] = first[start[i]];
                first[start[i]] = i;
            }

            que.Enqueue(0);

            while (que.Count != 0)
            {
                var k = first[que.Dequeue()];
                while (k != -1)
                {
                    if (dis[end[k]] > dis[start[k]] + weight[k])
                    {
                        dis[end[k]] = dis[start[k]] + weight[k];
                        if (!que.Contains(end[k]))
                        {
                            que.Enqueue(end[k]);
                        }
                    }
                    k = next[k];
                }
            }

            for (var i = 0; i < n; i++)
                System.Console.Write(dis[i] + "\t");
        }
    }
}
