using System.Collections.Generic;

namespace euler_from26
{
    public static class Prime
    {

        public static bool isDivisible(long n, int by) => n % by == 0;
        public static IEnumerable<long> Prime_to(long max)
        {
            long[] sieve = new long[max+1];
            // 0 means can be prime
            // 1 means compound
            for (long candidate = 2; candidate <= max; candidate++)
                if (sieve[candidate] == 0)
                {
                    long pin = candidate;
                    do
                    {
                        sieve[pin] = 1;
                        pin += candidate;
                    } while (pin <= max);
                    yield return candidate;
                }
        }

        public static long[] Primes(long max)
        {
            List<long>primes = new();
            foreach(long p in Prime_to(max))
                primes.Add(p);
            return primes.ToArray();
        }

        public static IEnumerable<int> Divisors(int N)
        {
            for (int candidate = 1; candidate <= N / 2; candidate++)
                if (N % candidate == 0)
                    yield return candidate;
        }

        public static List<long>Prime_Divisors(long n, long[] primes)
        {
            List<long> divisors = new ();
            int index = 0;
            while(n>1)
                if (n % primes[index] == 0)
                {
                    divisors.Add(primes[index]);
                    n /= primes[index];
                }
                else
                    index++;
            return divisors;
        }

        public static long[] Prime_Divisors_array(long n, long[] primes) => Prime_Divisors(n, primes).ToArray();

        public static HashSet<long> Prime_Unique_Divisors(long n, long[] primes) => new HashSet<long>(Prime_Divisors(n, primes));

        public static void Reduce_Divisors(List<int> p1, List<int> p2)
        {
            int n1 = 0;
            do
            {
                int n2 = p2.IndexOf(p1[n1]);
                if (n2 >= 0)
                {
                    p1.RemoveAt(n1);
                    p2.RemoveAt(n2);
                }
                else
                    n1++;
            } while (n1 < p1.Count);
            if (p1.Count == 0)
                p1.Add(1);
            if (p2.Count == 0)
                p2.Add(1);
        }

    }
}