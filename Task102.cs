using System;
using System.IO;

namespace euler_from26
{
    public static class Task102
    {
        public static void main ()
        {
            Console.WriteLine("Task102");
            var SR = new StreamReader("p102_triangles.txt");
            int count = 0;
            while(SR.Peek() >= 0)
            {
                string line = SR.ReadLine();
                // Console.WriteLine(line);
                var a = line.Split(',');
                foreach(var aa in a)
                    Console.Write($"{aa} ");
                double xa = Double.Parse(a[0]);
                double ya = Double.Parse(a[1]);
                double xb = Double.Parse(a[2]);
                double yb = Double.Parse(a[3]);
                double xc = Double.Parse(a[4]);
                double yc = Double.Parse(a[5]);
                double v = (xa * yb - xb * ya) / (xb * yc + xa * yb + xc * ya - xa * yc - xb * ya - xc * yb);
                double u = - xa / (xb - xa) - v * (xc - xa) / (xb - xa);
                double w = 1.0 - u - v;
                bool inTri  = 0 <= u && u <= 1 && 0 <= v && v <= 1 && 0 <= w && w <= 1;
                if (inTri)
                    count++;
                Console.WriteLine();
            }
            SR.Close();
            Console.WriteLine(count);
        }
    }
}
