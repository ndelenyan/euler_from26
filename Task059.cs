using System;
using System.IO;

namespace euler_from26
{
    public static class Task059
    {

        public static char[] applyPass(char[] chars, char[] pass)
        {
            char[] res = new char[chars.Length];
            for (int i = 0; i < chars.Length; i++)
                res[i] = (char)(chars[i] ^ pass[i % pass.Length]);
            return res;
        }

        public static (char min, char max) min_max(char[] test)
        {
            char min = (char)255;
            char max = (char)0;
            foreach(char t in test)
            {
                if (t > max)
                    max = t;
                if (t < min)
                    min = t;
            }
            return (min, max);
        }

        public static void main()
        {
            StreamReader SR = new StreamReader("p059_cipher.txt");
            string line = SR.ReadLine();
            SR.Close();
            var codes = line.Split(',');
            Console.WriteLine(codes.Length);
            char[] chars = new char[codes.Length];
            for (int i = 0; i < codes.Length; i++)
            {
                chars[i] = (char)int.Parse(codes[i]);
                //Console.Write($"{chars[i]} ");
            }
            char[] pass = new char[3];
            for (pass[0] = 'a'; pass[0] <= 'z'; pass[0]++)
                for (pass[1] = 'a'; pass[1] <= 'z'; pass[1]++)
                    for (pass[2] = 'a'; pass[2] <= 'z'; pass[2]++)
                    {
                        var candidate = applyPass(chars, pass);
                        (char min, char max) = min_max(candidate);
                        if (min >= (char)32 && max <= 'z')
                        {
                            long sum = 0;
                            foreach(var c in candidate)
                                sum += c;
                            Console.WriteLine($"{String.Join("", candidate)}\t{sum}");
                        }
                    }
        }
    }
}