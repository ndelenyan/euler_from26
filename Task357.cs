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

        public static IEnumerable<long[]> combos(long[] nums)
        {
            if (nums.Length == 1)
                yield return new long[] { nums[0] };
            else
                for (int i = 0; i < nums.Length; i++)
                {
                    yield return new long[] { nums[i] };
                    int restLen = nums.Length - i - 1;
                    long[] restNums = new long[restLen];
                    //                    Array.ConstrainedCopy(nums, 0, restNums, 0, i);
                    Array.ConstrainedCopy(nums, i + 1, restNums, 0, restLen);
                    foreach (var r in combos(restNums))
                    {
                        var res = MyCollections.AddArray(nums[i], r);
                        yield return res;
                    }
                }
        }
        public static bool i(long candidate)
        {
            if (candidate == 1 || candidate == 2) return true;
            foreach (var d in Prime.Divisors_2toSqrt(candidate))
            {
                if (Array.BinarySearch(primes, d + candidate / d) < 0)
                    return false;
            }
            return true;
        }

        public static void main()
        {
            long sum = 0;
            Console.Write("calculating primes... ");
            primes = Prime.Primes(100_000_001);
            Console.WriteLine("done");
            //             var d = MyCollections.toArray(Prime_Divisors_All(60));
            // //            Console.WriteLine(MyCollections.Print(d));
            //             foreach(var c in combos(d))
            //                  Console.WriteLine($"{MyCollections.Print(c)} {Functions.product(c)}");
            for (long j = 0; j < primes.Length; j++)
            {
                if (j % 10_000 == 0)
                    Console.WriteLine($"{j}/{primes.Length}:{sum}");
                var candidate = primes[j] - 1;
                if (i(candidate))
                    sum += candidate;
            }
            Console.WriteLine(sum);
            // 1739023853137
        }
    }
}