using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task061
    {
        public static long p(long i, long n)
        {
            switch(i)
            {
                case 0: return n * (n + 1) / 2;
                case 1: return n * n;
                case 2: return n * (3 * n - 1) / 2;
                case 3: return n * (2 * n - 1);
                case 4: return n * (5 * n - 3) / 2;
                case 5: return n * (3 * n - 2);
                default: return -1;
            }
        }

        public static long[][] P = new long[6][];

        public static void fill_4_digits()
        {
            for(long i = 0; i < 6; i++)
            {
                // Console.WriteLine(i);
                long n = 1;
                long len = 0;
                List<long> l = new();
                while(len <= 4)
                {
                    long c = p(i, n);
                    len = Digits.digit_len(c);
                    if (len == 4)
                        l.Add(c);
                    n++;
                }
                P[i] = l.ToArray();
            }
        }

        public static bool check_last_first(long a, long b)
        {
            var digits_a = Digits.digitsAsArray(a);
            var digits_b = Digits.digitsAsArray(b);
            var last_a = Digits.int_from_digits(new long[]{digits_a[2], digits_a[3]});
            var first_b = Digits.int_from_digits(new long[]{digits_b[0], digits_b[1]});
            return last_a == first_b;
        }

        public static List<long[]> chains(List<long[]>start, long i)
        {
            List<long[]>res = new();
            if (i==0)
            {
                foreach(var c in P[i])
                    res.Add(new long[]{c});
            }
            else
            {
                // Console.WriteLine(MyCollections.Print(P[i]));
                foreach(var link in start)
                {
                    foreach(var c in P[i])
                    {
                        if (check_last_first(link[link.Length-1], c))
                            res.Add(MyCollections.AddArrays(link, new long[]{c}));
                    }
                }
            }
            return res;
        }

        public static void main ()
        {
            Console.WriteLine("Task061");
            fill_4_digits();
            foreach(var c in P)
                Console.WriteLine(c.Length);

            foreach(var p in Functions.Permute(new long[]{0, 1, 2, 3, 4, 5}))
            {
                List<long[]> chain = new();
                for(long i = 0; i < 6; i++)
                {
                    // Console.WriteLine(i);
                    var c = chains(chain, p[i]);
                    chain = c;
                }
                foreach(var c in chain)
                    if (check_last_first(c[5], c[0])) 
                            Console.WriteLine(Functions.sum(c));
            }
        }
    }
}
