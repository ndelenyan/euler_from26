using System;
using System.Collections.Generic;
using System.Numerics;

namespace euler_from26
{
    public static class Prime
    {

        public static bool isDivisible(BigInteger n, BigInteger by) => n % by == 0;
        public static IEnumerable<long> Prime_to(long max)
        {
            long[] sieve = new long[max + 1];
            // 0 means can be prime
            // 1 means compound
            yield return 1;
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
            List<long> primes = new();
            foreach (long p in Prime_to(max))
                primes.Add(p);
            return primes.ToArray();
        }

        public static IEnumerable<long> Divisors(long N)
        {
            for (long candidate = 1; candidate <= N / 2; candidate++)
                if (N % candidate == 0)
                    yield return candidate;
            yield return N;
        }

        public static IEnumerable<long> Divisors_2toSqrt(long N)
        {
            for (long candidate = 2; candidate <= (long)Math.Sqrt(N); candidate++)
                if (N % candidate == 0)
                    yield return candidate;
            //            yield return N;
        }



        public static IEnumerable<long> Prime_Divisors(long n, long[] primes, bool one = true)
        {
            int index = one ? 0 : 1;
            while (n > 1)
                if (n % primes[index] == 0)
                {
                    n /= primes[index];
                    yield return primes[index];
                }
                else
                    index++;
        }

        public static List<long> Prime_Divisors_List(long n, long[] primes, bool one = true)
        {
            List<long> divisors = new();
            foreach (var d in Prime_Divisors(n, primes, one))
                divisors.Add(d);
            return divisors;
        }

        public static HashSet<long> Prime_Unique_Divisors(long n, long[] primes, bool one = true) => new HashSet<long>(Prime_Divisors(n, primes, one));

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

        public static long totient(long n, long[] primes)
        {
            // for prime numbers phi(n) = n-1
            if (n==1)
                return 1;
            else if (Array.BinarySearch(primes, n) >= 0)
                return n - 1;
            else
            {
                var p = Prime_Unique_Divisors(n, primes, false);
                long no = 1;
                long de = 1;
                foreach(var pp in p)
                {
                    no *= pp - 1;
                    de *= pp;
                }
                return n * no / de;
            }
        }

    }
}