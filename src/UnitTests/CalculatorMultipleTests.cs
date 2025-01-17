﻿using TDDCalculator.Domain;
using Xunit;

namespace TDDCalculator.UnitTests
{
    public class CalculatorMultipleTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1.5,2", 3)]
        public void Multiple_MultipleTwoNumbers_WhenStringIsValid(string calculation, float expected)
        {
            //Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Multiple(calculation);

            //Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("10,2,3,2", 120)]
        public void Multiple_MultipleAnyNumbers_WhenStringIsValid(string calculation, float expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.Multiple(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("5\n2,10\n5, 10", 5000)]
        public void Multiple_MultipleUsingNewLineDelimiter_WhenStringIsValid(string calculation, float expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.Multiple(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("5*2*10*5*10", 5000)]
        public void Multiple_MultipleUsingSignDelimiter_WhenStringIsValid(string calculation, float expected)
        {
            //Arrange
            var calc = new Calculator();

            //Act
            var result = calc.Multiple(calculation);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
