using System;
using System.Collections.Generic;
namespace euler_from26
{
    public static class Task32
    {
        public static void main()
        {
            List<int>pans = new List<int>();
            for (int m1 = 2; m1 <= 9; m1++)
                for (int m2 = 1000; m2 <= 9999; m2++)
                {
                    int product = m1 * m2;
                    if (Digits.isPandigital(9, m1, m2, product) && !pans.Contains(product))
                        pans.Add(product);
                }
            for (int m1 = 10; m1 <= 99; m1++)
                for (int m2 = 100; m2 <= 999; m2++)
                {
                    int product = m1 * m2;
                    if (Digits.isPandigital(9, m1, m2, product) && !pans.Contains(product))
                        pans.Add(product);
                }
            int sum = 0;
            foreach(var p in pans)
                sum += p;
            Console.WriteLine(sum);
        }
    }
}