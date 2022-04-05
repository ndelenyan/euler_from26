using System;
using System.Linq;

namespace euler_from26
{
    public static class Task719
    {

        public static long T(long n)
        {
            long sum = 0;
            long max = (long)Math.Sqrt(n);
            for (long i = 1; i <= max; i++)
            {
                if (i % 1000 == 0)
                    Console.WriteLine($"{i} / {max}");
                long sq = i * i;
                if (Numbers.IsSNumber(sq))
                    sum += sq;
            }
            return sum;
        }

        public static void main()
        {
            Console.WriteLine(T(1000000000000));
        }
    }
}