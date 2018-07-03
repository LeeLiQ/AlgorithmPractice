using System;
using System.Collections.Generic;

namespace increasing_subsequences_dfs
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 4, 6, 7, 7 };

            var result = FindSubsequences(nums);

            foreach (var list in result)
            {
                foreach (var num in list)
                    System.Console.Write(num + "\t");
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }

        private static List<List<int>> FindSubsequences(int[] nums)
        {
            var result = new List<List<int>>();
            if (nums == null || nums.Length <= 1)
                return result;

            DFS(new List<int>(), 0, nums, result);

            return result;
        }

        private static void DFS(List<int> list, int here, int[] nums, List<List<int>> result)
        {
            if (list.Count > 1)
                result.Add(new List<int>(list));
            var trace = new HashSet<int>();

            for (var i = here; i < nums.Length; i++)
            {
                if (trace.Contains(nums[i]))
                    continue;
                if (list.Count == 0 || nums[i] >= list[list.Count - 1])
                {
                    trace.Add(nums[i]);
                    list.Add(nums[i]);
                    DFS(list, i + 1, nums, result);
                    list.Remove(list[list.Count - 1]);
                }
            }
        }
    }
}
