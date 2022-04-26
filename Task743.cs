using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task743
    {

        public static long mod = 1_000_000_007;

        public static BigInteger f2(long k, long n)
        {
            for (long o = k % 2; o <= k; o+=2)
            {
                BigInteger f = 1;
                if (o==0)
                {
                    // for (long i = k / 2 + 1; i <= k; i++)
                    // {
                    //     if (i % 1000 == 0)
                    //         Console.WriteLine(i);
                    //     f *= i;
                    // }
                    for (long j = 2; j <= k / 2; j++)
                    {
                        if (j % 1000 == 0)
                            Console.WriteLine(j);
                        f /= j;
                    }
                }
            }
                return 0;
        }

        public static BigInteger f(long k, long n)
        {
            BigInteger sum = 0;
            BigInteger fo = 0;
            Console.WriteLine("counting n2k...");
            BigInteger n2k = BigInteger.ModPow(4, (int)(n / k), mod);
            BigInteger n2ki = BigInteger.ModPow(n2k, mod - 2, mod);
            Console.WriteLine("done");
            for (long o = k; o >= 0; o -= 2)
            {
                if (o % 1000 == 0)
                    Console.WriteLine(o);
                if (o==k)
                    fo = BigInteger.ModPow(2, n, mod);
                else
                {
                    BigInteger koi = BigInteger.ModPow((k - o) * (k - o), mod - 2, mod);
                    fo = ((fo * 4) * (o + 1) * (o + 2) * n2ki * koi) % mod;
                }
                sum += fo;
//                sum %= mod;
            }
            return sum % mod;
        }

        public static void main()
        {
            // n  k
            // k windows repeat
            // sum in k = k; zeros = twos
            // in each window 1 can be 01 or 10
            // o - number of 1s in k-windows
            // k - o is even (0s = 2s) => o % 2 = k % 2
            // 0s = 2s = (k-o)/2
            // ways to put o 1s in k places = C(k, o)
            // ways to put (k-o) / 2 0s in n places = C(k, (k-o)/2)
            // then sum o 0..k
            // o 1s can be 2^o
            // in other k-windows 1s can be different
            // Console.WriteLine(f(3, 9));
            // Console.WriteLine(f(4, 20));
            Console.WriteLine("start");
            Console.WriteLine(f(100000000, 10000000000000000));
        }
    }
}