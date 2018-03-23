using System;

namespace short_path_floyd_warshall
{
    class Program
    {
        static void Main(string[] args)
        {
            var mx = Int32.MaxValue;
            var map = new long[4, 4]
            {
                {0,2,6,4},
                {mx,0,3,mx},
                {7,mx,0,1},
                {5,mx,12,0}
            };

            for (var k = 0; k < 4; k++)
                for (var i = 0; i < 4; i++)
                    for (var j = 0; j < 4; j++)
                    {
                        if (map[i, j] > map[i, k] + map[k, j])
                            map[i, j] = map[i, k] + map[k, j];
                    }
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    System.Console.Write(map[i, j] + "\t");
                }
                System.Console.WriteLine();
            }
        }
    }
}
