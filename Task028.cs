using System;

namespace euler_from26
{
//     Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

// 21 22 23 24 25
// 20  7  8  9 10
// 19  6  1  2 11
// 18  5  4  3 12
// 17 16 15 14 13

// It can be verified that the sum of the numbers on the diagonals is 101.

// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
    public static class Task28
    {

        public static int [,] grid;

        public static void print_grid(int n)
        {
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                    Console.Write($"{grid[y, x]}\t");
                Console.WriteLine();
            }
        }

        public static void fill_grid(int n)
        {
            grid = new int[n, n];
            int minX = n / 2;
            int maxX = n / 2;
            int minY = n / 2;
            int maxY = n / 2;
            int z = 1;
            grid[minX, minY] = z;
            // right - down - left - up
            while (true)
            {
                if (maxX < n - 1)
                {
                    maxX++;
                    for (int x = minX + 1; x <= maxX; x++)
                        grid[minY, x] = ++z;
                }
                else
                {
                    for (int x = minX + 1; x <= maxX; x++)
                        grid[minY, x] = ++z;
                    return;
                }
                if (maxY < n - 1)
                {
                    maxY++;
                    for (int y = minY + 1; y <= maxY; y++)
                        grid[y, maxX] = ++z;
                }
                else
                    return;
                if (minX > 0)
                {
                    minX--;
                    for (int x = maxX - 1; x >= minX; x--)
                        grid[maxY, x] = ++z;
                }
                else
                    return;
                if (minY > 0)
                {
                    minY--;
                    for (int y = maxY - 1; y >= minY; y--)
                        grid[y, minX] = ++z;
                }
                else
                    return;
            }
        }

        public static int sum_diag(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += grid[i, i];
                sum += grid[i, n-i-1];
            }
            sum -= grid[n/2, n/2];
            return sum;
        }

        public static void main()
        {
            fill_grid(1001);
//            print_grid(5);
            Console.WriteLine(sum_diag(1001));
        }
    }
}