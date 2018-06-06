using System;

namespace three_sum_closet
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[4] { -1, 2, 1, -4 };
            var target = 1;
            var len = nums.Length;
            var result = 0;
            if (len <= 3)
                foreach (var num in nums)
                    result += num;
            Array.Sort(nums);
            result = nums[0] + nums[1] + nums[2];
            for (var i = 0; i < len - 3; i++)
            {
                var left = i + 1;
                var right = len - 1;
                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];
                    if (Math.Abs(result - target) >= Math.Abs(sum - target))
                    {
                        result = sum;
                        if (result == target)
                            System.Console.WriteLine(result);
                    }
                    if (sum > target)
                        right--;
                    if (sum < target)
                        left++;
                }
            }
            System.Console.WriteLine(result);
        }
    }
}
