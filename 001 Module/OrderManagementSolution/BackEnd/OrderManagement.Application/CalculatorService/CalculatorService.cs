namespace OrderManagement.Application.CalculatorService;

public class CalculatorService : ICalculatorService
{
    public decimal Calculate(decimal firstValue, decimal secondValue, string operation)
    {
        return operation.Trim().ToLowerInvariant() switch
        {
            "+" or "addition" => firstValue + secondValue,
            "-" or "soustraction" => firstValue - secondValue,
            "*" or "multiplication" => firstValue * secondValue,
            "/" or "division" => secondValue == 0 ? throw new DivideByZeroException("Division by zero is not allowed.") : firstValue / secondValue,
            _ => throw new ArgumentException($"Operation non supportee: {operation}", nameof(operation))
        };
    }
}