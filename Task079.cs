using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task079
    {

        public static bool suits(long[] perm, long[]pass)
        {
            int i1 = Array.IndexOf(perm, pass[0]);
            int i2 = Array.IndexOf(perm, pass[1]);
            int i3 = Array.IndexOf(perm, pass[2]);
            return i1 < i2 && i2 < i3;
        }

        public static bool suits(long[] perm, List<long[]>all)
        {
            foreach(var p in all)
                if (!suits(perm, p))
                    return false;
            return true;
        }

        public static void main()
        {
            int[] passes = Functions.LoadNumbers("p079_keylog.txt");
            HashSet<long> pass = new();
            HashSet<long> digits = new();
            foreach (var p in passes)
            {
                pass.Add(p);
                foreach(var d in Digits.digits(p))
                    digits.Add(d);
            }
            List<long[]> distinct_keys_array = new();
            foreach(var ddd in pass)
                distinct_keys_array.Add(Digits.digitsAsArray(ddd));
            long[] digits_array = new long[digits.Count];
            int i = 0;
            foreach(int d in digits)
                digits_array[i++] = d;
            foreach(var p in Functions.Permute(digits_array, 0))
                if (suits(p, distinct_keys_array))
                    Console.WriteLine(MyCollections.Print(p));
            Console.WriteLine("done");
        }
    }
}