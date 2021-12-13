using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task36
    {
        public static void main()
        {
            long sum = 0;
            for (int i = 1; i < 1000000; i++)
            {
                var digits10 = Digits.digitsAsArray(i, 10);
                var digits2 = Digits.digitsAsArray(i, 2);
                if (Digits.isPalindrome(digits10) && Digits.isPalindrome(digits2))
                    sum += i;
            }
            Console.WriteLine(sum);
            Console.WriteLine(MyCollections.Print(Digits.digitsAsArray(128, 2)));
        }
    }
}