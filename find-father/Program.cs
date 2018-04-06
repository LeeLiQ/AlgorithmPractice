using System;

namespace find_father
{
    class Program
    {
        static void Main(string[] args)
        {
            var gangsters = new int[10];
            var gangSize = new int[10];
            var count = gangsters.Length;
            #region [Initialization]
            for (var i = 0; i < gangsters.Length; i++)
            {
                gangsters[i] = i;
                gangSize[i] = 1; // at the beginning, each gang sub group has only that gangster.
            }

            var pairs = new int[11, 2]
            {
                {4,3},
                {3,8},
                {6,5},
                {9,4},
                {2,1},
                {8,9},
                {5,0},
                {7,2},
                {6,1},
                {1,0},
                {6,7}
            };
            #endregion


            for (var i = 0; i < pairs.GetLength(0); i++)
            {
                // System.Console.WriteLine("enter a pair:");
                // int.TryParse(Console.ReadLine(), out var a);
                // int.TryParse(Console.ReadLine(), out var b);
                merge(gangsters, gangSize, pairs[i, 0], pairs[i, 1], ref count);
            }

            for (var i = 0; i < gangsters.Length; i++)
            {
                System.Console.Write(gangsters[i] + "\t");
            }

            System.Console.WriteLine();
            System.Console.WriteLine(count);
        }

        private static int find(int[] gang, int son)
        {
            while (son != gang[son])
                son = gang[son];
            return son;
        }

        private static void merge(int[] gang, int[] gangSize, int a, int b, ref int count)
        {
            var aRoot = find(gang, a);
            var bRoot = find(gang, b);
            if (aRoot == bRoot)
                return;
            if (gangSize[aRoot] > gangSize[bRoot])
            {
                gangSize[aRoot] += gangSize[bRoot];
                gang[bRoot] = gang[aRoot];
            }
            else
            {
                gangSize[bRoot] += gangSize[aRoot];
                gang[aRoot] = gang[bRoot];
            }
            count--;
        }
    }
}
