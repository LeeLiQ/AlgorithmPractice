using System;
using System.Collections.Generic;
using System.Linq;

namespace matrix_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var mat = new int[3, 3]
            {
                {0,0,0},
                {0,1,0},
                {1,1,1}
            };

            var result = UpdateMatrix(mat);
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                    System.Console.Write(result[i, j] + "\t");
                System.Console.WriteLine();
            }
        }

        private static int[,] UpdateMatrix(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);

            var dists = new int[n, m]; // This is the final result matrix.

            var qu = new Queue<int[]>();
            for (var i = 0; i < n; i++)
                for (var j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        qu.Enqueue(new int[] { i, j });
                        dists[i, j] = 0; // 0 itself has a distance of 0 to 0.
                    }
                    else
                        dists[i, j] = Int32.MaxValue;
                }

            UpdateDists(matrix, dists, qu);
            return dists;
        }

        private static void UpdateDists(int[,] matrix, int[,] dists, Queue<int[]> qu)
        {
            var dirs = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } }; // four directions.
            while (qu.Any())
            {
                var pos = qu.Dequeue();
                var dist = dists[pos[0], pos[1]];
                for (var k = 0; k < dirs.GetLength(0); k++)
                {
                    var x = pos[0] + dirs[k, 0];
                    var y = pos[1] + dirs[k, 1];
                    if (x >= 0 && y >= 0 && x < matrix.GetLength(0) && y < matrix.GetLength(1))
                    {
                        var targetDist = matrix[x, y] == 0 ? 0 : dist + 1;
                        if (dists[x, y] > targetDist)
                        {
                            dists[x, y] = targetDist;
                            qu.Enqueue(new int[] { x, y });
                        }
                    }
                }
            }
        }
    }
}
