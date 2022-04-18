using System;
using System.IO;

namespace euler_from26
{
    public static class Task099
    {
        public static void main()
        {
            int i = 0;
            int max = 0;
            double maxV = 0.0;

            using (StreamReader sr = new StreamReader("p099_base_exp.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    i++;
                    string[] a = line.Split(',');
                    double b = Double.Parse(a[0]);
                    double e = Double.Parse(a[1]);
                    double thisV = e * Math.Log(b);
                    if (thisV > maxV)
                    {
                        maxV = thisV;
                        max = i;
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}