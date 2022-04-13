using System;
using System.Numerics;
using System.Collections.Generic;

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
                return (n % 9 + 1) * BigInteger.Pow(10, n / 9) - 1;
        }

        public static BigInteger S(long k, BigInteger mod)
        {
            BigInteger sum = 5 * (BigInteger.Pow(10, k / 9) - 1);
            for (int n = 1; n <= k; n++)
                sum += s_fast(n);
            return sum % mod;
        }

        public static long[] F(long count)
        {
            long[] res = new long[count];
            res[0] = 0;
            res[1] = 1;
            for (int i = 2; i < count; i++)
                res[i] = res[i - 2] + res[i - 1];
            return res;
        }

        public static void main()
        {
            BigInteger mod = 1_000_000_007;
//            System.Console.WriteLine(S(20, mod));
            var f = F(90);
            // System.Console.WriteLine(MyCollections.Print(f));
            for (int i=2; i <= 90; i++)
                Console.WriteLine($"{i}:\t{f[i]}:\t{S(f[i], mod)}");
            // for (int i = 1; i < 20; i++)
            //     System.Console.WriteLine($"{i}: {S(i, mod)}");
        }
    }
}