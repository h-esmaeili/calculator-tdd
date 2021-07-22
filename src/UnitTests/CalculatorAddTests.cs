using System;
using TDDCalculator.Domain;
using Xunit;

namespace TDDCalculator.UnitTests
{
    public class CalculatorAddTests
    {

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1,4", 5)]
        public void Add_AddTwoNumber_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1, 2, 3, 5", 11)]
        public void Add_AddAnyNumbers_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2, 3\n 5, 10", 21)]
        public void Add_AddUsingNewLineDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }



        [Theory]
        [InlineData("1,-2", "-2")]
        [InlineData("1,2,-1,-4", "-1,-4")]
        public void Add_ShouldThrowAnException_WhenNegativeNumbersAreUsed(string calculation, string expected)
        {
            //Arrange
            var calc = new Calculator();

            // Act
            void action() => calc.Add(calculation);

            //Assert
            var exception = Assert.Throws<Exception>(action);

            Assert.Equal("Negatives not allowed: " + expected, exception.Message);
        }
    }
}
