using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task053
    {

        
        public static void main()
        {
            int count = 0;
            for (BigInteger n = 2; n <= 100; n++)
                for (BigInteger r = 2; r < n; r++)
                    if (Functions.C(n, r) > 1000000)
                        count++;
            Console.WriteLine(count);
        }
    }
}