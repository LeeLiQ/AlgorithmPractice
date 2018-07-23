using System;

namespace sort_colors
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 2, 0, 2, 1, 1, 0 };
            SortColors(input);
        }

        private static void SortColors(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;
            int left = 0, right = nums.Length - 1, middle = 0;

            while (middle <= right)
            {
                if (nums[middle] == 1)
                    middle++;
                else if (nums[middle] == 2)
                {
                    var temp2 = nums[middle];
                    nums[middle] = nums[right];
                    nums[right] = temp2;
                    right--;
                }
                else
                {
                    var temp0 = nums[middle];
                    nums[middle] = nums[left];
                    nums[left] = temp0;
                    middle++;
                    left++;
                }
            }
        }
    }
}
