using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace euler_from26
{

    public static class Task072
    {
        public static long max = 1_000_000;
        public static long[] primes = Prime.Primes(max);
        public static long[][] divisors = new long[max + 1][];
        public static void main ()
        {
            Console.WriteLine("Task072");
            long sum = 0;
            for (long i = 2; i <= max; i++)
            {
                if (i%10_000 == 0)
                    Console.WriteLine(i);
                sum += Prime.totient(i, primes);
            }
            Console.WriteLine(sum);
        }
    }
}
