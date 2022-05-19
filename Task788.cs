using System;

namespace euler_from26
{
    public static class Task788
    {

        public static void main()
        {
            long count = 0;
            long max = 4;
            long i = 0;
            while (++i < Math.Pow(10, max))
            {
                bool isd = Numbers.IsDominating(i);
                if (isd)
                    count++;
                Console.WriteLine($"{i}: {(isd ? '*' : ' ')}\tcount:{count}");
            }
        }
    }
}