using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task055
    {

        public static bool isLychrel(BigInteger n)
        {
            for (int i = 0; i < 50; i++)
            {
                var r = Digits.int_from_digits(Digits.digitsAsArray(n), true);
                n += r;
                if (Digits.isPalindrome(n))
                    return false;
            }
            return true;
        }

        public static void main()
        {
            int count = 0;
            for (BigInteger i = 1; i < 10000; i++)
                if (isLychrel(i))
                {
                    Console.WriteLine($"{++count}:\t{i}");
                }
            Console.WriteLine(count);
        }
    }
}