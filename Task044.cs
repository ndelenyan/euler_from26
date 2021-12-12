using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task44
    {

        public static long penta(long n) => n * (3 * n - 1) / 2;

        public static long[] pentas(long max)
        {
            List<long>penta_list = new();
            long i= 0;
            long p = 0;
            while(p < max)
            {
                p = penta (++i);
                penta_list.Add(p);
            }
            return penta_list.ToArray();
        }

        public static bool isSuper(long p1, long p2) => (Array.IndexOf(penti, p2-p1) >= 0) && (Array.IndexOf(penti, p2+p1) >= 0);

        public static long max = 10000000;

        public static long[] penti = pentas(max);

        public static void main()
        {
            long d_min = max;
            // int i_min = -1;
            // int j_min = -1;
            for (int i = 0; i < penti.Length - 1; i++)
                for (int j = i + 1; j < penti.Length; j++)
                    if (isSuper(penti[i], penti[j]))
                        if (penti[j] - penti[i] < d_min)
                        {
                            d_min = penti[j] - penti[i];
                        }
            Console.WriteLine($"{d_min}");
        }
    }
}