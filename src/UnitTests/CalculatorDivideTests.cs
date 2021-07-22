using System;
using TDDCalculator.Domain;
using Xunit;

namespace TDDCalculator.UnitTests
{
    public class CalculatorDivideTests
    {

        [Theory]
        [InlineData(1, 2, 0)]
        public void Divide_DivideTwoNumber_WhenStringIsValid(int param1, int param2, int expected)
        {
            //Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Divide(param1, param2);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 0, 0)]
        public void Divide_ShouldThrowAnException_WhenZeroNumberAreUsed(int param1, int param2, int expected)
        {
            //Arrange
            var calc = new Calculator();

            // Act
            void action() => calc.Divide(param1, param2);

            //Assert
            var exception = Assert.Throws<DivideByZeroException>(action);

            Assert.Equal("Zero not allowed: " + expected, exception.Message);
        }
    }
}
