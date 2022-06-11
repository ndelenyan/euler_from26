using System;
namespace euler_from26
{
    public static class Task085
    {

        public static long times(long n, long k) => n - k + 1;

        public static long times (long w, long h, long k, long l) => times(w, k) * times(h, l);

        public static long rects(long w, long h)
        {
            long sum = 0;
            for (int x = 1; x <= w; x++)
                for(int y = 1; y <= h; y++)
                    sum += times(w, h, x, y);
            return sum;
        }

        public static void main ()
        {
            long max = 100;
            long target = 2_000_000;
            long min = target;
            long min_s = 0;
            for (int w = 1; w <= max; w++)
                for(long h = 1; h <= max; h++)
                {
                    long candidate = rects(w, h) - target;
                    if (candidate < 0)
                        candidate = -candidate;
                    if (candidate < min)
                    {
                        min = candidate;
                        min_s = w * h;
                        Console.WriteLine($"{w}x{h}\t{candidate}\t{rects(w, h)}");
                    }
                }
            Console.WriteLine(min_s);
        }
    }
}
