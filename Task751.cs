using System;
using System.Text;

namespace euler_from26
{
    public static class Task751
    {

        public struct dec
        {
            public decimal value;
            public int lastPos;
        }

    public static string concat(int[] a)
        {
            StringBuilder SB = new();
            SB.Append(a[0]);
            SB.Append('.');
            for (int i = 1; i < a.Length; i++)
                SB.Append(a[i]);
            return SB.ToString();
        }
        
        public static dec construct(dec source, decimal from)
        {
            dec res = new();
            long addon = (long)Math.Floor(from);
            int p = Digits.digit_len(addon);
            res.lastPos = source.lastPos + p;
            res.value = source.value + (decimal)addon * (decimal)Math.Pow(10, -res.lastPos);
            return res;
        }// => bas + ;

        public static dec seq (decimal theta, long steps)
        {
            dec res = new(){value = Math.Floor(theta), lastPos = 0};
            decimal b = theta;
            for (int i = 0; i < steps; i++)
            {
                b = Math.Floor(b) * (1.0M + b - Math.Floor(b));
                res = construct(res, b);
//                System.Console.WriteLine($"{b} {res.value}");
            }
            return res;
        }

        public static bool equal(decimal d1, decimal d2, long lastPos)
        {
            return Math.Abs(d1 - d2) <= (decimal)Math.Pow(10, -lastPos);
        }

        public static void proceed(dec candidate, long steps)
        {
            if (steps > 26)
            {
                System.Console.WriteLine(candidate.value);
                Console.ReadLine();
            }
            for (long d = 0; d <= 9; d++)
            {
                var c = construct(candidate, d);
                var check = seq(c.value, steps);
                //                Console.ReadLine();
                //if (Decimal.Equals(c.value, check.value))
//                System.Console.WriteLine($"steps:{steps} {d}: {c.value} ={Math.Abs(c.value - check.value)}, {Math.Pow(10, -(c.lastPos + 1))}= {check.value}, c.lastPos: {c.lastPos} check.lastPos: {check.lastPos}");
                if (equal(c.value, check.value, c.lastPos))
                {
                    proceed(check, steps + 1);
                }
            }
        }

        public static void main()
        {
            dec res = new() { value = 2.0M, lastPos = 0 };
            proceed(res, 1);
        }
    }
}