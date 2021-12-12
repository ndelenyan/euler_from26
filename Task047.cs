using System;


namespace euler_from26
{
    public static class Task47
    {

        public static int max = 1000000;

        public static int[] primes = Prime.Primes(max);


        public static int countPrimeFactors(int n) => Prime.Prime_Unique_Divisors(n, primes).Count;
        public static void main()
        {
            int i = 1;
            do
            {
                i++;
            } while (countPrimeFactors(i) != 4 || countPrimeFactors(i+1) != 4 || countPrimeFactors(i+2) != 4 || countPrimeFactors(i+3) != 4);
            Console.WriteLine(i);
        }
    }
}