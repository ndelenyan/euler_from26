using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace euler_from26
{
    public static class Functions
    {

        public static BigInteger[] Fibonacci(int count)
        {
            BigInteger[] res = new BigInteger[count];
            res[0] = 0;
            res[1] = 1;
            for (int i = 2; i < count; i++)
                res[i] = res[i - 1] + res[i - 2];
            return res;
        }
        public static void PrintGrid(int[][]grid)
        {
            foreach (var line in grid)
            {
                foreach (var g in line)
                    Console.Write($"{g} ");
                Console.WriteLine();
            }
        }

        public static int[] LoadNumbers(string filename)
        {
            List<string> lines = new();
            StreamReader SR = new StreamReader(filename);
            while (SR.Peek() >= 0)
                lines.Add(SR.ReadLine());
            SR.Close();
            int[] grid = new int[lines.Count];
            for (int i = 0; i < lines.Count; i++)
                grid[i] = int.Parse(lines[i]);
            return grid;
        }
        public static int[][] LoadGrid(string filename)
        {
            List<string> lines = new();
            StreamReader SR = new StreamReader(filename);
            while(SR.Peek() >= 0)
                lines.Add(SR.ReadLine());
            SR.Close();
            int[][] grid = new int[lines.Count][];
            for (int i = 0; i < lines.Count; i++)
            {
                var str_nums = lines[i].Split(" ");
                grid[i] = new int[str_nums.Length];
                for (int j = 0; j < str_nums.Length; j++)
                    grid[i][j] = int.Parse(str_nums[j]);
            }
            return grid;
        }

        public static void swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public static IEnumerable<int[]> Permute(int[] ints, long fix)
        {
            if (fix == ints.Length - 1)
                yield return ints;
            else
                for (long f = fix; f < ints.Length; f++)
                {
                    swap(ref ints[fix], ref ints[f]);
                    foreach(var p in Permute(ints, fix + 1))
                        yield return p;
                    swap(ref ints[fix], ref ints[f]);
                }
        }

        public static IEnumerable<int[]> Combine(int[] ints, long fix)
        {
            if (fix == ints.Length - 1)
                for (int i = 'A'; i <= 'Z'; i++)
                {
                    ints[fix] = i;
                    yield return ints;
                }
            else
                for (long f = fix; f < ints.Length; f++)
                {
                    foreach (var p in Combine(ints, fix + 1))
                        yield return p;
                }
        }



        public static List<int> ToList(int[] array)
        {
            List<int> lst = new();
            foreach(var l in array)
                lst.Add(l);
            return lst;
        }

        public static int WordValue(string name)
        {
            int w = 0;
            for (int i=0; i<name.Length; i++)
            {
                int l = name[i] - 'A' + 1;
                w += l;
            }
            return w;
        }
        public static string[] LoadWords(string filename)
        {
            StreamReader SR = new StreamReader(filename);
            var text = SR.ReadLine();
            SR.Close();
            var names = text.Split(',');
            string[] name = new string[names.Length];
            for(int i = 0; i < names.Length; i++)
                name[i] = names[i].Trim('\"');
            return name;
        }
        public static long Factorial(long n)
        {
            long res = 1;
            for (long i=1; i<= n; i++)
                res *= i;
            return res;
        }

        public static BigInteger Factorial(BigInteger n)
        {
            BigInteger res = 1;
            if (n > 1)
                for (BigInteger i = 2; i <= n; i++)
                    res *= i;
            return res;
        }

        public static BigInteger C(BigInteger n, BigInteger k) => Factorial(n) / (Factorial(k) * Factorial(n - k));

        public static BigInteger[,] fill__spiral_grid(int n, bool clockwise)
        {
            BigInteger[,] grid = new BigInteger[n, n];
            int minX = n / 2;
            int maxX = n / 2;
            int minY = n / 2;
            int maxY = n / 2;
            long z = 1;
            grid[minX, minY] = z;
            if (clockwise)
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
                        return grid;
                    }
                    if (maxY < n - 1)
                    {
                        maxY++;
                        for (int y = minY + 1; y <= maxY; y++)
                            grid[y, maxX] = ++z;
                    }
                    else
                        return grid;
                    if (minX > 0)
                    {
                        minX--;
                        for (int x = maxX - 1; x >= minX; x--)
                            grid[maxY, x] = ++z;
                    }
                    else
                        return grid;
                    if (minY > 0)
                    {
                        minY--;
                        for (int y = maxY - 1; y >= minY; y--)
                            grid[y, minX] = ++z;
                    }
                    else
                        return grid;
                }
            else
                // counter-clockwise
                while (true)
                {
                    if (maxX < n - 1)
                    {
                        maxX++;
                        for (int x = minX + 1; x <= maxX; x++)
                            grid[maxY, x] = ++z;
                    }
                    else
                    {
                        for (int x = minX + 1; x <= maxX; x++)
                            grid[maxY, x] = ++z;
                        return grid;
                    }
                    if (minY > 0)
                    {
                        minY--;
                        for (int y = maxY - 1; y >= minY; y--)
                            grid[y, maxX] = ++z;
                    }
                    else
                        return grid;
                    if (minX > 0)
                    {
                        minX--;
                        for (int x = maxX - 1; x >= minX; x--)
                            grid[minY, x] = ++z;
                    }
                    else
                        return grid;
                    if (maxY < n - 1)
                    {
                        maxY++;
                        for (int y = minY + 1; y <= maxY; y++)
                            grid[y, minX] = ++z;
                    }
                    else
                        return grid;
                }
        }
    }
}