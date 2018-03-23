using System;

namespace dijkstra_shortest_paths
{
    //shortest paths from one point to all other points.
    class Program
    {
        static void Main(string[] args)
        {
            var mx = Int32.MaxValue;
            var map = new long[6, 6]
            {
                {0,1,12,mx,mx,mx},
                {mx,0,9,3,mx,mx},
                {mx,mx,0,mx,5,mx},
                {mx,mx,4,0,13,15},
                {mx,mx,mx,mx,0,4},
                {mx,mx,mx,mx,mx,0}
            };
            var dis = new long[6] 
            // this is used to store the initial value of the distances from 0 to all other points. 
            //If we start from other point, replace the value with values in that row.
            // We call them estimated shortest distances.
            {
                0,1,12,mx,mx,mx
            };
            var book = new int[6]; // collection of points that have known shortest path when book[i]=0;

            book[0] = 1;
            var u = 0;
            //Dijkstra algorithm core section
            for (var i = 0; i < (6 - 1); i++) // no need to deal with the last point.
            {
                //find the closest point next to the starting point.
                long min = mx;
                for (var j = 0; j < 6; j++)
                {
                    if (book[j] == 0 && dis[j] < min)
                    {
                        min = dis[j];
                        u = j;
                    }
                }
                book[u] = 1;
                for (var v = 1; v < 6; v++)
                    if (map[u, v] < mx)
                        if (dis[v] > dis[u] + map[u, v])
                            dis[v] = dis[u] + map[u, v];
            }
            for (var i = 0; i < 6; i++)
                Console.Write(dis[i] + "\t");
            System.Console.WriteLine();
        }
    }
}
