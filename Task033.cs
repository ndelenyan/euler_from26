using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task33
    {
        public static void main()
        {
            for(long numerator = 10; numerator < 99; numerator++)
                for (long denominator = numerator + 1; denominator < 100; denominator++)
                {
                    var n_d = Digits.digits_list(numerator);
                    var d_d = Digits.digits_list(denominator);
                    if (d_d[0] == 0 && n_d[0] == 0)
                        continue;
                    if (Digits.Reduce_Digits(n_d, d_d, 1))
                        if ((double)numerator/(double)denominator == (double) n_d[0]/ (double)d_d[0])
                            Console.WriteLine($"{numerator}/{denominator} = {MyCollections.Print(n_d)} / {MyCollections.Print(d_d)}");
                }
        }
    }
}