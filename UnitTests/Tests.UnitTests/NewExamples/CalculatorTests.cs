using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Src.UnitTests.NewExamples;

namespace Tests.UnitTests.NewExamples;




public class CalculatorTests
{
    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Add(10, 20);

        // Assert
        result.Should().Be(30);
    }

    [Fact]
    public void Add_NegativeAndPositiveNumbers_ReturnsCorrectSum()
    {
        var calculator = new Calculator();

        var result = calculator.Add(-10, 20);

        result.Should().Be(10);
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        var calculator = new Calculator();

        var result = calculator.Subtract(20, 8);

        result.Should().Be(12);
    }

    [Fact]
    public void Multiply_ByZero_ReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Multiply(15, 0);

        result.Should().Be(0);
    }

    [Fact]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        var calculator = new Calculator();

        var result = calculator.Divide(10, 2);

        result.Should().Be(5.0);
    }

    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        var calculator = new Calculator();
        new Mock
        var act = () => calculator.Divide(10, 0);

        act.Should()
            .Throw<DivideByZeroException>();
    }
}


