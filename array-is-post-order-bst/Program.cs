using System;

namespace array_is_post_order_bst
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new int[] { 5, 12, 6, 9, 11, 10, 8 };

            Console.WriteLine(IsPostOrderBST(test));
        }

        private static bool IsPostOrderBST(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return false;

            return Helper(arr, 0, arr.Length - 1);
        }

        private static bool Helper(int[] arr, int start, int end)
        {
            var root = arr[end];
            var i = start;
            while (i <= end && arr[i] < root)
                i++;

            for (var j = i; j <= end; j++)
            {
                if (arr[j] < root)
                    return false;
            }

            var left = (i > start) ? Helper(arr, start, i - 1) : true;
            var right = (i < end) ? Helper(arr, i, end - 1) : true;
            return left && right;
        }
    }
}
