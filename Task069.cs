using System;

namespace euler_from26
{
    public static class Task069
    {
        public static void main()
        {
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