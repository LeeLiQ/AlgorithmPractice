using System;

namespace cyclic_automorphisms_oa
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;

            var pattern = "byebye";

            var len = pattern.Length;

            var doublePattern = pattern + pattern;

            for (var i = 0; i <= len; i++)
            {
                if (pattern.Equals(doublePattern.Substring(i, len)))
                    count++;
            }

            System.Console.WriteLine(count);
        }
    }
}
