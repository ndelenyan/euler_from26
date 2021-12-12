using System;
using System.Collections.Generic;
namespace euler_from26
{
    public static class Task27
    {

        public static int value(int a, int b, int n) => n * n + a * n + b;

        public static IEnumerable<int> candidate(int a, int b)
        {
            for (int n=0; n < Math.Abs(a * b); n++)
                yield return value(a, b, n);
        }
        public static long[] primes;

        public static int conseq_primes(int a, int b)
        {
            int n = 0;
            foreach(var c in candidate(a, b))
                if (Array.BinarySearch(primes, c) >= 0)
                    n++;
                else
                    return n;
            return n;
        }

        public static void main()
        {
            int a_min = -1000;
            int a_max = 1000;
            int b_min = -1000;
            int b_max = 1000;
            int n_max = b_max * b_max + a_max * b_max + b_max;
            int ab_max = 0;
            long n_maxx = 0;
            primes = Prime.Primes(n_max);
            for (int a = a_min; a <= a_max; a++)
                for (int b = b_min; b <= b_max; b++)
                {
                    int n_q = conseq_primes(a, b);
                    if (n_q > n_maxx)
                    {
                        n_maxx = n_q;
                        ab_max = a * b;
                    }
                }
                    
            Console.WriteLine(ab_max);
        }
    }
}