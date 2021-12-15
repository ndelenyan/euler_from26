using System;
using System.Numerics;

namespace euler_from26
{
    public static class Task092
    {
        public static BigInteger arrive(BigInteger source)
        {
            while(source != 1 && source != 89)
            {
                BigInteger dest = 0;
                foreach(var digit in Digits.digits(source))
                    dest += digit * digit;
                source = dest;
            }
            return source;
        }
        public static void main()
        {
            int count89 = 0;
            for (BigInteger i = 1; i < 10000000; i++)
                if (arrive(i) == 89)
                    count89++;
            Console.WriteLine(count89);
        }
    }
}