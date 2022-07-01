using System;

namespace euler_from26
{
    public static class Task069
    {
        public static void main()
        {
            /*
            n/f(n) -> max
            f(n) = n * P (1 - 1/p)
            n / f (n) = 1 / P (1 - 1/p) -> max
            P (1 - 1/p) -> min
            is
            number of p -> max
            p -> min

            */
            long max = 1_000_000;
            var primes = Prime.Prime_to(max);
            long res = 1;
            foreach(var p in primes)
                if (res * p < max)
                    res *= p;
                else
                    break;
            System.Console.WriteLine(res);
        }
    }
}