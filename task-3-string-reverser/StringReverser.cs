using System;

namespace StringReverser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("String Reverser");
            Console.WriteLine("===============\n");
            
            // Примеры использования
            string[] testStrings = { "hello", "world", "programming", "a", "" };
            
            foreach (string input in testStrings)
            {
                string reversed = ReverseString(input);
                Console.WriteLine($"'{input}' -> '{reversed}'");
            }
            
            // Интерактивный ввод
            Console.Write("\nEnter a string to reverse: ");
            string userInput = Console.ReadLine();
            string userReversed = ReverseString(userInput);
            Console.WriteLine($"Reversed: '{userReversed}'");
        }

        public static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
                
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
