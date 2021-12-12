using System.Collections.Generic;
using System;
namespace euler_from26
{
    public static class Task38
    {

        public static long[] concat_product(long n, long[] p)
        {
            long[]products = new long[p.Length];
            for (int i=0; i<p.Length; i++)
                products[i] = n * p[i];
            return products;
        }

        public static void main()
        {
            for (int i=1; i<10000; i++)
                for (int n = 2; n <= 9; n++)
                {
                    long[] nn = new long[n];
                    for(int j=0; j<n; j++)
                        nn[j] = j+1;
                    var product = concat_product(i, nn);
                    if (Digits.isPandigital(9, product))
                        Console.WriteLine(MyCollections.Print(product));
                }
            Console.WriteLine();
        }
    }
}