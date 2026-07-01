using servcieCalc = OrderManagement.Application.CalculatorService;

namespace OrderManagement.Application.Test;

public class CalculatorServiceTests
{
    private readonly servcieCalc.CalculatorService _service =  new() ;

    [Theory]
    [InlineData(10, 5, "+", 15)]
    [InlineData(10, 5, "addition", 15)]
    [InlineData(10, 5, "-", 5)]
    [InlineData(10, 5, "soustraction", 5)]
    [InlineData(10, 5, "*", 50)]
    [InlineData(10, 5, "multiplication", 50)]
    [InlineData(10, 5, "/", 2)]
    [InlineData(10, 5, "division", 2)]
    public void Calculate_ReturnsExpectedResult(decimal firstValue, decimal secondValue, string operation, decimal expected)
    {
        var result = _service.Calculate(firstValue, secondValue, operation);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Calculate_ThrowsWhenDividingByZero()
    {
        var exception = Assert.Throws<DivideByZeroException>(() => _service.Calculate(10, 0, "/"));

        Assert.Equal("Division by zero is not allowed.", exception.Message);
    }

    [Fact]
    public void Calculate_ThrowsWhenOperationIsUnknown()
    {
        Assert.Throws<ArgumentException>(() => _service.Calculate(10, 5, "modulo"));
    }
}