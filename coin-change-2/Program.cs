using System;

namespace coin_change_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var amount = 5;
            var coins = new int[] { 1, 2, 5 };
            var result = Change(amount, coins);
            var result2 = ChangeArray(amount, coins);
            System.Console.WriteLine(result);
            System.Console.WriteLine(result2);
        }

        private static int Change(int amount, int[] coins)
        {
            var dp = new int[amount + 1];
            dp[0] = 1;

            foreach (var coin in coins)
                for (var i = coin; i <= amount; i++)
                    dp[i] += dp[i - coin];
            return dp[amount];
        }

        private static int ChangeArray(int amount, int[] coins)
        {
            //the reason for +1 is that, 0 coins is considered, 0 amount is also considered
            var dp = new int[coins.Length + 1, amount + 1];

            for (var i = 1; i < coins.Length + 1; i++)
            {
                //0 amount with more than 0 coins is always 1 since no coin needed is a solution
                dp[i, 0] = 1;

                for (var j = 1; j <= amount; j++)
                {
                    if (j >= coins[i - 1])
                        dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i - 1]];
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }
            return dp[coins.Length, amount];
        }
    }
}
