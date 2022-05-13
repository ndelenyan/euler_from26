using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task745
    {

        public static long[] sq;

        public static long g(long n)
        {
            for (int index = sq.Length - 1; index >= 0; index--)
                if (n % sq[index] == 0)
                    return sq[index];
            return 1;
        }

        public static void main()
        {
            long max = (long)Math.Pow(10, 14);
            long mod = 1_000_000_007;
            List<long> squares = new();
            for (long i = 1; i <= (long)Math.Sqrt(max); i++)
                squares.Add(i * i);
            sq = squares.ToArray();
            long[] count = new long[sq.Length];
            //            Console.WriteLine(MyCollections.Print(sq));
            for (int i = sq.Length - 1; i >= 0; i--)
            {
                count[i] = max / sq[i];
                // for (int j = sq.Length - 1; j > i; j--)
                //     if (sq[j] % sq[i] == 0)
                //         count[i] -= count[j];
                for (long m = 2; m <= Math.Sqrt(max / sq[i]); m++)
                {
                    int j = Array.BinarySearch(sq, sq[i] * m * m);
                    if (j >= 0)
                        count[i] -= count[j];
                }
                if (i % 10000 == 0)
                    Console.WriteLine(i);
            }
            //            Console.WriteLine(MyCollections.Print(count));
            long sum = 0;
            for (int k = 0; k < count.Length; k++)
                sum += (count[k] * sq[k]) % mod;
            Console.WriteLine(sum % mod);
            // long sum = 0;
            // for (long c = 1; c < sq.Length; c++)
            // {
            //     var gg = g(c);
            //     sum += gg;
            //     Console.WriteLine($"c:{c}\tg:{gg}\tS:{sum}");
            // }
            // Console.WriteLine(sum);
        }
    }
}