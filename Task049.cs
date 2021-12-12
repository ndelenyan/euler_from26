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

        public static bool perm_4_primes(long n, long [] primes)
        {
            List<long> res = new();
            foreach (var p in Functions.Permute(Digits.digits_array(n), 0))
            {
                long pp = Digits.int_from_digits(Functions.ToList(p));
                if (pp == n)
                    continue;
                if ((Digits.digit_len(pp) == 4) && (pp > n) && Array.IndexOf(primes, pp) >= 0)
                    res.Add(pp);
            }
            if (res.Count >= 2)
            {
                for (int i = 0; i < res.Count; i++)
                    for (int j = 0; j < res.Count; j++)
                        if (i == j)
                            continue;
                        else if (res[i] - n == res[j] - res[i])
                            Console.WriteLine($"{n} {res[i]} {res[j]} : ");
                return true;
            }
            else
                return false;
        }

        public static void main()
        {
            List<long> primes4 = new ();
            foreach (var p in prime4())
                primes4.Add(p);
            foreach(var p in primes4)
                perm_4_primes(p, primes4.ToArray());
        }
    }
}