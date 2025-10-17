using Xunit;

namespace IsPrime.Tests
{
    public class IsPrimeTests
    {
        [Theory]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(17, true)]
        [InlineData(18, false)]
        [InlineData(1, false)]
        [InlineData(0, false)]
        [InlineData(-7, false)]
        public void CheckPrimes(int number, bool expected)
        {
            bool result = IsPrime.PrimeChecker.IsPrime(number);
            Assert.Equal(expected, result);
        }
    }
}
