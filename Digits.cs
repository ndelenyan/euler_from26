using System;
using System.Collections.Generic;
using System.Numerics;

namespace euler_from26
{
    public static class Digits
    {

        public static BigInteger digit_sum(BigInteger n)
        {
            BigInteger res = 0;
            foreach(var p in digits(n))
                res += p;
            return res;
        }

        public static IEnumerable<int> digits(BigInteger n, int basis = 10)
        {
            while (n > 0)
            {
                yield return (int)(n % basis);
                n /= basis;
            }
        }

        public static List<int> digitsAsList(BigInteger n, int basis = 10)
        {
            List<int> res = new();
            while (n > 0)
            {
                res.Add((int)(n % basis));
                n /= basis;
            }
            return res;
        }

        public static int[] digitsAsArray(BigInteger n, int basis = 10) => digitsAsList(n, basis).ToArray();

        public static int digit_len(BigInteger n, int basis = 10)
        {
            int l = 0;
            foreach (var d in digits(n, basis))
                l++;
            return l;
        }

        public static BigInteger int_from_digits(IList<int> digits, bool reverse = false, int basis = 10)
        {
            BigInteger multiplier = 1;
            BigInteger res = 0;
            for (int i = 0; i < digits.Count; i++)
            {
                res += multiplier * (reverse ? digits[digits.Count - i - 1] : digits[i]);
                multiplier *= basis;
            }
            return res;
        }
        public static void Rotate_Digits(IList<int> p)
        {
            int temp = p[0];
            p.RemoveAt(0);
            p.Add(temp);
        }

        public static bool Reduce_Digits(List<int> p1, List<int> p2, long max)
        {
            int reduced = 0;
            int n1 = 0;
            do
            {
                int n2 = p2.IndexOf(p1[n1]);
                if (n2 >= 0)
                {
                    p1.RemoveAt(n1);
                    p2.RemoveAt(n2);
                    reduced++;
                    if (reduced == max)
                        return true;
                }
                else
                    n1++;
            } while (n1 < p1.Count);
            return false;
        }

        public static bool isPandigital(BigInteger n)
        {
            var d = digitsAsArray(n);
            for (int i = 1; i <= d.Length; i++)
                if (Array.IndexOf(d, i) < 0)
                    return false;
            return true;
        }

        public static bool isPalindrome(BigInteger n) => isPalindrome(digitsAsArray(n));

        public static bool isPalindrome(int[] digits)
        {
            for (int i = 0; i < digits.Length ; i++)
                if (digits[i] != digits[digits.Length - i - 1])
                    return false;
            return true;
        }

        public static bool isPandigital(BigInteger z, params int[] n)
        {
            List<int>lst = new ();
            foreach(int nn in n)
                lst.AddRange(digits(nn));
            int [] d = lst.ToArray();
            if (z != d.Length)
                return false;
            for (int i = 1; i <= d.Length; i++)
                if (Array.IndexOf(d, i) < 0)
                    return false;
            return true;
        }

    }
}