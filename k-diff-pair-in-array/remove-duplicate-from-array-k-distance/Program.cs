using System;

namespace remove_duplicate_from_array_k_distance
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
            RemoveDuplicate(nums);
            foreach (var num in nums)
                System.Console.WriteLine(num);
        }

        private static int RemoveDuplicate(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int i = 0, j = 0;
            while (j < nums.Length)
            {
                if (i < 2)
                    i++;
                else
                {
                    if (nums[j] > nums[i - 2])
                        nums[i++] = nums[j];
                }
                j++;
            }
            return i;
        }
    }
}
