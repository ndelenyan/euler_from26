using System;

namespace euler_from26
{
    public static class Task357
    {

        public static long[] primes;

        public static bool i(long candidate)
        {
            foreach (var d in Prime.Divisors(candidate))
            {
                if (Array.BinarySearch(primes, d + candidate / d) < 0)
                    return false;
                if (d >= candidate / d)
                    return true;
            }
            return true;
        }

        public static void main()
        {
            long sum = 0;
            Console.Write("calculating primes... ");
            primes = Prime.Primes(100_000_000);
            Console.WriteLine("done");
            for (int j = 0; j <= primes.Length; j++)
            {
                if (j % 10_000 == 0)
                    Console.WriteLine($"{j}/{primes.Length}");
                var candidate = primes[j] - 1;
                if (i(candidate))
                    sum += candidate;
            }
            Console.WriteLine(sum);
        }
    }
}