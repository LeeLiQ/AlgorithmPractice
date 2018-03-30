using System;

namespace fast_find_union
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter # of sites: ");
            int.TryParse(Console.ReadLine(), out var n);

            var id = new int[n];
            for (var i = 0; i < n; i++)
                id[i] = i;
            var count = n;
            var sizeOfTree = new int[n]; //At the beginning, each site is a tree itself. So the values are 1.
            for (var i = 0; i < n; i++)
                sizeOfTree[i] = 1;
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
            for (var i = 0; i < 11; i++)
                Union(pairs[i, 0], pairs[i, 1], id, sizeOfTree, ref count);
            System.Console.WriteLine(count);
            for (var i = 0; i < n; i++)
                System.Console.Write(i + "\t");
            System.Console.WriteLine("----------------");
            foreach (var num in id)
                System.Console.Write(num + "\t");
            System.Console.WriteLine();
            System.Console.WriteLine("================");
            foreach (var num in sizeOfTree)
                System.Console.Write(num + "\t");
        }

        private static int Find(int p, int[] id)
        {
            while (p != id[p])
                p = id[p];
            return p;
        }

        private static void Union(int p, int q, int[] id, int[] sizeOfTree, ref int count)
        {
            var pRoot = Find(p, id);
            var qRoot = Find(q, id);
            if (pRoot == qRoot)
                return;
            if (sizeOfTree[pRoot] > sizeOfTree[qRoot])
            {
                sizeOfTree[pRoot] += sizeOfTree[qRoot];
                id[qRoot] = pRoot;
            }
            else
            {
                sizeOfTree[qRoot] += sizeOfTree[pRoot];
                id[pRoot] = qRoot;
            }
            count--;
        }
    }
}
