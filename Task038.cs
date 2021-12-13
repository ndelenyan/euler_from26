using System.Numerics;
using System;
namespace euler_from26
{
    public static class Task38
    {

        public static int[] concat_product(int n, int[] p)
        {
            int[]products = new int[p.Length];
            for (int i=0; i<p.Length; i++)
                products[i] = n * p[i];
            return products;
        }

        public static void main()
        {
            for (int i=1; i<10000; i++)
                for (int n = 2; n <= 9; n++)
                {
                    int[] nn = new int[n];
                    for(int j=0; j<n; j++)
                        nn[j] = j+1;
                    var product = concat_product(i, nn);
                    if (Digits.isPandigital((BigInteger)9, product))
                        Console.WriteLine(MyCollections.Print(product));
                }
            Console.WriteLine();
        }
    }
}