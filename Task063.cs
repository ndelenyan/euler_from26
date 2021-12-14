using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task063
    {
        public static void main()
        {
            int pow = 0;
            int len = 0;
            int count = 0;
            do
            {
                pow++;
                BigInteger candidate = 0;
                for (int ba = 1; ba < 10; ba++)
                {
                    candidate = BigInteger.Pow(ba, pow);
                    len = Digits.digit_len(candidate);
                    if (len == pow)
                        count++;
                }
            } while (len >= pow);
            Console.WriteLine(count);
        }
    }
}