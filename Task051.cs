using System;
using System.Linq;
using System.Collections.Generic;

namespace euler_from26
{

    public struct mask_rest
    {
        public long[] mask;
        public long[] rest;
    }

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

        public static long num_from_digits_mask(long[] digits, long[] mask)
        {
            long[] masked_digits = new long[mask.Length];
            for (int i = 0; i < mask.Length; i++)
                masked_digits[i] = digits[mask[i]];
            return (long)Digits.int_from_digits(masked_digits);
        }

        public static IEnumerable<mask_rest> select(long[] from, long n)
        {
            if (n == 0)
                yield return new mask_rest() { mask = new long[0], rest = from };
            else
                for (int i = 0; i < from.Length; i++)
                {
                    var r = Functions.rest(from, i);
                    foreach (var m_r in select(r, n - 1))
                        yield return new mask_rest() { mask = MyCollections.AddArray(from[i], m_r.mask), rest = m_r.rest };
                }
        }

        public static mask_rest[] masks(long len, long n)
        {
            long[] ini = new long[len];
            for (int i = 0; i < len; i++)
                ini[i] = i;
            var res = select(ini, n).ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                long[] temp = new long[res[i].rest.Length + 1];
                Array.ConstrainedCopy(res[i].rest, 0, temp, 0, res[i].rest.Length);
                temp[res[i].rest.Length] = len;
                res[i].rest = temp;
            }
            return res;
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
            // foreach (var m_r in select(new long[] { 1, 2, 3, 4 }, 3))
            //     Console.WriteLine($"mask:{MyCollections.Print(m_r.mask)}\trest:{MyCollections.Print(m_r.rest)}");
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
                    var m_r_s = masks(num_len - 1, mask_len);
                    for (int i = 0; i < m_r_s.Length; i++)
                    {
                        //                        Console.WriteLine($"trying mask: {MyCollections.Print(m_r_s[i].mask)}");
                        Dictionary<long, long> count = new();
                        foreach (var rr in r)
                            if (digits_suits_mask(rr, m_r_s[i].mask) && rr[0] != 0)
                            {
                                long num = num_from_digits_mask(rr, m_r_s[i].rest);
                                if (count.ContainsKey(num))
                                    count[num]++;
                                else
                                    count.Add(num, 1);
                                //                                Console.WriteLine($"{MyCollections.Print(rr)} suits this mask.\tRest mask is {MyCollections.Print(m_r_s[i].rest)}\trest is {num}.\tIt's count is {count[num]}");
                                if (count[num] >= 8)
                                {
                                    Console.WriteLine(Digits.int_from_digits(rr));
                                    Console.WriteLine($"{MyCollections.Print(rr)} suits this mask.\tRest mask is {MyCollections.Print(m_r_s[i].rest)}\trest is {num}.\tIt's count is {count[num]}");
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