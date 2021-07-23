using System;
using TDDCalculator.Domain;
using Xunit;

namespace TDDCalculator.UnitTests
{
    public class CalculatorDivideTests
    {

        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(1.5, 2, 0.75)]
        public void Divide_DivideTwoNumber_WhenStringIsValid(float param1, float param2, float expected)
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
        public void Divide_ShouldThrowAnException_WhenZeroNumberAreUsed(float param1, float param2, float expected)
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
