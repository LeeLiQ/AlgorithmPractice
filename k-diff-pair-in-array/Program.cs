using System;
using System.Collections.Generic;

namespace k_diff_pair_in_array
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FindPairs(new int[] { 3, 1, 4, 1, 5 }, 2);
            Console.WriteLine(result);
        }

        private static int FindPairs(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k < 0)
                return 0;

            var dict = new Dictionary<int, int>();
            var count = 0;
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict.Add(num, 1);
            }

            foreach (var entry in dict)
            {
                if (k == 0)
                {
                    if (entry.Value > 1)
                        count++;
                }
                else
                {
                    if (dict.ContainsKey(entry.Key + k))
                        count++;
                }
            }
            return count;
        }
    }
}
