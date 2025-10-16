---

## 💻 Program.cs
```csharp
using System;

namespace SumOfDigits
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите целое число:");
            string input = Console.ReadLine();
            int result = Calculator.SumOfDigits(input);
            Console.WriteLine(result);
        }
    }

    public static class Calculator
    {
        public static int SumOfDigits(string input)
        {
            int number = Math.Abs(int.Parse(input));
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
    }
}
