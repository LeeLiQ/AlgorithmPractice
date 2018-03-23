using System;

namespace match_equation
{
    class Program
    {
        private static int[] numbers = new int[10] { 6, 2, 5, 5, 4, 5, 6, 3, 7, 6 };
        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out var target);
            for (var a = 0; a <= 1111; a++)
                for (var b = 0; b <= 1111; b++)
                {
                    var c = a + b;
                    if (CountMatch(a) + CountMatch(b) + CountMatch(c) == target - 4)
                    {
                        System.Console.WriteLine($"{a} + {b} = {c}");
                    }
                }

        }

        private static int CountMatch(int x)
        {
            var num = 0;
            while (x / 10 != 0)
            {
                num += numbers[x % 10];
                x = x / 10;
            }
            num += numbers[x];
            return num;
        }
    }
}
