using System;

namespace reverse_word_in_place
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "one two three";
            var charArray = input.ToCharArray();
            ReverseChars(charArray, 0, input.Length - 1);
            int start = 0, end = 0;
            while (start < input.Length)
            {
                if (charArray[start] == ' ')
                {
                    start++;
                    end++;
                }
                else if (end == input.Length || charArray[end] == ' ')
                {
                    ReverseChars(charArray, start, end - 1);
                    start = end + 1;
                    end++;
                }
                else
                    end++;
            }
            System.Console.WriteLine(new string(charArray));
            System.Console.WriteLine("++++++++++++++++++++");
        }

        private static void ReverseChars(char[] arr, int start, int end)
        {
            while (start < end)
            {
                var temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }
    }
}
