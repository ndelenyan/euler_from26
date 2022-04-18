using System;

namespace euler_from26
{
    public static class Task081
    {

        public static int[][] grid, min;

        public static void calcMin(int y, int x)
        {
            if ((y == min.Length - 1) && (x == min[y].Length - 1))
                min[y][x] = grid[y][x];
            else if (y == min.Length - 1)
                min[y][x] = min[y][x + 1] + grid[y][x];
            else if (x == min[y].Length - 1)
                min[y][x] = min[y + 1][x] + grid[y][x];
            else
                {
                var right = min[y][x + 1];
                var down = min[y + 1][x];
                min[y][x] = right < down ? right : down;
                min[y][x] += grid[y][x];
            }

        }
        public static void main()
        {
            grid = Functions.LoadGrid("p081_matrix.txt", ",");
            min = new int[grid.Length][];
            for (int i = 0; i < min.Length; i++)
                min[i] = new int[grid[i].Length];

            for (int n = 79; n >= 0; n--)
            {
                for (int x = n; x >= 0; x--)
                {
                    calcMin(n, x);
                    calcMin(x, n);
                }
            }
            System.Console.WriteLine(min[0][0]);
        }
    }
}