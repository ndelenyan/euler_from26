using System;

namespace euler_from26
{
    public static class Task41
    {
        public static long[] primes = Prime.Primes(999999999+1);
        public static void main()
        {
            for (long i = primes.Length - 1; i >= 1; i--)
                if (Digits.isPandigital(Digits.digit_len(primes[i]), (int)primes[i]))
                {
                    Console.WriteLine(primes[i]);
                    break;
                }
        }
    }
}