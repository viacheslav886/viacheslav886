using NUnit.Framework;
using GuessNumberGame;

namespace GuessNumberGame.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Constructor_ShouldInitializeGame()
        {
            var game = new Game(1, 50, 5);
            Assert.AreEqual(5, game.MaxAttempts);
        }

        [Test]
        public void Guess_ShouldReturnHint_WhenWrongNumber()
        {
            var game = new Game(1, 2, 3);
            string result = game.Guess(1);
            Assert.IsTrue(result.Contains("больше") || result.Contains("меньше"));
        }

        [Test]
        public void Guess_ShouldEndAfterMaxAttempts()
        {
            var game = new Game(1, 2, 1);
            game.Guess(1);
            Assert.IsTrue(game.IsGameOver);
        }

        [Test]
        public void Guess_ShouldReturnSuccess_WhenGuessed()
        {
            // Проверяем, что при угадывании возвращается корректное сообщение.
            var game = new Game(1, 1, 5);
            string result = game.Guess(1);
            Assert.IsTrue(result.Contains("Поздравляем"));
        }
    }
}
