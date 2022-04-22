using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task076
    {

        public static int[] coins = new int[99];

        public static int ways(int n, int index)
        {
            int sum = 0;
            if (index == coins.Length - 1)
                return 1;
            for (int i = n / coins[index]; i >= 0; i--)
                sum += ways(n - i * coins[index], index + 1);
            return sum;
        }

        public static void main()
        {
            for (int i = 0; i < 99; i++)
                coins[i] = 99 - i;
            Console.WriteLine(ways(100, 0));
        }
    }
}