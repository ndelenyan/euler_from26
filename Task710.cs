using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

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

        public static List<long[]> twopals;

        public static void addPair(long[] arr, long n, long iStart)
        {
            if (n<0)
                return;
            if (n==0)
                twopals.Add((long[])arr.Clone());
            else
                for (long i = iStart; i <= n; i++)
                    for (long m = 2; m <= n; m += 2)
                        if ((n - m * i) % 2 == 0)
                        {
                            arr[i] += m;
                            addPair(arr, n - m * i, i + 1);
                            arr[i] -= m;
                        }
        }

        public static void init(long n)
        {
            long[] arr = new long[n + 1];
            if (n % 2 == 0)
            {
                arr[2] = 1;
                addPair(arr, n - 2, 1);
                arr[2] = 0;
            }
            arr[2] = 2;
            addPair(arr, n - 4, 1);
            if (n % 2 == 1)
            {
                for (long i = 1; i <= n - 4; i += 2)
                    if (n - 4 - i >= 0)
                    {
                        arr[i] = 1;
                        addPair(arr, n - 4 - i, 1);
                        arr[i] = 0;
                    }
            }
            arr[2] = 0;
        }

        public static long count2pals(long[] two)
        {
            BigInteger top = 0;
            BigInteger bottom = 1;
            foreach(var t in two)
                if (t == 0)
                    continue;
                else if (t % 2 == 0)
                {
                    top += t / 2;
                    bottom *= Functions.Factorial(t / 2);
                }
                else
                {
                    top += (t - 1 ) / 2;
                    bottom *= Functions.Factorial((t - 1) / 2);
                }
            return (long)(Functions.Factorial(top) / bottom);
        }

        public static long countTwoPals(long n)
        {
            long sum = 0;
            twopals = new();
            init(n);
            foreach (var t in twopals)
            {
                var c = count2pals(t);
                System.Console.WriteLine($"{MyCollections.Print(t)} {c}");
                sum += c;
            }
            return sum;
        }

        public static void main()
        {
            System.Console.WriteLine(countTwoPals(10));
            // 1 1 2 2
            // 1 2 1 2
            // 1 2 2 1
            // 2 1 1 2
            // 2 1 2 1
            // 2 2 1 1
        }
    }
}