using System;
namespace euler_from26
{
    public static class Task30
    {
        public static void main()
        {
            int max = 9 * 9 * 9 * 9 * 9 * 5;
            int all_sum = 0;
            for (int i = 1; i < max; i++)
            {
                long sum = 0;
                foreach(var digit in Digits.digits(i))
                    sum += digit * digit * digit * digit * digit;
                if (sum == i)
                    all_sum += i;
            }
            Console.WriteLine(all_sum - 1);
        }
    }
}