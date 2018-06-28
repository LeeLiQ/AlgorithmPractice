using System;

namespace longest_increasing_matrix_path
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[3, 3]
                {
                    {9,9,4},
                    {6,6,8},
                    {2,1,1}
                };

            var longest = 0;
            var paths = new int[nums.GetLength(0), nums.GetLength(1)];

            for (var i = 0; i < nums.GetLength(0); i++)
                for (var j = 0; j < nums.GetLength(1); j++)
                {
                    var pathL = Dfs(nums, paths, i, j);
                    longest = Math.Max(pathL, longest);
                }

            Console.WriteLine(longest);
        }

        private static int Dfs(int[,] nums, int[,] paths, int i, int j)
        {
            if (paths[i, j] != 0)
                return paths[i, j];

            var dirs = new int[,]
            {
                    {0,1},
                    {1,0},
                    {0,-1},
                    {-1,0}
            };
            var longest = 1;
            for (var k = 0; k < 4; k++)
            {
                var x = i + dirs[k, 0];
                var y = j + dirs[k, 1];

                if (x >= 0 && y >= 0 && x < nums.GetLength(0) && y < nums.GetLength(1) && nums[i, j] < nums[x, y])
                {
                    var pathL = Dfs(nums, paths, x, y);
                    longest = Math.Max(pathL + 1, longest);
                }
            }

            paths[i, j] = longest;
            return longest;
        }
    }
}
