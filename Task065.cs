using System;
using System.Collections.Generic;
using System.Numerics;

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

        public static long[] gen_e(long n)
        {
            long[] res = new long[n];
            res[0] = 1;
            res[1] = 2;
            long i = 2;
            long count = 0;
            long k = 2;
            while(i < n)
            {
                if (count == 2)
                {
                    res[i] = 2 * k;
                    k++;
                    count = 0;
                }
                else
                {
                    res[i] = 1;
                    count++;
                }
                i++;
            }
            return res;
        }

        public static Fraction convergent(long start, long[] gens)
        {
            Fraction R = new Fraction();
            // Array.Reverse(gens);
            for(int i = gens.Length - 1; i >= 0; i--)
            {
                if (i == gens.Length - 1)
                    R = new Fraction(gens[i], 1);
                else
                    R = gens[i] + R.inverse();
                // Console.WriteLine(R);
            }
            return start + R.inverse();
        }

        public static Fraction[] convergents(long start, long[] gens)
        {
            Fraction[] res = new Fraction[gens.Length + 1];
            res[0] = new Fraction(start, 1);
            long i = 1;
            // foreach(var g in fabric(gens))
            //     Console.WriteLine(MyCollections.Print(g));
            foreach(var g in fabric(gens))
            {
                Console.Write($"{MyCollections.Print(g)}\t");
                var z = convergent(start, g);
                Console.WriteLine($"{z}");
                res[i] = z;
                i++;
            }
            return res;
        }

        public static void main ()
        {

            var e = gen_e(100);
            Console.WriteLine(MyCollections.Print(e));
            var b = convergents(2, e);
            BigInteger nnm2 = 2;
            BigInteger nnm1 = 3;
            BigInteger nn = 0;
            for(int i = 2; i < b.Length - 1; i++)
            {
                nn = nnm2 + nnm1 * e[i-1];
                Console.WriteLine($"{i+1}\t{b[i].nominator}\t{nn}\t{e[i]}");
                nnm2 = nnm1;
                nnm1 = nn;
            }
            Console.WriteLine(Digits.digit_sum(nn));
            // 	
        }
    }
}