using System;

namespace euler_from26
{
    public static class Task060
    {
        public static long max_max = 100_000_000;
        public static long[] primes = Prime.Primes(max_max);
        public static long max = Array.BinarySearch(primes, 79693);

        public static bool check_pair(long p1, long p2)
        {
            var p1_len = Digits.digit_len(p1);
            var p2_len = Digits.digit_len(p2);
            var p1c = (long)Math.Pow(10, p1_len); 
            var p2c = (long)Math.Pow(10, p2_len); 
            var c1 = p2 * p1c + p1;
            var c2 = p1 * p2c + p2;
            return Array.BinarySearch(primes, c1) >= 0 && Array.BinarySearch(primes, c2) >= 0;
        }

        public static bool check_pairs(long[] prev, long n)
        {
            foreach (var p in prev)
                if (!check_pair(p, n))
                    return false;
            return true;
        }

        public static long[] add(long[] source, long d)
        {
            long[] res = new long[source.Length + 1];
            Array.ConstrainedCopy(source, 0, res, 0, source.Length);
            res[source.Length] = d;
            return res;
        }

        public static void main ()
        {
            long c = 0;
            long start = 0;
            Console.WriteLine(max);
            // max = 10_000;
            long[] chain = new long[0];
            while(start < max)
            {
                c = start;
                chain = new long[0];
                while(c < max && chain.Length < 5)
                {
                    if (check_pairs(chain, primes[c]))
                        chain = add(chain, primes[c]);
                    c++;
                }
                if (chain.Length == 5)
                {
                    Console.WriteLine($"{MyCollections.Print(chain)} {Functions.sum(chain)}");
                    return;
                }
                start++;
            }
        }
    }
}
