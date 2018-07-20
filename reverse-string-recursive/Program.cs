using System;

namespace reverse_string_recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "12345";

            Console.WriteLine(Reverse(input));
        }

        private static string Reverse(string input)
        {
            if (input.Length == 1)
                return input;

            return Reverse(input.Substring(1)) + input[0];
        }
    }
}
