using System;
using System.Collections.Generic;

namespace _3_sum_smaller
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { -2, 0, 1, 3 };
            // var nums = new int[] { 5, 1, 3, 4, 7 };   // 1 3 4 5 7
            var target = 2;
            // var target = 12;
            var result = 0;
            Array.Sort(nums);
            for (var i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1, k = nums.Length - 1;
                while (j < k)
                {
                    // this loop can only be used to get the count, but can't be used to find all the combo since it will miss all possible combo by moving only one pointer.
                    // DFS can be used to find all combos similar to all possible increasing sub-array problem.
                    if (nums[i] + nums[j] + nums[k] >= target)
                        k--;
                    else
                    {
                        result += k - j;
                        j++;
                    }
                }
            }
            System.Console.WriteLine(result);
        }
    }
}
