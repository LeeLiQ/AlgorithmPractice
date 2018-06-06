using System;

namespace max_product_subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[2] { 0, 2 };
            var result = nums[0];
            var cur = 1;
            int start = 0, end = 0;
            while (start < nums.Length && end < nums.Length)
            {
                cur = cur * nums[end];
                if (cur > result)
                    result = cur;
                if (cur <= result && cur < nums[end])
                {
                    cur = nums[end];
                    result = cur > result ? cur : result;
                }
                end++;
            }

            Console.WriteLine(result);
        }
    }
}
