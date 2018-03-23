using System;

namespace three_poker
{
    class Program
    {
        static void Main(string[] args)
        {
            var box = new int[3];
            var book = new int[3];

            Dfs(box, book, 0);
            System.Console.WriteLine();
        }

        private static void Dfs(int[] box, int[] book, int step)
        {
            if (step == 3)
            {
                foreach (var value in box)
                    System.Console.Write($"{value}  ");
                System.Console.WriteLine();
                return;
            }

            #region [what needs to be done in the current step]
            //loop through the possibility for current step.
            for (var i = 0; i < 3; i++)
            {
                if (book[i] == 0)
                {
                    box[step] = i + 1;
                    book[i] = 1;
                    Dfs(box, book, step + 1);
                    book[i] = 0;
                }

            }
            #endregion
        }
    }
}
