using System;
using System.Collections.Generic;
using System.Text;

namespace euler_from26
{
    public static class MyCollections
    {

        public static long[] toArray(IEnumerable<long>e)
        {
            int l = 0;
            foreach(var _ in e)
                l++;
            long[] res = new long[l];
            l = 0;
            foreach(var a in e)
                res[l++] = a;
            return res;
        }

        public static long[] AddArray(long l, long[] a)
        {
            long[] res = new long[a.Length + 1];
            res[0] = l;
            Array.ConstrainedCopy(a, 0, res, 1, a.Length);
            return res;
        }

        public static long[] AddArrays(long[] a1, long[] a2)
        {
            long[] res = new long[a1.Length + a2.Length];
            Array.ConstrainedCopy(a1, 0, res, 0, a1.Length);
            Array.ConstrainedCopy(a2, 0, res, a1.Length, a2.Length);
            return res;
        }

        public static string Print(IEnumerable<long> t)
        {
            var SB = new StringBuilder();
            SB.Append("{");
            foreach (var tt in t)
                SB.Append($" {tt}");
            SB.Append(" }");
            return SB.ToString();
        }
    }
}