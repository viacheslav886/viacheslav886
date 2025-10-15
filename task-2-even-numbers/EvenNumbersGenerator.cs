using System;

namespace EvenNumbersGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Even Numbers Generator");
            Console.WriteLine("======================\n");
            
            // Примеры использования
            Console.WriteLine("GetFirstEvenNumbers(3): " + string.Join(", ", GetFirstEvenNumbers(3)));
            Console.WriteLine("GetFirstEvenNumbers(5): " + string.Join(", ", GetFirstEvenNumbers(5)));
            Console.WriteLine("GetFirstEvenNumbers(8): " + string.Join(", ", GetFirstEvenNumbers(8)));
            
            // Интерактивный ввод
            Console.Write("\nEnter count of even numbers: ");
            if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
            {
                int[] numbers = GetFirstEvenNumbers(count);
                Console.WriteLine($"First {count} even numbers: {string.Join(", ", numbers)}");
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a positive integer.");
            }
        }

        public static int[] GetFirstEvenNumbers(int count)
        {
            var result = new int[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = (i + 1) * 2;
            }
            return result;
        }
    }
}
