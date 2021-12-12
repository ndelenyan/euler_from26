using System;
using System.Text;

namespace euler_from26
{
    public static class Task40
    {
        public static string S;

        public static int d(int i)
        {
            return S[i-1] - '0';
        }

        public static void main()
        {
            var SB = new StringBuilder();
            int i = 1;
            do
            {
                SB.Append(i++);
            } while (SB.Length <= 1000000);
            S = SB.ToString();
            Console.WriteLine(d(1) * d(10) * d(100) * d(1000) * d(10000) * d(100000) * d(1000000));
        }
    }
}