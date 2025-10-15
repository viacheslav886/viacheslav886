using Xunit;

namespace BankInterestCalculator.Tests
{
    public class InterestCalculatorTests
    {
        [Fact]
        public void Test_OneMonth_At12Percent()
        {
            // arrange
            string input = "100.00 12 1";
            double expected = 101.0;

            // act
            double result = BankInterestCalculator.InterestCalculator.Calculate(input);

            // assert
            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void Test_TwelveMonths_At12Percent()
        {
            string input = "100 12 12";
            double expected = 112.68; // примерно

            double result = BankInterestCalculator.InterestCalculator.Calculate(input);

            Assert.Equal(expected, result, 2);
        }
    }
}
