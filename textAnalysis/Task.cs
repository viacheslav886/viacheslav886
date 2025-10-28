using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    public static class FrequencyAnalysisTask
    {
        /// <summary>
        /// Строит N-граммную модель текста:
        /// для всех биграмм и триграмм находит наиболее частое продолжение.
        /// </summary>
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var bigrams = GetNgrams(text, 2);
            var trigrams = GetNgrams(text, 3);

            AddMostFrequentToResult(result, bigrams);
            AddMostFrequentToResult(result, trigrams);

            return result;
        }

        private static Dictionary<string, Dictionary<string, int>> GetNgrams(List<List<string>> text, int n)
        {
            var ngrams = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in text)
            {
                for (int i = 0; i <= sentence.Count - n; i++)
                {
                    string start = string.Join(" ", sentence.GetRange(i, n - 1));
                    string next = sentence[i + n - 1];

                    if (!ngrams.ContainsKey(start))
                        ngrams[start] = new Dictionary<string, int>();

                    if (!ngrams[start].ContainsKey(next))
                        ngrams[start][next] = 0;

                    ngrams[start][next]++;
                }
            }

            return ngrams;
        }

        private static void AddMostFrequentToResult(
            Dictionary<string, string> result,
            Dictionary<string, Dictionary<string, int>> ngrams)
        {
            foreach (var pair in ngrams)
            {
                string start = pair.Key;
                var continuations = pair.Value;

                string bestNext = "";
                int maxFrequency = -1;

                foreach (var cont in continuations)
                {
                    string next = cont.Key;
                    int frequency = cont.Value;

                    if (frequency > maxFrequency ||
                        (frequency == maxFrequency && string.CompareOrdinal(next, bestNext) < 0))
                    {
                        maxFrequency = frequency;
                        bestNext = next;
                    }
                }

                result[start] = bestNext;
            }
        }
    }
}
