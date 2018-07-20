using System;

namespace _88_merge_sorted_arrays_easy
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums1 = new int[] { 4, 5, 6, 0, 0, 0 };
            var nums2 = new int[] { 1, 2, 3 };
            merge(nums1, 3, nums2, 3);
            foreach (var num in nums1)
                System.Console.WriteLine(num);
        }

        private static void merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1 == null || nums2 == null)
                return;
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] >= nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }
                k--;
            }
            while (j >= 0)
            {
                nums1[j] = nums2[j];
                j--;
            }
        }
    }
}
