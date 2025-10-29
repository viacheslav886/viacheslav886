using System;
using System.Collections.Generic;
using System.Linq;

namespace WordStatistics
{
    public static class WordAnalyzer
    {
        /// <summary>
        /// Считает, сколько раз каждое слово встречается в тексте.
        /// </summary>
        public static Dictionary<string, int> CountWordFrequencies(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new Dictionary<string, int>();

            var words = text
                .ToLower()
                .Split(new[] { ' ', '\t', '\n', '\r', ',', '.', '!', '?', ';', ':', '"', '\'' },
                       StringSplitOptions.RemoveEmptyEntries);

            return words
                .GroupBy(w => w)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Возвращает N самых частых слов в тексте.
        /// При равной частоте — в лексикографическом порядке.
        /// </summary>
        public static List<string> GetTopWords(string text, int n)
        {
            var frequencies = CountWordFrequencies(text);

            return frequencies
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key, StringComparer.Ordinal)
                .Take(n)
                .Select(p => p.Key)
                .ToList();
        }

        /// <summary>
        /// Возвращает все слова, начинающиеся с указанного префикса.
        /// </summary>
        public static List<string> FindWordsByPrefix(string text, string prefix)
        {
            var frequencies = CountWordFrequencies(text);
            prefix = prefix.ToLower();

            return frequencies.Keys
                .Where(w => w.StartsWith(prefix, StringComparison.Ordinal))
                .OrderBy(w => w, StringComparer.Ordinal)
                .ToList();
        }
    }
}
