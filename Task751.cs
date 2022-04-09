using System;
using System.Text;

namespace euler_from26
{
    public static class Task751
    {

        public static string concat(int[] a)
        {
            StringBuilder SB = new();
            SB.Append(a[0]);
            SB.Append('.');
            for (int i = 1; i < a.Length; i++)
                SB.Append(a[i]);
            return SB.ToString();
        }
        
        public static decimal construct(decimal bas, decimal digit, int pos) => bas + (decimal)digit * (decimal)Math.Pow(10, -pos);

        public static int dec(decimal d, int i)
        {
            int b = (int)Math.Floor(d);
            if (i==1)
                return b;
            else
            {
                d -= b;
                i--;
                return (int)Math.Floor(d * (decimal)Math.Pow(10, i)) % 10;
            }
        }

        public static decimal seq (decimal theta, int steps)
        {
            decimal res = 0.0M;
            decimal b = theta;
            for (int i = 0; i < steps; i++)
            {
                b = Math.Floor(b) * (1.0M + b - Math.Floor(b));
                res = construct(res, Math.Floor(b), i);
            }
            return res;
        }

        public static void main()
        {
            System.Console.WriteLine(seq(2.956938891377988M, 10));
        }
    }
}