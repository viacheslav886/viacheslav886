using NUnit.Framework;
using TextStats;

namespace Tests
{
    public class TextAnalyzerTests
    {
        [Test]
        public void TestWordCount()
        {
            Assert.AreEqual(4, TextAnalyzer.CountWords("Hello world from test"));
        }

        [Test]
        public void TestSentenceCount()
        {
            Assert.AreEqual(2, TextAnalyzer.CountSentences("Hi! How are you?"));
        }

        [Test]
        public void TestTopWords()
        {
            var top = TextAnalyzer.TopWords("a a a b b c", 2);
            Assert.AreEqual("a", top.Keys.First());
            Assert.AreEqual(3, top["a"]);
        }

        [Test]
        public void TestAverageLength()
        {
            Assert.AreEqual(3, TextAnalyzer.AverageWordLength("hey bro"));
        }
    }
}
