using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task48
    {
        public static void main()
        {
            BigInteger mod = BigInteger.Pow(10, 10);
            Console.WriteLine(mod);
            BigInteger sum = 0;
            for (BigInteger i = 1; i <= 1000; i++)
            {
                sum += BigInteger.ModPow(i, i, mod);
            }
            Console.WriteLine(sum);
        }
    }
}