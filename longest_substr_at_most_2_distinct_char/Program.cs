using System;
using System.Collections.Generic;

namespace longest_substr_at_most_2_distinct_char
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "abcbbbbcccbdddadacb";
            var result = Str2Distinct(input);

            System.Console.WriteLine(result);
        }

        private static string Str2Distinct(string input)
        {
            if (input == null || input.Length < 3)
                return input;

            var map = new Dictionary<char, int>();
            int l = 0, r = 0, start = 0, maxLen = 0;

            while (r < input.Length)
            {
                var cur = input[r];

                if (map.ContainsKey(cur))
                    map[cur]++;
                else
                    map.Add(cur, 1);

                //start to check count of unique char in the map
                if (map.Count > 2)
                {
                    if (maxLen < r - l)
                    {
                        maxLen = r - l;
                        start = l;
                    }
                    while (map.Count > 2)
                    {
                        var temp = input[l];
                        if (map.ContainsKey(temp))
                            map[temp]--;
                        if (map[temp] == 0)
                            map.Remove(temp);
                        l++;
                    }
                }
                r++;
            }

            return r - l > maxLen ? input.Substring(l, r - l) : input.Substring(start, maxLen);
        }
    }
}
