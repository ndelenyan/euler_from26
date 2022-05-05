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
            long[] sieve = new long[max+1];
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
            List<long>primes = new();
            foreach(long p in Prime_to(max))
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

        public static IEnumerable<long[]>combos(long[] nums)
        {
            if (nums.Length == 1)
                yield return new long[] { nums[0] };
            else
                for (int i = 0; i < nums.Length; i++)
                {
                    yield return new long[] { nums[i] };
                    int restLen = nums.Length - 1;
                    long[] restNums = new long[restLen];
                    Array.ConstrainedCopy(nums, 0, restNums, 0, i);
                    Array.ConstrainedCopy(nums, i + 1, restNums, i, nums.Length - i - 1);
                    foreach(var r in combos(restNums))
                    {
                        var res = MyCollections.AddArray(nums[i], r);
                        yield return res;
                    }
                }
        }

        public static IEnumerable<long> Prime_Divisors_All(long n, long[] primes)
        {
            yield return 1;
            int index = 1;
            while (n > 1)
            {
                while (n % primes[index] == 0)
                {
                    n /= primes[index];
                    yield return primes[index];
                }
                index++;
            }
        }


        public static IEnumerable<long>Prime_Divisors(long n, long[] primes)
        {
            int index = 0;
            while (n > 1)
                if (n % primes[index] == 0)
                {
                    n /= primes[index];
                    yield return primes[index];
                }
                else
                    index++;
        }

        public static List<long>Prime_Divisors_List(long n, long[] primes)
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

        //public static long[] Prime_Divisors_array(long n, long[] primes) => Prime_Divisors(n, primes).ToArray();

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