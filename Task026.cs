using System;
using System.Collections.Generic;
using System.Numerics;

namespace euler_from26
{
    public static class Task26
    {
        public static long cycle_len(long p)
        {
            for (int candidate = 2; candidate <= p; candidate++)
                if (BigInteger.ModPow(10, candidate, p) == 1) 
                    return candidate;
            return 0;
        }

        public static void main()
        {
            long max = 0;
            long max_d = 0;
            foreach(var d in Prime.Prime_to(1000))
            {
                long c = cycle_len(d);
                if (c > max)
                {
                    max = c;
                    max_d = d;
                }
            }
            Console.WriteLine(max_d);
        }



    }
}