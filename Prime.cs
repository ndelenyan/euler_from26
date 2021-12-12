using System.Collections.Generic;

namespace euler_from26
{
    public static class Prime
    {

        public static bool isDivisible(long n, int by) => n % by == 0;
        public static IEnumerable<int> Prime_to(int max)
        {
            int[] sieve = new int[max+1];
            // 0 means can be prime
            // 1 means compound
            for (int candidate = 2; candidate <= max; candidate++)
                if (sieve[candidate] == 0)
                {
                    int pin = candidate;
                    do
                    {
                        sieve[pin] = 1;
                        pin += candidate;
                    } while (pin <= max);
                    yield return candidate;
                }
        }

        public static int[] Primes(int max)
        {
            List<int>primes = new();
            foreach(int p in Prime_to(max))
                primes.Add(p);
            return primes.ToArray();
        }

        public static IEnumerable<int> Divisors(int N)
        {
            for (int candidate = 1; candidate <= N / 2; candidate++)
                if (N % candidate == 0)
                    yield return candidate;
        }

        public static List<int>Prime_Divisors(int n, int[] primes)
        {
            List<int> divisors = new ();
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

        public static int[] Prime_Divisors_array(int n, int [] primes) => Prime_Divisors(n, primes).ToArray();

        public static HashSet<int> Prime_Unique_Divisors(int n, int[] primes) => new HashSet<int>(Prime_Divisors(n, primes));

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