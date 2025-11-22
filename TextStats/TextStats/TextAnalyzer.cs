using System;
using System.Linq;
using System.Collections.Generic;

namespace TextStats
{
    public static class TextAnalyzer
    {
        public static int CountWords(string text)
        {
            return string.IsNullOrWhiteSpace(text)
                ? 0
                : text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int CountSentences(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;

            char[] end = { '.', '!', '?' };
            return text.Split(end, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static Dictionary<string, int> TopWords(string text, int top = 5)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new();

            var words = text
                .ToLower()
                .Split(new[] { ' ', '\n', '\r', '\t', '.', ',', '?', '!', ';', ':' },
                       StringSplitOptions.RemoveEmptyEntries);

            return words
                .GroupBy(x => x)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .Take(top)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public static double AverageWordLength(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;

            var words = text
                .Split(new[] { ' ', '\n', '\r', '\t', '.', ',', '?', '!', ';', ':' },
                       StringSplitOptions.RemoveEmptyEntries);

            return words.Average(w => w.Length);
        }
    }
}
