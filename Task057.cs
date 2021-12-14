using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task057
    {
        public static int num = 1000;
        public static BigInteger[] n = new BigInteger[num];
        public static BigInteger[] d = new BigInteger[num];

        public static void calc_dn()
        {
            n[0] = 3;
            d[0] = 2;
            for (int i = 1; i < num; i++)
            {
                var rn = n[i - 1] - d[i - 1];
                n[i] = d[i - 1];
                d[i] = 2 * d[i - 1] + rn;
                n[i] += d[i];
            }
        }
        public static void main()
        {
            calc_dn();
            int count = 0;
            for (int i = 0; i < num; i++)
                if (Digits.digit_len(n[i]) > Digits.digit_len(d[i]))
                    count++;
            Console.WriteLine(count);
        }
    }
}