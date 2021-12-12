using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Task049
    {

        public static int[] primes = Prime.Primes(10000);

        public static IEnumerable<int> prime4()
        {
            foreach(var p in primes)
                if (Digits.digit_len(p) == 4)
                    yield return p;
        }

        public static void main()
        {
            List<int> primes4 = new List<int>();
            foreach (var p in prime4())
                primes4.Add(p);
            Console.WriteLine(primes4.Count);
            //
        }
    }
}