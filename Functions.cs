using System.IO;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Functions
    {

        public static void swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public static IEnumerable<int[]> Permute(int[] ints, int fix)
        {
            if (fix == ints.Length - 1)
                yield return ints;
            else
                for (int f = fix; f < ints.Length; f++)
                {
                    swap(ref ints[fix], ref ints[f]);
                    foreach(var p in Permute(ints, fix + 1))
                        yield return p;
                    swap(ref ints[fix], ref ints[f]);
                }
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
        public static int Factorial(int n)
        {
            int res = 1;
            for (int i=1; i<= n; i++)
                res *= i;
            return res;
        }
    }
}