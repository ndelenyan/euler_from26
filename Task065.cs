using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task065
    {

        public static IEnumerable<long[]> fabric(long[] gens)
        {
            for (int i = 0; i < gens.Length; i++)
            {
                long[] r = new long[i + 1];
                Array.ConstrainedCopy(gens, 0, r, 0, i + 1);
                yield return r;
            }
        }

        public static Fraction convergent(long start, long[] gens)
        {
            Fraction F = new Fraction();
            Fraction R = new Fraction() { nominator = start, denominator = 1};
            Array.Reverse(gens);
            foreach(var gen in gens)
            {
                if (R == 1)
                {
                    R.nominator = gen;
                    R.denominator = 1;
                }
                else
                {
                    R = gen + R.inverse();
                }
                Console.WriteLine(R);
            }
            return start + R;
        }
        public static void main ()
        {
            // var a = new long[]{1, 2, 3, 4, 5, 6, 7, 8, 9};
            var a = new long[]{2, 2};
            // foreach(var b in fabric(a))
            //     Console.WriteLine(MyCollections.Print(b));
            var b = convergent(1, a);
            Console.WriteLine(b);
            // foreach(var c in b)
            //     Console.WriteLine(c);
        }
    }
}