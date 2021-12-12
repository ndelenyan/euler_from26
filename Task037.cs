using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task37
    {
        public static long max = 1000000;
        public static long[] primes = Prime.Primes(max);
        public static bool isTunc(long[] digits)
        {
            for (int i=1; i<digits.Length; i++)
            {
                int[] check = new int[i];
                Array.ConstrainedCopy(digits, 0, check, 0, i);
                if (Array.IndexOf(primes, Digits.int_from_digits(check)) < 0)
                    return false;
                Array.ConstrainedCopy(digits, digits.Length - i, check, 0, i);
                if (Array.IndexOf(primes, Digits.int_from_digits(check)) < 0)
                    return false;
            }
            return true;
        }
        public static void main()
        {
            long sum = 0;
            long n = 0;
            for (int i = Array.IndexOf(primes, 11); i < primes.Length; i++)
                if (isTunc(Digits.digits_array(primes[i])))
                {
                    Console.WriteLine($"{++n}:\t{primes[i]}");
                    sum += primes[i];
                }
            Console.WriteLine(sum);
        }
    }
}