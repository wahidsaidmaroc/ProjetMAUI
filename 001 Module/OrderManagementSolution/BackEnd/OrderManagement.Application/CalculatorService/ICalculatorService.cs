namespace OrderManagement.Application.CalculatorService;

public interface ICalculatorService
{
    decimal Calculate(decimal firstValue, decimal secondValue, string operation);
}