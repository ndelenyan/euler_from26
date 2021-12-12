using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task42
    {

        public static int tri(int i) => i * (i + 1) / 2;

        public static int[] tris(int max)
        {
            int i = 1;
            int tr = 0;
            List<int> list = new List<int>();
            do
            {
                tr = tri(i++);
                list.Add(tr);
            } while(tr <= max);
            return list.ToArray();
        }

        public static int[] all_tri;

        public static void main()
        {
            var words = Functions.LoadWords("p042_words.txt");
            int max = 192;
            all_tri = tris(max);
            int count = 0;
            foreach(var word in words)
            {
                int wv = Functions.WordValue(word);
                if (Array.IndexOf(all_tri, wv) >= 0)
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}