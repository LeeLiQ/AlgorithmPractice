using System;
using System.Text;
using System.Collections.Generic;

namespace decode_string
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "3[a]2[b]";
            var result = DecodeString(input);
            Console.WriteLine(result);
        }

        private static string DecodeString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;
            var result = new StringBuilder();

            var st = new Stack<char>();
            var countOfLeft = 0;
            foreach (var c in s)
            {
                if (c == '[')
                    countOfLeft++;
                else if (c == ']')
                {
                    countOfLeft--;
                    var sb = new List<char>();
                    while (!Char.IsDigit(st.Peek()))
                        sb.Add(st.Pop());
                    var multiplier = st.Pop(); // this line is wrong since it doesn't consider coefficient to be > 9
                    var arr = sb.ToArray();
                    Array.Reverse(arr);
                    var unit = new string(arr);
                    var temp = new StringBuilder();
                    for (var i = 0; i < multiplier; i++)
                        temp.Append(unit);
                    if (countOfLeft == 0)
                        result.Append(temp.ToString());
                    else
                        foreach (var k in temp.ToString())
                            st.Push(k);
                }
                else
                    st.Push(c);
            }

            return result.ToString();
        }
    }
}
