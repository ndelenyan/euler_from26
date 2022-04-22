using System;

namespace euler_from26
{
    public static class Task122
    {

        public static bool incr(long[] digits)
        {
            if (digits.Length == 1)
                return true;
            for (int i = 0; i < digits.Length - 1; i++)
                if (digits[i] > digits[i+1])
                    return false;
            return true;
        }

        public static bool decr(long[] digits)
        {
            if (digits.Length == 1)
                return true;
            for (int i = 0; i < digits.Length - 1; i++)
                if (digits[i] < digits[i + 1])
                    return false;
            return true;
        }

        public static bool bouncy(long[] digits) => !incr(digits) && !decr(digits);

        public static void main()
        {
            long b = 0;
            long t = 0;
            long f = 0;
            do
            {
                t++;
                var d = Digits.digitsAsArray(t);
                if (bouncy(d))
                    b++;
                f = 100 * b / t;
            } while (f < 99);
            Console.WriteLine(t);
        }
    }
}