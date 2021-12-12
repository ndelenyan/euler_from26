using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task35
    {

        public static long[] primes;
        public static bool isCircular(List<long> digits)
        {
            for (int i = 0; i < digits.Count - 1; i++)
            {
                Digits.Rotate_Digits(digits);
                if (Array.IndexOf(primes, Digits.int_from_digits(digits)) < 0)
                    return false;
            }
            return true;
        }

        public static void main()
        {
            int count = 0;
            primes = Prime.Primes(1000000);
            foreach(var p in primes)
            {
                var candidate = Digits.digits_list(p);
                if (isCircular(candidate))
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}