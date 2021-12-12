using System.IO;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Functions
    {

        public static void swap(ref long a, ref long b)
        {
            long tmp = a;
            a = b;
            b = tmp;
        }

        public static IEnumerable<long[]> Permute(long[] ints, long fix)
        {
            if (fix == ints.Length - 1)
                yield return ints;
            else
                for (long f = fix; f < ints.Length; f++)
                {
                    swap(ref ints[fix], ref ints[f]);
                    foreach(var p in Permute(ints, fix + 1))
                        yield return p;
                    swap(ref ints[fix], ref ints[f]);
                }
        }

        public static List<long> ToList(long[] array)
        {
            List<long> lst = new();
            foreach(var l in array)
                lst.Add(l);
            return lst;
        }

        public static int WordValue(string name)
        {
            int w = 0;
            for (int i=0; i<name.Length; i++)
            {
                int l = name[i] - 'A' + 1;
                w += l;
            }
            return w;
        }
        public static string[] LoadWords(string filename)
        {
            StreamReader SR = new StreamReader(filename);
            var text = SR.ReadLine();
            SR.Close();
            var names = text.Split(',');
            string[] name = new string[names.Length];
            for(int i = 0; i < names.Length; i++)
                name[i] = names[i].Trim('\"');
            return name;
        }
        public static long Factorial(long n)
        {
            long res = 1;
            for (long i=1; i<= n; i++)
                res *= i;
            return res;
        }
    }
}