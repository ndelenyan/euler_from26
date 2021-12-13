using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task056
    {

        public static long sum(int[] d)
        {
            long r = 0;
            foreach(var dd in d)
                r += dd;
            return r;
        }

        public static void main()
        {
            long r_max = 0;
            for (int a = 1; a < 100; a++)
                for (int b = 0; b < 100; b++)
                {
                    BigInteger B = BigInteger.Pow(a, b);
                    var digits = Digits.digitsAsArray(B);
                    long r = sum(digits);
                    if (r > r_max)
                        r_max = r;
                }
            Console.WriteLine(r_max);
        }
    }
}