using System;

namespace flight_connection_dfs
{
    class Program
    {
        private static int min = Int32.MaxValue;
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
            //     {1,0,1,1,mx},
            //     {mx,1,0,1,1},
            //     {mx,1,1,0,1},
            //     {mx,mx,1,1,0}
            // };
            var book = new int[5];
            book[0] = 1;
            Dfs(map, book, 0, 0);
            System.Console.WriteLine(min);
        }

        private static void Dfs(int[,] map, int[] book, int step, int current)
        {
            if (step > min)
                return;
            if (current == 4)
            {
                min = Math.Min(step, min);
                return;
            }
            for (var i = 0; i < 5; i++)
            {
                if (map[current, i] != Int32.MaxValue && book[i] == 0)
                {
                    book[i] = 1;
                    Dfs(map, book, step + 1, i);
                    book[i] = 0;
                }
            }
        }
    }
}
