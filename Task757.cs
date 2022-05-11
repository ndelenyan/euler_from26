using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task757
    {
        public static void main()
        {
            long max = (long)Math.Pow(10, 14);
            HashSet<long> st = new();
            for (long x = 1; x < (long)Math.Sqrt(max); x++)
                for (long k = x; k < (long)(Math.Sqrt(max) / x); k++)
                {
                    long a = k * x;
                    long c = x * (k + 1);
                    long d = k * (x + 1);
                    long b = (k + 1) * (x + 1);
                    long candidate = x * (x + 1) * k * (k + 1);
                    //                    Console.WriteLine($"{a}*{b} = {c}*{d} = {candidate}");
                    if (candidate <= max)
                    {
                        st.Add(candidate);
                    }
                }
            Console.WriteLine(st.Count);
        }
    }
}