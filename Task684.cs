using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task684
    {

        public static int s(int n)
        {
            int i = 0;
            BigInteger dd;
            do
            {
                i++;
                dd = Digits.digit_sum(i);
            } while (dd != n);
            return i;
        }

        public static BigInteger s_fast(int n)
        {
            if (n < 10)
                return n;
            int nines = n / 9;
            int rest = n % 9;
            int[] digits = new int[rest == 0 ? nines : nines + 1];
            Array.Fill<int>(digits, 9);
            if (rest > 0)
                digits[nines] = rest;
            return Digits.int_from_digits(digits);
        }

        public static BigInteger S(BigInteger k, BigInteger mod)
        {
            BigInteger sum = 0;
            for (int n = 1; n <= k; n++)
                sum += s_fast(n);
            return sum;
        }

        public static void main()
        {
            BigInteger mod = 1_000_000_007;
            var F = Functions.Fibonacci(90);
            for (int i=2; i <= 90; i++)
                Console.WriteLine($"{i}:\t{F[i]}:\t{S(F[i], mod)}");
        }
    }
}