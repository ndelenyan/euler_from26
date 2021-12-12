using System;

namespace euler_from26
{
    public static class Task45
    {
        public static void main()
        {
            long i=144;
            long H = 0;
            do
            {
                H = i * (2 * i - 1);
                i++;
            } while (!(Numbers.isPentagonal(H) && Numbers.isTriangular(H)));
            Console.WriteLine(H);
        }
    }
}