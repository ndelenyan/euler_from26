using System;

namespace euler_from26
{


    public struct ret
    {
        public long n;
        public bool win;
    }

    public static class Task692
    {

        public static bool siegbert(long all, long prev, out long min)
        {
            min = 0;
            if (all == 1 || all == 2)
            {
                min = all;
                return true;
            }
            long max = prev != 0 ? prev * 2 : all;
            for (min = 1; min <= max; min++)
                if (jo(all - min, min))
                    return true;
            return false;
        }


        public static bool jo(long all, long prev)
        {
            if (all == 0)
                return true;
            if (all <= prev * 2)
                return false;
            for (long i = 1; i <= prev * 2; i++)
                if (!siegbert(all - i, i, out long _))
                    return false;
            return true;
        }

        public static void main()
        {
            var ff = Functions.Fibonacci(81);
            long[] f = new long[ff.Length - 1];
            long[] sums = new long[ff.Length - 1];
            Array.ConstrainedCopy(ff, 2, f, 1, f.Length - 2);
            Console.WriteLine(MyCollections.Print(f));
            long sum = 0;
            for (int index = 0; index < f.Length; index++)
            {
                //                var index = Array.BinarySearch(f, test);
                // if (index >= 0)
                var min = f[index];
                // else
                //     siegbert(test, 0, out min);
                // if (index >= 0)
                if (index <= 3)
                    sums[index] = min;
                else
                    sums[index] = sums[index - 1] + sums[index - 2] + f[index - 3];
                sum += sums[index];
                Console.WriteLine($"index:{index}\tH={min}\tcalc sum:{sums[index]}");
            }
            Console.WriteLine(sum);
        }
    }
}