using System;
using TDDCalculator.Domain;
using Xunit;

namespace TDDCalculator.UnitTests
{
    public class CalculatorSplitEqTests
    {

        [Theory]
        [InlineData(10, 2, "{5, 5}")]
        [InlineData(120, 4, "{30, 30, 30, 30}")]
        public void SplitEq_SplitEqTwoNumber_WhenStringIsValid(int param1, int param2, string expected)
        {
            //Arrange
            var calc = new Calculator();

            // Act
            var result = calc.SplitEq(param1, param2);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
