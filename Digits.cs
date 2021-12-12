using System;
using System.Collections.Generic;

namespace euler_from26
{
    public static class Digits
    {
        public static IEnumerable<int> digits (int n, int basis = 10)
        {
            while(n > 0)
                {
                    yield return n % basis;
                    n /= basis;
                }
        }

        public static int digit_len(int n, int basis = 10)
        {
            int l = 0;
            foreach (var d in digits(n, basis))
                l++;
            return l;
        }

        public static List<int> digits_list(int n, int basis = 10)
        {
            List<int> res = new();
            foreach(var d in digits(n, basis))
                res.Add(d);
            return res;
        }

        public static void Rotate_Digits(List<int> p)
        {
            int temp = p[0];
            p.RemoveAt(0);
            p.Add(temp);
        }

        public static int int_from_digits(List<int> p, int basis = 10)
        {
            int res = 0;
            for ( int i = 0; i < p.Count; i++)
                res += (int)Math.Pow(basis, i) * p[i];
            return res;
        }

        public static long int_from_digits(int[] p, bool reverse = false, int basis = 10)
        {
            long res = 0;
            if (! reverse)
            {
                for ( int i = 0; i < p.Length; i++)
                    res += (long)Math.Pow(basis, i) * p[i];
            }
            else
            {
                for ( int i = 0; i < p.Length; i++)
                    res += (long)Math.Pow(basis, i) * p[p.Length - i - 1];
            }
            return res;
        }

        public static bool Reduce_Digits(List<int> p1, List<int> p2, int max)
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

        public static int[] digits_array(int n, int basis = 10)
        {
            List<int> res = new();
            foreach(var d in digits(n, basis))
                res.Add(d);
            return res.ToArray();
        }

        public static bool isPandigital(int n)
        {
            int [] d = digits_array(n);
            for (int i = 1; i <= d.Length; i++)
                if (Array.IndexOf(d, i) < 0)
                    return false;
            return true;
        }

        public static bool isPalindrome(int[] digits)
        {
            for (int i = 0; i < digits.Length ; i++)
                if (digits[i] != digits[digits.Length - i - 1])
                    return false;
            return true;
        }

        public static bool isPandigital(int z, params int[] n)
        {
            List<int>lst = new List<int>();
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