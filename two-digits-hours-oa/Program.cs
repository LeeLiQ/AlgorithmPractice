using System;

namespace two_digits_hours_oa
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = TwoDigitsHour("22:22:21", "22:22:23");
            System.Console.WriteLine(result);
        }

        public static int TwoDigitsHour(string S, string T)
        {
            if (string.IsNullOrWhiteSpace(S) || string.IsNullOrWhiteSpace(T) || S.Length != T.Length)
                return 0;
            var left = S.Split(':');
            var right = T.Split(':');
            var low = new int[3];
            var high = new int[3];
            for (var i = 0; i < left.Length; i++)
            {
                low[i] = Int32.Parse(left[i]);
                high[i] = Int32.Parse(right[i]);
            }
        }
    }
}
