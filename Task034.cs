using System;
namespace euler_from26
{
    public static class Task34
    {

        public static int sum_fact(int n)
        {
            int sum = 0;
            foreach(var d in Digits.digits(n))
                sum += Functions.Factorial(d);
            return sum;
        }
        public static void main()
        {
            int sum = -3;
            for (int i = 1; i < 1000000; i++)
                if (i==sum_fact(i))
                {
                    sum += i;
                    Console.WriteLine(i);
                }
            Console.WriteLine(sum);
        }
    }
}