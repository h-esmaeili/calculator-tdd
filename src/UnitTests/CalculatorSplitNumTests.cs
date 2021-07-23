using TDDCalculator.Domain;
using Xunit;

namespace TDDCalculator.UnitTests
{
    public class CalculatorSplitNumTests
    {

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("10,2", 8)]
        public void SplitNum_SplitNumTwoNumbers_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            // Act
            var result = calc.SplitNum(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("60,15,10", 35)]
        [InlineData("140,45,35,20", 40)]
        public void SplitNum_SplitNumAnyNumbers_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.SplitNum(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("8\n2,3", 3)]
        [InlineData("20\n2,3\n5, 5", 5)]
        public void SplitNum_SplitNumUsingNewLineDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.SplitNum(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("8 SN 2 SN 3", 3)]
        [InlineData("140 SN 45 SN 35 SN 20", 40)]
        public void SplitNum_SplitNumUsingSNDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.SplitNum(calculation);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
