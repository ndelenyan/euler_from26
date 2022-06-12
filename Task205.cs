using System;
using System.Collections.Generic;

namespace euler_from26
{

    public static class DictionaryExtension
    {
        public static void AddValue(this Dictionary<long, long> dict, long key, long value)
        {
            if (dict.ContainsKey(key))
                dict[key] += value;
            else
                dict[key] = value;
        }
        public static void AddOne(this Dictionary<long, long> dict, long key) => AddValue(dict, key, 1);
    }

    public static class Task205
    {

        public static Dictionary<long, long>count(long dice, long n)
        {
            if (n == 1)
            {
                Dictionary<long, long> res = new();
                for(long i = 1; i <= dice; i++)
                    res.AddOne(i);
                return res;
            }
            else
            {
                Dictionary<long, long> res = new();
                var nm1 = count(dice, n-1);
                for(long i = 1; i <= dice; i++)
                    foreach(var t in nm1)
                        res.AddValue(i + t.Key, t.Value);
                return res;
            }
        }

        public static Dictionary<long, double> tr(Dictionary<long, long> dice)
        {
            long sum = 0;
            foreach(var d in dice)
                sum += d.Value;
            Dictionary<long, double> res = new();
            foreach(var d in dice)
                res[d.Key] = (double)d.Value / (double)sum;
            return res;
        }

        public static void main ()
        {
            // var r = count(6, 2);
            // foreach(var rr in r)
            //     Console.WriteLine(rr);
            // var z = tr(r);
            // foreach(var zz in z)
            //     Console.WriteLine(zz);
            var Pete = tr(count(4, 9));
            var Colin = tr(count(6, 6));
            double prob = 0.0;
            // Console.WriteLine("Pete:");
            // foreach(var p in Pete)
            //     Console.WriteLine(p);
            // Console.WriteLine("Colin:");
            // foreach(var c in Colin)
            //     Console.WriteLine(c);
            foreach(var p in Pete)
                foreach(var c in Colin)
                    if (p.Key > c.Key)
                        prob += p.Value * c.Value;
            Console.WriteLine(prob);
        }
    }
}
