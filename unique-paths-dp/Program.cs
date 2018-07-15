using System;

namespace unique_paths_dp
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = uniquePaths_iterative(7, 3);
            Console.WriteLine(result);

            var result2 = UniquePath2(5, 4);
            System.Console.WriteLine(result2); ;
        }

        public static long uniquePaths_iterative(int m, int n)
        {
            if (m <= 0 || n <= 0)
            {
                return 0;
            }

            var counts = new long[n];
            for (var i = 0; i < n; i++)
            {
                counts[i] = 1;
            }

            for (var j = 1; j < m; j++)
            {
                for (int i = 1; i < n; i++)
                {
                    counts[i] += counts[i - 1];
                }
            }

            return counts[n - 1];
        }
        public static long UniquePath2(int m, int n)
        {
            if (m <= 0 || n <= 0)
                return 0;
            var pathCounts = new long[m, n];
            for (var i = 0; i < m; i++)
                pathCounts[i, 0] = 1;
            for (var i = 0; i < n; i++)
                pathCounts[0, i] = 1;
            for (var i = 1; i < m; i++)
                for (var j = 1; j < n; j++)
                    pathCounts[i, j] = pathCounts[i - 1, j] + pathCounts[i, j - 1];

            return pathCounts[m - 1, n - 1];
        }
    }
}
