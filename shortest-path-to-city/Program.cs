using System;

namespace shortest_path_to_city
{
    class Program
    {
        private static int min = Int32.MaxValue;
        static void Main(string[] args)
        {
            #region [initialization]
            var max = Int32.MaxValue;
            var map = new int[5, 5]
            {
                {0,2,max,max,10},
                {max,0,3,max,7},
                {4,max,0,4,max},
                {max,max,max,0,5},
                {max,max,3,max,0}
            };
            var undirectedMap = new int[5, 5]
            {
                {0,2,4,max,10},
                {2,0,3,max,7},
                {4,3,0,4,3},
                {max,max,4,0,5},
                {max,7,3,5,0}
            };
            #endregion
            var book = new int[5];
            book[0] = 1;
            var book1 = new int[5];
            book1[0] = 1;
            Dfs(map, book, 0, 0, 4);
            System.Console.WriteLine(min);
            min = Int32.MaxValue;
            Dfs(undirectedMap, book1, 0, 0, 4);
            System.Console.WriteLine(min);
        }

        private static void Dfs(int[,] map, int[] book, int cur, int distance, int targetCity)
        {
            //if the distance following this path is already too large, there is not need to continue.
            if (distance > min)
                return;

            //if this is the target city, it means we find a path, just update the distance.
            if (cur == targetCity)
            {
                min = Math.Min(distance, min);
                return;
            }

            //if this is still in the middle of nowhere, let's start from here to check the next possible city.
            for (var j = 0; j < 5; j++)
            {
                //if we can reach a next city from here and we haven't been there before, we can go there and update the distance
                if (map[cur, j] != Int32.MaxValue && book[j] == 0)
                {
                    book[j] = 1;
                    Dfs(map, book, j, distance + map[cur, j], targetCity);
                    book[j] = 0;
                }
            }
            return;
        }
    }
}
