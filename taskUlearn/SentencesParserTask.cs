using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    public static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            // Разделяем текст на предложения по заданным символам
            var sentenceSeparators = new[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentences = text.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries);

            var result = new List<List<string>>();

            foreach (var sentence in sentences)
            {
                var words = new List<string>();
                var currentWord = "";

                foreach (var ch in sentence)
                {
                    if (char.IsLetter(ch) || ch == '\'')
                    {
                        currentWord += char.ToLower(ch);
                    }
                    else if (currentWord.Length > 0)
                    {
                        words.Add(current
