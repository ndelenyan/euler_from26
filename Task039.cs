using System;

namespace euler_from26
{
    public static class Task39
    {

        public static bool isTri(int a, int b, int c) => a * a + b * b == c * c;

        public static void main()
        {
            int max_sols = 0;
            int max_p = 0;
            for (int p = 1; p <= 1000; p++)
            {
                int sols = 0;
                for (int c = 3; c <= p / 2; c++)
                    for (int a = 1; a < c; a++)
                    {
                        int b = p - c - a;
                        if (isTri(a, b, c))
                            sols++;
                    }
                if (sols > max_sols)
                {
                    max_sols = sols;
                    max_p = p;
                }
            }
            Console.WriteLine(max_p);
        }
    }
}