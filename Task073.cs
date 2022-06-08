using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task073
    {

        public static long max = 12_000;

        public static long[] primes = Prime.Primes(max);

        public static bool reducable(long d, long n)
        {
            var nn = Prime.Prime_Divisors(n, primes);
            foreach(var p in nn)
                Console.WriteLine(p);
            return false;
        }

        public static IEnumerable<Fraction>fractions(long d)
        {
            for (long dd = 1; dd <= d; dd++)
                for(long nn = 1; nn < dd; nn++)
                {
                    Fraction f = new Fraction(nn, dd);
                    yield return f;
                }
        }

        public static void main ()
        {
            // foreach(var f in fractions(8))
            //     Console.WriteLine(f);
            // Console.WriteLine("Task073");
            reducable(8, 8);
        }
    }
}
