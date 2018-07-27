using System;
using System.Collections.Generic;

namespace longest_substr_unique_char
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "pwwkew";
            var map = new HashSet<char>();
            int l = 0, r = 0, len = 0;
            while (r < s.Length)
            {
                var cur = s[r];
                if (!map.Contains(cur))
                {
                    map.Add(cur);
                    r++;
                    len = Math.Max(len, map.Count);
                }
                else
                {
                    map.Remove(s[l]);
                    l++;
                }
            }
            Console.WriteLine(len);
        }
    }
}
