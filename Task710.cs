using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace euler_from26
{
    public static class Task710
    {

        public static string str(Dictionary<long, int> d)
        {
            StringBuilder SB = new();
//            SB.Append("");
            foreach(var a in d)
                SB.Append($"{a.Key}:{a.Value} ");
            return SB.ToString();
        }

        public static Dictionary<long, long> process(long[] s)
        {
            Dictionary<long, long> res = new();
            foreach(long v in s)
                if(!res.ContainsKey(v))
                    res.Add(v, 1);
                else
                    res[v]++;
            return res;
        }

        public static long[] append(long a, long[] rest)
        {
            long[] res = new long[rest.Length + 1];
            res[0] = a;
            Array.ConstrainedCopy(rest, 0, res, 1, rest.Length);
            return res;
        }

        public static IEnumerable<long[]>sums(long n)
        {
            if (n == 0)
                yield break;
            else if (n==1)
                yield return new long[1] { 1 };
            else
                for (long i = 1; i <= n; i++)
                    foreach(var rest in sums(n - i))
                        yield return append(i, rest);
        }

        public static void main()
        {
            foreach (var a in sums(6))
            {
                var s = a.GroupBy(p => p).OrderByDescending(r => -r.Key).ToDictionary(q => q.Key, q => q.Count());
                System.Console.WriteLine($"{MyCollections.Print(a)} {str(s)}");
            }
            //            System.Console.WriteLine(710);
        }
    }
}