
---

## 🧩 **Tests.cs**
```csharp
using NUnit.Framework;
using System.Collections.Generic;
using TextAnalysis;

namespace TextAnalysisTests
{
    [TestFixture]
    public class SentencesParserTaskTests
    {
        [Test]
        public void SimpleText_ShouldReturnWords()
        {
            var text = "Hello, world!";
            var expected = new List<List<string>>
            {
                new List<string> { "hello", "world" }
            };

            var actual = SentencesParserTask.ParseSentences(text);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultipleSentences_ShouldSplitCorrectly()
        {
            var text = "Hello! It's me. Are you there?";
            var expected = new List<List<string>>
            {
                new List<string> { "hello" },
                new List<string> { "it's", "me" },
                new List<string> { "are", "you", "there" }
            };

            var actual = SentencesParserTask.ParseSentences(text);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SentenceWithApostrophes_ShouldKeepWord()
        {
            var text = "Don't stop; it's fine.";
            var expected = new List<List<string>>
            {
                new List<string> { "don't", "stop" },
                new List<string> { "it's", "fine" }
            };

            var actual = SentencesParserTask.ParseSentences(text);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyText_ShouldReturnEmptyList()
        {
            var text = "";
            var result = SentencesParserTask.ParseSentences(text);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void SentenceWithoutLetters_ShouldBeSkipped()
        {
            var text = "!!! ??? ;;;";
            var result = SentencesParserTask.ParseSentences(text);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void MixedSymbols_ShouldParseOnlyLetters()
        {
            var text = "(Hello) --- world!!! #$ it's fine??";
            var expected = new List<List<string>>
            {
                new List<string> { "hello" },
                new List<string> { "world" },
                new List<string> { "it's", "fine" }
            };

            var actual = SentencesParserTask.ParseSentences(text);
            Assert.AreEqual(expected, actual);
        }
    }
}
