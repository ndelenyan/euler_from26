using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task061
    {

        public static long P(long i, long n)
        {
            switch(i)
            {
                case 3: return n * (n + 1) / 2;
                case 4: return n * n;
                case 5: return n * (3 * n - 1) / 2;
                case 6: return n * (2 * n - 1);
                case 7: return n * (5 * n - 3) / 2;
                case 8: return n * (3 * n - 2);
                default: return 0;
            }

        }

        public static long[][]p = new long[9][];

        public static IEnumerable<long[]>addCycle(long n) // n [3..8]
        {
            if (n == 8)
                foreach(var x in p[n])
                    yield return new long[] {x};
            else
                foreach(var x in p[n])
                    foreach(var y in addCycle(n + 1))
                    {
                        var x_digits = Digits.digitsAsArray(x);
                        var y_digits = Digits.digitsAsArray(y[0]);
                        var x_last = Digits.int_from_digits(new long[]{x_digits[2], x_digits[3]});
                        var y_first = Digits.int_from_digits(new long[]{y_digits[0], x_digits[1]});
                        if (x_last == y_first)
                            if (n != 3)
                                yield return MyCollections.AddArray(x, y);
                            else
                            {
                                var last_digits = Digits.digitsAsArray(y[4]);
                                var x_first = Digits.int_from_digits(new long[]{x_digits[0], x_digits[1]});
                                var last_last = Digits.int_from_digits(new long[]{last_digits[2], last_digits[3]});
                                if (x_first == last_last)
                                    yield return MyCollections.AddArray(x, y);
                            }
                    }
        }

        public static void main ()
        {
            Console.WriteLine("Task061");
            long min = 1_000;
            long max = 9_999;
            for(long i = 3; i <= 8; i++)
            {
                List<long> d = new ();
                long n = 1;
                long z = P(i, n);
                do
                {
                    n++;
                    if (min <= z && z <= max)
                        d.Add(z);
                    z = P(i, n);
                } while (z <= max);
                Console.WriteLine($"{i}:\t{d.Count}");
                p[i] = d.ToArray();
            }
            foreach(var d in addCycle(7))
                Console.WriteLine(MyCollections.Print(d));
        }
    }
}
