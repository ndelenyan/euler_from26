using System;

namespace euler_from26
{
    public static class Task070
    {
        public static void main ()
        {
            Console.WriteLine("Task070");
            var primes = Prime.Primes(1000);
            Console.WriteLine(Prime.totient(36, primes));
        }
    }
}
