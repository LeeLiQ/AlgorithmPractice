using System;
using System.Collections.Generic;
using System.Linq;

namespace remove_k_digits
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = RemoveKdigits("112", 1);
            Console.WriteLine(result);
        }

        private static string RemoveKdigits(string num, int k)
        {
            int len = num.Length;
            //corner case
            if (k == len)
                return "0";

            var stack = new Stack<char>();
            int i = 0;
            while (i < num.Length)
            {
                //whenever meet a digit which is less than the previous digit, discard the previous one
                while (k > 0 && stack.Any() && stack.Peek() > num[i])
                {
                    stack.Pop();
                    k--;
                }
                stack.Push(num[i]);
                i++;
            }

            // corner case like "1111"
            while (k > 0)
            {
                stack.Pop();
                k--;
            }

            //construct the number from the stack
            var rev = stack.ToArray();
            Array.Reverse(rev);
            var newString = new string(rev);
            //remove all the 0 at the head
            var idx = 0;
            while (idx < newString.Length)
            {
                if (newString[idx] != '0')
                    break;
                idx++;
            }
            return idx < newString.Length ? newString.Substring(idx) : "0";
        }
    }
}
