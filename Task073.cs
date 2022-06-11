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
            var dd = Prime.Prime_Divisors_List(d, primes, false);
            foreach(var nn in Prime.Prime_Divisors(n, primes, false))
                if (dd.Contains(nn))
                    return true;
            return false;
        }

        public static IEnumerable<Fraction>fractions(long d)
        {
            for (long dd = 1; dd <= d; dd++)
            {
                if (dd % 100 == 0)
                    Console.WriteLine(dd);
                for(long nn = 1; nn < dd; nn++)
                    if (!reducable(nn, dd))
                        yield return new Fraction(nn, dd);
            }
        }

        public static void main ()
        {
            List<Fraction> fracs = new();
            foreach(var f in fractions(max))
                fracs.Add(f);
            long count = 0;
            Fraction third = new Fraction(1, 3);
            Fraction half = new Fraction(1, 2);
            foreach(Fraction f in fracs)
                if (f > third && f < half)
                    count++;
            Console.WriteLine(count);
        }
    }
}
