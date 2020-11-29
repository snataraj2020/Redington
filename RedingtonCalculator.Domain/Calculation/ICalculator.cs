using RedingtonCalculator.Domain.Models;

namespace RedingtonCalculator.Domain.Calculation
{
    public interface ICalculator
    {
        CalculatorType Type { get; }
        string Description { get; }

        ICalculationResult Calculate(IInputData inputData);
    }
}
