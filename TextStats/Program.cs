using System;

namespace TextStats
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter text:");
            string input = Console.ReadLine() ?? "";

            Console.WriteLine($"\nWords: {TextAnalyzer.CountWords(input)}");
            Console.WriteLine($"Sentences: {TextAnalyzer.CountSentences(input)}");
            Console.WriteLine($"Average word length: {TextAnalyzer.AverageWordLength(input):0.00}");

            Console.WriteLine("\nTop words:");
            foreach (var pair in TextAnalyzer.TopWords(input))
                Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
