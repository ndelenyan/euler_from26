using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task062
    {
        public static long[] primes = { 2, 3, 4, 5, 7, 11, 13, 17, 19, 23, 29 };
        public static long key(long[] digits)
        {
            long k = 1;
            for (int i = 0; i < digits.Length; i++)
                k *= (long)Math.Pow(primes[i], digits[i]);
            return k;
        }

        public static long[] countDigits(IEnumerable<int> digits)
        {
            long[] res = new long[10];
            foreach(var d in digits)
                res[d]++;
            return res;
        }

        public static Dictionary<long, long> min = new();
        public static Dictionary<long, int> count = new();
        public static void main()
        {
            // 0    1   2   3   4   5   6   7   8   9   
            // 2    3   5   7   11  13  17  19  23  29
            long i = 1;
            long k = 0;
            do
            {
                k = key(countDigits(Digits.digits((long)(Math.Pow(i, 3)))));
                if (!min.ContainsKey(k))
                {
                    min.Add(k, i);
                    count.Add(k, 1);
                }
                else
                    count[k]++;
                i++;
            } while (count[k] < 5);
            Console.WriteLine((long)Math.Pow(min[k], 3));
        }
    }
}