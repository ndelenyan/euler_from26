using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace euler_from26
{
    public static class Task357
    {

        public static long[] primes;

        public static IEnumerable<long> Prime_Divisors_All(long n)
        {
            yield return 1;
            int index = 1;
            while (n > 1)
            {
                while (n % primes[index] == 0)
                {
                    n /= primes[index];
                    yield return primes[index];
                }
                index++;
            }
        }


        public static bool i(long candidate)
        {
            var d = MyCollections.toArray(Prime_Divisors_All(candidate));
            foreach (var dd in Prime.combos(d))
            {
                long ddd = (long)Functions.product(dd);
                if (Array.BinarySearch(primes, ddd + candidate / ddd) < 0)
                    return false;
            }
            return true;
        }

        public static void main()
        {
            long sum = 0;
            Console.Write("calculating primes... ");
            primes = Prime.Primes(100_000_000);
            Console.WriteLine("done");
            var d = MyCollections.toArray(Prime_Divisors_All(60));
//            Console.WriteLine(MyCollections.Print(d));
            foreach(var c in Prime.combos(d))
                 Console.WriteLine($"{MyCollections.Print(c)} {Functions.product(c)}");
            // int count = 0;
            // Parallel.For(0, primes.Length, j =>
            // {
            //     count++;
            //     if (count % 10_000 == 0)
            //         Console.WriteLine($"{count}/{primes.Length}:{sum}");
            //     var candidate = primes[j] - 1;
            //     if ((candidate / 2) % 2 == 0)
            //         return;
            //     else if (i(candidate))
            //             sum += candidate;
            // });
            // Console.WriteLine(sum);
        }
    }
}