using System;

namespace euler_from26
{
    public static class Task050
    {

        public static long max = 1000000;

        public static long[] primes = Prime.Primes(max);

        public static int cons_primes_sum(long n, int index)
        {
            long sum = 0;
            int count = 0;
            do
            {
                count++;
                sum += primes[index++];
            } while (sum < n);
            return sum == n ? count : -1;
        }

        public static int longest(long n)
        {
            int max = 0;
            for (int i = 0; i < Array.IndexOf(primes, n); i++)
            {
                int z = cons_primes_sum(n, i);
                if (z > max)
                    max = z;
            }
            return max;
        }

        public static void main()
        {
            int max_len = 0;
            long max_n = 0;
            for (int i = primes.Length - 1; i > 0; i--)
            {
                int len = longest(primes[i]);
                if (len>0)
                    Console.WriteLine($"interim len {len}: {i}:{primes[i]}");
                if (len > max_len)
                {
                    max_len = len;
                    max_n = primes[i];
                }
            }
            Console.WriteLine($"Max: len:{max_len}, n = {max_n}");
            // interim len 543: 78333:997651
        }
    }
}