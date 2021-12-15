using System;

namespace euler_from26
{
    public static class Task067
    {
        public static void main()
        {
            var grid = Functions.LoadGrid("p067_triangle.txt");
            Functions.PrintGrid(grid);
            int[][] sum = new int[grid.Length][];
            for (int i = 0; i < sum.Length; i++)
                sum[i] = new int[grid[i].Length];
            Array.ConstrainedCopy(grid[sum.Length - 1], 0, sum[sum.Length - 1], 0, sum[sum.Length - 1].Length - 1);
            for (int i = sum.Length - 2; i >= 0; i--)
                    for (int j = 0; j < sum[i].Length; j++)
                        sum[i][j] = grid[i][j] + (sum[i + 1][j] > sum[i+1][j+1] ? sum[i + 1][j] : sum[i + 1][j + 1]);
            Console.WriteLine(sum[0][0]);
        }
    }
}