using System;

namespace euler_from26
{
    public static class Task788
    {

        /*

            n digits
            1) n is even. there must be n/2 + 1 equal digits. first digit cannot be 0
            ! 9 ways to occupy first digit
            n - 1 digits remaining
            a) equal is this digit
            - n/2 these digits, n/2 - 1 any digits
            - C(n - 1, n/2) ways to occupy these equal digits
            - 10 ^ (n/2 - 1)
            total = 9 * C(n-1, n/2) * 10^(n/2-1)
            b) equal is a different digit
            - n/2 + 1 equal digits, n/2 - 2 any digits
            - C(n - 1, n/2 + 1) ways to place equal digits, 9 digits
            - 10 ^ (n/2 - 2) other digits
            total = 9 * 9 * C(n-1, n/2 + 1) * 10^(n/2-2) = 9 * 9 * C(n-1, n/2 + 1) * 10^(n/2-2)
            TOTAL =  9 * C(n-1, n/2) * 10^(n/2-1) + 
                    9 * 9 * C(n-1, n/2 + 1) * 10^(n/2-2) = 
            = 9 * 10^(n/2 - 2) * [10 * C(n-1, n/2) + 9 * C(n-1, n/2 + 1)] = 
            = 9 * 10^(n/2 - 2) * C(n-1, n/2) * [10 + 9 * (n/2 - 1) / (n/2 + 1)] = 
            = 9 * 10^(n/2 - 2) * C(n-1, n/2) * [10 * (n/2 + 1) + 9 * (n/2 - 1)] / (n/2 + 1)
            = 9 * 10^(n/2 - 2) * C(n-1, n/2) * (19 * n/2 + 1) / (n/2 + 1)
        */
        public static long cc(long n)
        {
            if (n % 2 == 0)
            {
                long k = n / 2;
                long a = (long)Math.Pow(10, k - 2);
                a *= 9;
                var c = (long)Functions.C(n - 1, k);
                a *= c;
                a *= 19 * k + 1;
                a /= k + 1;
                return (long)a;
            }
            else
                return 0;
        }

        public static void main()
        {
            long count = 0;
            long max = 7;
            long i = 0;
            long len = 1;
            long[] sum = new long[10];
            while (++i < Math.Pow(10, max))
            {
                bool isd = Numbers.IsDominating(i);
                if (isd)
                    count++;
                if (i == (long)Math.Pow(10, len) - 1)
                {
                    sum[len] = count;
                    count = 0;
                    len++;
                }
                //                Console.WriteLine($"{i}: {(isd ? '*' : ' ')}\tcount:{count}");
            }
            Console.WriteLine(MyCollections.Print(sum));
            Console.Write("{ ");
            for (int j = 0; j < 10; j++)
                Console.Write($"{cc(j)} ");
            Console.WriteLine(" }");
        }
    }
}