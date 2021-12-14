using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task097
    {
        public static void main()
        {
            BigInteger B = 28433 * BigInteger.ModPow(2, 7830457, 10000000000) + 1;
            var bb = Digits.digitsAsArray(B);
            for (int i = 0; i < 10; i++)
                Console.Write(bb[i]);
            Console.WriteLine(B);
        }
    }
}