using System;
using System.Collections.Generic;
using System.Linq;

namespace euler_from26
{
    public static class Numbers
    {

        public static bool isTriangular(long n)
        {
            long D = 8 * n + 1;
            long d = (long)Math.Sqrt(D);
            if (d * d != D)
                return false;
            if ((d - 1) % 2 != 0)
                return false;
            return true;
        }

        public static bool isPentagonal(long n)
        {
            long D = 24 * n + 1;
            long d = (long)Math.Sqrt(D);
            if (d * d != D)
                return false;
            if ((d + 1) % 6 != 0)
                return false;
            return true;
        }

        public static IEnumerable<long> Hexagonal(long max)
        {
            long i=0;
            long H = 0;
            do
            {
                H = i * (2 * i - 1);
                i++;
                yield return H;
            } while (H <= max);
        }

        public static bool IsSNumber(long root, long s)
        {
//            long root = (long)Math.Sqrt(s);
//            if (root * root != s)
//                return false;
            foreach(var spl in Functions.Splitter(Digits.digitsAsArray(s)))
                if (root == Functions.sum(spl))
                    return true;
            return false;
        }

        public static long[] count_digits(IEnumerable<long>digits)
        {
            long[] res = new long[10];
            foreach (var d in digits)
                res[d]++;
            return res;
        }
        public static bool IsDominating(long n)
        {
            var digits = Digits.digitsAsArray(n);
            var counts = count_digits(digits);
            long len = digits.Length / 2;
            foreach(var c in counts)
                if (c > len)
                    return true;
            return false;
        }

    }
}