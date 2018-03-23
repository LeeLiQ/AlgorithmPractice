using System;

namespace simple_dfs
{
    class Program
    {
        private static int total = 0;
        static void Main(string[] args)
        {
            var a = new int[9];
            var book = new int[9];
            Dfs(1, a, book);
            System.Console.WriteLine($"total = {total}");
        }

        static void Dfs(int step, int[] a, int[] book)
        {
            int i;

            if (step == 10)
            {
                if (a[0] * 100 + a[1] * 10 + a[2]
                + a[3] * 100 + a[4] * 10 + a[5]
                == a[6] * 100 + a[7] * 10 + a[8])
                {
                    total++;
                    System.Console.WriteLine($"{a[0]}{a[1]}{a[2]}+{a[3]}{a[4]}{a[5]}={a[6]}{a[7]}{a[8]}");
                    return;
                }
            }
            for (i = 1; i <= 9; i++)
            {
                if (book[i - 1] == 0)
                {
                    a[step - 1] = i;
                    book[i - 1] = 1;
                    Dfs(step + 1, a, book);
                    book[i - 1] = 0;
                }
            }
            return;
        }
    }
}
