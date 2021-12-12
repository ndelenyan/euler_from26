using System;

namespace euler_from26
{
    public static class Task43
    {

        public static long d(int[] ints, params int[] i)
        {
            int[] z = new int[i.Length];
            for (int j = 0; j < i.Length; j++)
                z[i.Length - j - 1] = ints[i[j]];
            return Digits.int_from_digits(z);
        }

        public static void main()
        {
            // foreach (var p in Functions.Permute(new int[]{0, 1, 2}, 0))
            //     Console.WriteLine($"{MyCollections.Print(p)}\t{Digits.int_from_digits(p, true)}");
            long sum = 0;
            foreach(var p in Functions.Permute(new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, 0))
            {
                var d234 = d(p, new int[]{1, 2, 3});
                var d345 = d(p, new int[]{2, 3, 4});
                var d456 = d(p, new int[]{3, 4, 5});
                var d567 = d(p, new int[]{4, 5, 6});
                var d678 = d(p, new int[]{5, 6, 7});
                var d789 = d(p, new int[]{6, 7, 8});
                var d8910 = d(p, new int[]{7, 8, 9});
                if (    Prime.isDivisible(d234, 2)
                    && Prime.isDivisible(d345, 3)
                    && Prime.isDivisible(d456, 5)
                    && Prime.isDivisible(d567, 7)
                    && Prime.isDivisible(d678, 11)
                    && Prime.isDivisible(d789, 13)
                    && Prime.isDivisible(d8910, 17))
                    sum += Digits.int_from_digits(p, true);
//                Console.WriteLine($"{Digits.int_from_digits(p, true)}: {d234} {d345} {d456} {d567} {d678} {d789} {d8910}");
//                Console.ReadLine();
            }
            Console.WriteLine(sum);
        }
    }
}