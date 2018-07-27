using System;
using System.Collections.Generic;

namespace minimum_window_substr
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "ADOBECODEBANC";
            var t = "ABC";
            var result = MinWindowSubStr(s, t);
            Console.WriteLine(result);
        }

        private static string MinWindowSubStr(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
                return string.Empty;

            var map = new Dictionary<char, int>();
            int l = 0, r = 0, start = 0, count = 0, minLen = s.Length + 1;

            for (var i = 0; i < t.Length; i++)
            {
                if (map.ContainsKey(t[i]))
                    map[t[i]]++;
                else
                    map.Add(t[i], 1);
            }

            while (r < s.Length)
            {
                var curR = s[r];
                if (map.ContainsKey(s[r]))
                {
                    map[s[r]]--;
                    if (map[s[r]] >= 0)
                        count++;
                }
                while (count == t.Length)
                {
                    if (minLen > r - l + 1)
                    {
                        minLen = r - l + 1;
                        start = l;
                    }
                    var curL = s[l];
                    if (map.ContainsKey(s[l]))
                    {
                        map[s[l]]++;
                        if (map[s[l]] > 0)
                            count--;
                    }
                    l++;
                }
                r++;
            }
            return minLen == s.Length + 1 ? string.Empty : s.Substring(start, minLen);
        }
    }
}
