using System;

namespace euler_from26
{

    public static class Task46
    {

        public static int max = 1000000;
        public static int [] primes = Prime.Primes(max);

        public static bool isGoldbach(int n)
        {
            int firstSq = (int)Math.Sqrt(n/2);
            for (int sq = firstSq; sq >= 1; sq--)
                if (Array.IndexOf(primes, n - 2 * sq * sq) >= 0)
                    return true;
            return false;
        }

        public static void main()
        {
            int candidate = 3;
            do
            {
                candidate += 2;
                if (Array.IndexOf(primes, candidate) >= 0)
                    continue;
                if (!isGoldbach(candidate))
                    Console.WriteLine($"Goldbach xception: {candidate}");
            } while (candidate < max);
            Console.WriteLine("none found");
        }
    }
}