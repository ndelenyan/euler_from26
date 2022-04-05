using System;
using System.Numerics;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task206
    {
        public static void main()
        {
            Console.WriteLine(Math.Sqrt(1929374254627488900));
//            return;
            long[] digits = { 0, 0, 9, 0, 8, 0, 7, 0, 6, 0, 5, 0, 4, 0, 3, 0, 2, 0, 1 };
            for (digits[3] = 0; digits[3] < 10; digits[3]++)
                for (digits[5] = 0; digits[5] < 10; digits[5]++)
                {
                    Console.WriteLine($"{digits[3]}-{digits[5]}");
                    for (digits[7] = 0; digits[7] < 10; digits[7]++)
                        for (digits[9] = 0; digits[9] < 10; digits[9]++)
                            for (digits[11] = 0; digits[11] < 10; digits[11]++)
                                for (digits[13] = 0; digits[13] < 10; digits[13]++)
                                    for (digits[15] = 0; digits[15] < 10; digits[15]++)
                                        for (digits[17] = 0; digits[17] < 10; digits[17]++)
                                        {
                                            long n = (long)Digits.int_from_digits(digits);
                                            long s = (long)Math.Sqrt(n);
                                            if (s * s == n)
                                                Console.WriteLine(n);
                                        }
                }
        }
    }
}