using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task074
    {

        public static long[] facts = new long[10];

        public static long digit_fact_sum(long n)
        {
            long sum = 0;
            foreach(var d in Digits.digits(n))
                sum += facts[d];
            return sum;
        }

        public static long chain_len(long n)
        {
            List<long> chain = new();
            do
            {
                chain.Add(n);
                n = digit_fact_sum(n);
            } while(!chain.Contains(n));
            return chain.Count;
        }

        public static void main ()
        {
            for (long i = 0; i < 10; i++)
                facts[i] = Functions.Factorial(i);
            // Console.WriteLine(digit_fact_sum(363600));
            // Console.WriteLine(chain_len(871));
            long count = 0;
            for(long i = 1; i < 1_000_000; i++)
                if (chain_len(i) == 60)
                    count++;
            Console.WriteLine(count);
        }
    }
}
