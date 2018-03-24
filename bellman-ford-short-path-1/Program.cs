using System;
using System.Linq;

namespace bellman_ford_short_path_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mx = Int32.MaxValue;
            var dis = new long[10] { 0, mx, mx, mx, mx, mx, mx, mx, mx, mx };
            int[] start = new int[10], end = new int[10], weight = new int[10];

            for (var i = 0; i < 5; i++)
            {
                System.Console.WriteLine($"enter start, end, and weight for {i + 1} edge");
                start[i] = int.Parse(Console.ReadLine());
                end[i] = int.Parse(Console.ReadLine());
                weight[i] = int.Parse(Console.ReadLine());
            }

            #region [original bellman-ford]
            // for (var k = 0; k < (5 - 1); k++) // n - 1 round of relaxation (n is the number of points)
            //     for (var j = 0; j < 5; j++) // m # of edges
            //     {
            //         if (dis[end[j]] > dis[start[j]] + weight[j])
            //             dis[end[j]] = dis[start[j]] + weight[j];
            //     }
            #endregion

            #region [improved with negative loop check and already shortest check]
            var backup = new long[10] { 0, mx, mx, mx, mx, mx, mx, mx, mx, mx };
            var flag = false;
            for (var k = 0; k < 4; k++)
            {
                Array.Copy(dis, backup, 5);
                for (var i = 0; i < 5; i++)
                    dis[end[i]] = dis[end[i]] > dis[start[i]] + weight[i] ? dis[start[i]] + weight[i] : dis[end[i]];
                if (dis.SequenceEqual(backup))
                    break;
            }

            //check if negative loop exists
            for (var i = 0; i < 5; i++) // edge relaxation
                if (dis[end[i]] > dis[start[i]] + weight[i])
                    flag = true;

            if (flag)
            {
                System.Console.WriteLine("Negative loop exists!!!!");
                return;
            }

            #endregion

            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(dis[i] + "\t");
            }
            System.Console.WriteLine();
        }
    }
}
