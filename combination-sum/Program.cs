using System;
using System.Collections.Generic;

namespace combination_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 2, 3, 6, 7 };
            var target = 7;
            var result = CombinationSum(nums, target);

            foreach (var list in result)
            {
                foreach (var num in list)
                    System.Console.Write(num + "\t");
                System.Console.WriteLine();
            }
        }


        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (target <= 0)
                return result;
            Helper(result, new List<int>(), candidates, target, 0);
            return result;
        }

        private static void Helper(IList<IList<int>> result, List<int> path, int[] nums, int target, int idx)
        {
            if (target == 0)
                result.Add(new List<int>(path));

            if (target > 0)
            {
                for (var i = idx; i < nums.Length; i++)
                {
                    path.Add(nums[i]);
                    Helper(result, path, nums, target - nums[i], i);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
