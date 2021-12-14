using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task058
    {

        public static void print_grid(BigInteger[,] grid, int n)
        {
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                    Console.Write($"{grid[y, x]}\t");
                Console.WriteLine();
            }
        }

        public static long[] primes = Prime.Primes(1000000000);

        public static long total(long size) => 2 * size - 1;

        public static void main()
        {
            // int count = 0;
            // do
            // {
            //     size += 2;
            //     var grid = Functions.fill__spiral_grid(size, false);
            //     //            print_grid(grid, size);
            //     count = 0;
            //     for (int i = 0; i < size; i++)
            //     {
            //         if (Array.IndexOf(primes, (long)grid[i, i]) >= 0)
            //             count++;
            //         if (Array.IndexOf(primes, (long)grid[i, size - i - 1]) >= 0)
            //             count++;
            //     }
            //     Console.WriteLine($"{size}: {count}/{2 * size - 1}={100*(double)count / (double)(2 * size - 1)}%");
            // } while((double)count / (double)(2 * size - 1) >= 0.1);
            // Console.WriteLine($"{size}");
            long max = 100000;
            long[] countPrimes = new long[max];
            countPrimes[1] = 0;
            long size = 1;
            while (size < max)
            {
                size += 2;
                countPrimes[size] = countPrimes[size - 2];
                long prevMax = (size - 2) * (size - 2);
                long c1 = prevMax + size - 1;
                long c2 = prevMax + 2 * (size - 1);
                long c3 = prevMax + 3 * (size - 1);
                long c4 = prevMax + 4 * (size - 1);
                if (Array.BinarySearch(primes, c1) >= 0)
                    countPrimes[size]++;
                if (Array.BinarySearch(primes, c2) >= 0)
                    countPrimes[size]++;
                if (Array.BinarySearch(primes, c3) >= 0)
                    countPrimes[size]++;
                if (Array.BinarySearch(primes, c4) >= 0)
                    countPrimes[size]++;
                Console.WriteLine($"{size}:\t{countPrimes[size]}/{total(size)}\t=\t{(double)countPrimes[size] / (double)total(size)*100}% ({c1} {c2} {c3} {c4})");
                if ((double)countPrimes[size] / (double)total(size) < 0.1)
                {
                    Console.WriteLine(size);
                    return;
                }
            }

        }
    }
}