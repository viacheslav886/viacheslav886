using System;

namespace IsPrime
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите целое число:");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            bool isPrime = PrimeChecker.IsPrime(number);
            Console.WriteLine(isPrime ? "YES" : "NO");
        }
    }

    public static class PrimeChecker
    {
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int limit = (int)Math.Sqrt(number);
            for (int i = 3; i <= limit; i += 2)
            {
