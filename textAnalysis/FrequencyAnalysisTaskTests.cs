using System.Collections.Generic;
using NUnit.Framework;
using TextAnalysis;

namespace TextAnalysis.Tests
{
    [TestFixture]
    public class FrequencyAnalysisTaskTests
    {
        [Test]
        public void ExampleTest()
        {
            var text = new List<List<string>>
            {
                new List<string> { "a", "b", "c", "d" },
                new List<string> { "b", "c", "d" },
                new List<string> { "e", "b", "c", "a", "d" }
            };

            var expected = new Dictionary<string, string>
            {
                {"a", "b"},
                {"b", "c"},
                {"c", "d"},
                {"e", "b"},
                {"a b", "c"},
                {"b c", "d"},
                {"e b", "c"},
                {"c a", "d"}
            };

            var actual = FrequencyAnalysisTask.GetMostFrequentNextWords(text);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void LexicographicalTieBreak()
        {
            var text = new List<List<string>>
            {
                new List<string> { "x", "a" },
                new List<string> { "x", "b" }
            };

            var result = FrequencyAnalysisTask.GetMostFrequentNextWords(text);

            Assert.AreEqual("a", result["x"], "Должно выбрать лексикографически меньшее 'a'");
        }

        [Test]
        public void EmptyInput_ReturnsEmptyDictionary()
        {
            var result = FrequencyAnalysisTask.GetMostFrequentNextWords(new List<List<string>>());
            Assert.IsEmpty(result);
        }
    }
}
