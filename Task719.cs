using System;
using System.Numerics;
using System.Threading.Tasks;

namespace euler_from26
{
    public static class Task719
    {

        public static BigInteger T(long n)
        {
            BigInteger sum = 0;
            long max = (long)Math.Sqrt(n);
            int count = 1;
            Parallel.For(1, max + 1, i =>
//                for (long i = 1; i <= max; i++)
                {
                    if (count++ % 1000 == 0)
                        Console.WriteLine($"{count} / {max}");
                    long sq = i * i;
                    if (Numbers.IsSNumber(i, sq))
                    {
                        sum += sq;
                        System.Console.WriteLine($"{i} {sq} {sum}");
                    }
            });
            return sum;
        }

        public static void main()
        {
            Console.WriteLine(T((long)Math.Pow(10, 4)));
//            Console.WriteLine(T(1_000_000_000_000));
            // 128088830547983
            // 128088830547982
        }
    }
}