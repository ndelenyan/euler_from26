using System;
using System.Linq;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task051
    {

        public static long[] primes(int len)
        {
            var r = Prime.Primes((long)Math.Pow(10, len));
            Console.WriteLine(r[r.Length - 1]);
            var res = r.Where(t => t >= Math.Pow(10, len - 1));
            return res.ToArray();
        }

        public static long[][] digits(long[] primes)
        {
            long[][] res = new long[primes.Length][];
            for (int i = 0; i < primes.Length; i++)
                res[i] = Digits.digitsAsArray(primes[i]);
            return res;
        }

        public static IEnumerable<long[]> select(long[] from, long n)
        {
            if (n == 1)
                foreach (var d in from)
                    yield return new long[] { d };
            else
                for (int i = 0; i < from.Length; i++)
                {
                    var r = Functions.rest(from, i);
                    foreach (var rr in select(r, n - 1))
                        yield return MyCollections.AddArray(from[i], rr);
                }
        }

        public static long[][] masks(long len, long n)
        {
            long[] ini = new long[len];
            for (int i = 0; i < len; i++)
                ini[i] = i;
            return select(ini, n).ToArray();
        }

        public static bool digits_suits_mask(long[] digits, long[] mask)
        {
            for (int i = 1; i < mask.Length; i++)
                if (digits[mask[0]] != digits[mask[i]])
                    return false;
            return true;
        }

        public static void main()
        {
            // foreach (var rr in r)
            //     Console.WriteLine(MyCollections.Print(rr));
            // foreach (var r in masks(4, 3))
            //     Console.WriteLine(MyCollections.Print(r));
            // var d = Digits.digitsAsArray(3224);
            // var mask = new long[] { 1, 3 };
            // Console.WriteLine(digits_suits_mask(d, mask));
            int num_len = 3;
            bool done = false;
            do
            {
                var r = digits(primes(num_len));
                for (long mask_len = 1; mask_len < num_len; mask_len++)
                {
                    var ms = masks(num_len - 1, mask_len);
                    for (int i = 0; i < ms.Length; i++)
                    {
                        long[] count = new long[ms[i].Length];
                        foreach (var rr in r)
                            if (digits_suits_mask(rr, ms[i]))
                            {
                                count[i]++;
                                if (count[i] >= 8)
                                {
                                    Console.WriteLine(Digits.int_from_digits(rr));
                                    done = true;
                                }
                            }
                    }
                }
                num_len++;
            } while (!done);
        }
    }
}