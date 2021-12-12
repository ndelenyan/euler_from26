using System;
using System.Collections.Generic;
using System.Numerics;

namespace euler_from26
{
    public static class Task26
    {
        public static int cycle_len(int p)
        {
            for (int candidate = 2; candidate <= p; candidate++)
                if (BigInteger.ModPow(10, candidate, p) == 1) 
                    return candidate;
            return 0;
        }

        public static void main()
        {
            int max = 0;
            int max_d = 0;
            foreach(var d in Prime.Prime_to(1000))
            {
                int c = cycle_len(d);
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