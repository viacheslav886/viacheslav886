using System;

namespace BankCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bank Deposit Calculator");
            Console.WriteLine("=======================\n");
            
            Console.WriteLine("Enter initial amount, annual rate (%), and months (separated by space):");
            Console.WriteLine("Example: 100.00 12 1");
            
            string input = Console.ReadLine();
            double result = Calculate(input);
            
            Console.WriteLine($"\nFinal amount: {Math.Round(result)}");
            Console.WriteLine($"Detailed: {result:F2}");
        }

        public static double Calculate(string input)
        {
            var parts = input.Split();
            var sum = double.Parse(parts[0]);
            var annualRate = double.Parse(parts[1]);
            var months = int.Parse(parts[2]);
            var result = sum * Math.Pow(1 + annualRate / 100.0 / 12.0, months);
            return result;
        }
    }
}
