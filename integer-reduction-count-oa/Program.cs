using System;

namespace integer_reduction_count_oa
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "111111100";
            System.Console.WriteLine(Solution(input));
        }

        private static int Solution(string s)
        {
            var count = 0;
            if (string.IsNullOrWhiteSpace(s))
                return count;

            while (s.Length > 0)
            {
                if (s.IndexOf('1') == -1)
                    break;
                if (s[s.Length - 1] == '1')
                    s = s.Substring(0, s.Length - 1) + '0';
                else if (s[s.Length - 1] == '0')
                    s = s.Substring(0, s.Length - 1);
                count++;
            }

            return count;
        }
    }
}
