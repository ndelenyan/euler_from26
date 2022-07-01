using System;

namespace euler_from26
{
    public static class Task070
    {
        /*
        n / f(n) -> min
        f(n) = n * P (1 - 1/p)
        n / f (n) = 1 / P (1 - 1/p) -> min
        P (1 - 1/p) -> max
        is
        number of p -> min
        p -> max
        */

        public static void main ()
        {
            long max = (long)Math.Pow(10, 7);
            Console.WriteLine("Task070");
            Console.WriteLine("start prime generation");
            var primes = Prime.Primes(max);
            Console.WriteLine("done prime generation");
            Console.WriteLine(primes.Length); // 664580
            var t = 664580/2;
            Console.WriteLine($"{t}:\t{primes[t]}");
            var d = primes[t] - 1;
            // var i = Array.BinarySearch(primes, d);
            // Console.WriteLine($"{i} {~i}");
            Console.WriteLine($"1 prime");
            for(long i = primes.Length - 1; i >= 0; i--)
            {
                long p = primes[i];
                long f = Prime.totient(p, primes);
                if (Digits.are_permutation(p, f))
                    Console.WriteLine($"n = {p}, rel = {(double)p/(double)f}");
            }
            Console.WriteLine("1 done");
            Console.WriteLine($"2 primes");
            for(long i = primes.Length - 1; i >= 0; i--)
            {
                if (i% 10_000 == 0)
                    Console.WriteLine(i);
                long j = 0;
                long p = primes[i] * primes[j];
                while(p <= max)
                {
                    long f = Prime.totient(p, primes);
                    if (Digits.are_permutation(p, f))
                        Console.WriteLine($"n = {p}, rel = {(double)p/(double)f}");
                    j++;
                    p = primes[i] * primes[j];
                }
            }
            Console.WriteLine("2 done");
        }
    }
}
