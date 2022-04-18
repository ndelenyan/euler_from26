using System;

namespace euler_from26
{
    public static class Task686
    {

        public static double log102 = Math.Log10(2.0);

        public static bool IsFirstDigits(long what, long len, long pow)
        {
            double nlog102 = pow * log102;
            double mid = nlog102 - Math.Floor(nlog102) + len - 1;
            return (Math.Log10(what) <= mid) && (mid <= Math.Log10(what+1));
        }

        public static long p(long L, long len, long n)
        {
            long count = 0;
            long pow = 0;
            do
            {
                pow++;
                if (IsFirstDigits(L, len, pow))
                    count++;
            } while (count < n);
            return pow;
        }

        public static void main()
        {
            var a = p(123, 3, 678910);
            System.Console.WriteLine(a);
        }
    }
}