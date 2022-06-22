using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace euler_from26
{

    public static class Task072
    {
        public static long max = 1_000_000;
        public static long[] primes = Prime.Primes(max);
        public static long[][] divisors = new long[max + 1][];
        public static void main ()
        {
            Console.WriteLine("Task072");
            for(long i = 1; i <= max; i++)
            {
                if (i % 10_000 == 0)
                    Console.WriteLine($"{i} / {max}");
                var h = Prime.Prime_Unique_Divisors(i, primes, false);
                divisors[i] = new long[h.Count];
                int j = 0;
                foreach(var c in h)
                    divisors[i][j++] = c;
            }
            divisors[1] = new long[] {1};
            // for (int i = 1; i <= 10; i++)
            //     Console.WriteLine(MyCollections.Print(divisors[i]));
            long count = 0;
            Parallel.For(1, max + 1, i =>
            {
                if (i % 10_000 == 0)
                    Console.WriteLine($"{i} / {max}");
                for(long j = 1; j < i; j++)
                {
                    bool are_reducible = false;
                    foreach (var d in divisors[j])
                        if (Array.BinarySearch(divisors[i], d) >= 0)
                        {
                            are_reducible = true;
                            break;
                        }
                    if (! are_reducible)
                        count++;                    
                }
            });
            Console.WriteLine(count);
        }
    }
}
