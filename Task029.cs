using System;
using System.Collections.Generic;
using System.Numerics;

namespace euler_from26
{
    public static class Task29
    {

        public static IEnumerable<BigInteger>powers(int a, int b)
        {
            for(int i = 2; i <= a; i++)
                for (int j = 2; j <= b; j++)
                    yield return BigInteger.Pow(i, j);
        }

        public static int unique_powers(int a, int b)
        {
            List<BigInteger>pow = new List<BigInteger>();
            foreach(var p in powers(a, b))
                if(!pow.Contains(p))
                    pow.Add(p);
            return pow.Count;
        }

        public static void main()
        {
            Console.WriteLine(unique_powers(100, 100));
        }
    }
}