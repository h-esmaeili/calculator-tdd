using TDDCalculator.Domain;
using Xunit;

namespace TDDCalculator.UnitTests
{
    public class CalculatorSubtractTests
    {

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("3,2", 1)]
        public void Subtract_SubtractTwoNumbers_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Subtract(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("6,1,1", 4)]
        [InlineData("10, 2, 3, 5", 0)]
        public void Subtract_SubtractAnyNumbers_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.Subtract(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("8\n2,3", 3)]
        [InlineData("20\n2, 3\n 5, 5", 5)]
        public void Subtract_SubtractUsingNewLineDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.Subtract(calculation);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
