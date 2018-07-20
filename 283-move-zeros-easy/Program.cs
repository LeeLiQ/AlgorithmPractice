using System;

namespace _283_move_zeros_easy
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 0, 1, 0, 3, 12 };
            moveZeroes(nums);
        }

        private static void moveZeroes(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return;

            for (int i = 0; i < nums.Length - 1; i++)
            {

                if (nums[i] == 0)
                {
                    int j = i + 1;
                    while (j < nums.Length && nums[j] == 0)
                    {
                        j++;
                    }
                    if (j < nums.Length)
                    {
                        nums[i] = nums[j];
                        nums[j] = 0;
                    }
                }
            }
        }
    }
}
