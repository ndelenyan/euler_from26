using System;

namespace euler_from26
{
    public static class Task145
    {

        public static bool reversible(long n)
        {
            if (n % 10 == 0)
                return false;
            var d = Digits.digitsAsList(n);
            long r = (long)Digits.int_from_digits(d, false);
            long s = n + r;
            foreach(var dd in Digits.digits(s))
                if (dd % 2 == 0)
                    return false;
            return true;
        }

        public static void main ()
        {
            Console.WriteLine("Task145");
            long count = 0;
            for (long n = 1; n <= 1_000_000_000; n++)
            {
                if (n % 1_000_000 == 0)
                    Console.WriteLine(n);
                if (reversible(n))
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}
