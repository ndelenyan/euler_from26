using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task052
    {

        public static long[] primes = Prime.Primes(100);

        public static long signature(long n)
        {
            long s = 1;
            foreach(var d in Digits.digits(n))
                s *= primes[d];
            return s;
        }

        public static void main()
        {
            long n = 1;
            bool same;
            do
            {
                n++;
                long s = signature(n);
                long s2 = signature(2 * n);
                long s3 = signature(3 * n);
                long s4 = signature(4 * n);
                long s5 = signature(5 * n);
                long s6 = signature(6 * n);
                same = s == s2 && s == s3 && s == s4 && s == s5 && s == s6;
            } while (!same);
            Console.WriteLine(n);
        }
    }
}