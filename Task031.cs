using System;
namespace euler_from26
{
    public static class Task31
    {
// 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p), and £2 (200p).
        public static int[] coins = new int[] {200, 100, 50, 20, 10, 5, 2, 1};

        public static int ways(int n, int index)
        {
            int sum = 0;
            if (index == coins.Length - 1)
                return 1;
            for (int i=n / coins[index]; i >= 0; i--)
                sum += ways(n - i * coins[index], index + 1);
            return sum;
        }

        public static void main()
        {
            Console.WriteLine(ways(200, 0));
        }
    }
}