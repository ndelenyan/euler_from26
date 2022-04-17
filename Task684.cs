using System;
using System.Numerics;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task684
    {

        public static long mod = 1_000_000_007;
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

        public static long S(long n, BigInteger mod)
        {
            var nd9 = n / 9;
            var np9 = n % 9;
            var pow = Math.Pow(10, nd9);
            var k = (np9 + 1) * (np9 + 2) / 2;
            var v = 5 * (pow - 1);
            var w = pow * k;
            return (long)(v + w - n - 1);
        }

        public static long S_mod(long n, long mod)
        {
            var nd9 = n / 9;
            var np9 = n % 9;
//            var pow = Math.Pow(10, nd9);
            long pow = (long)BigInteger.ModPow(10, nd9, mod);
            //            BigInteger nd9 = BigInteger.DivRem()
            var k = (np9 + 1) * (np9 + 2) / 2;
            var v = 5 * (pow - 1);
            var w = pow * k;
            long res = (long)((v + w - n - 1) % mod);
            while(res < 0)
                res += mod;
            return res;
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
            System.Console.WriteLine($"{S(20, mod)} {S_mod(20, mod)}");
            var f = F(91);
            long sum = 0;
            for (int i = 2; i <= 90; i++)
            {
                sum += S_mod(f[i], mod);
                sum = sum % mod;
                Console.WriteLine($"{i}:\t{f[i]}:\t{S_mod(f[i], mod)}\t{sum}");
            }
            System.Console.WriteLine(sum);
        }
    }
}