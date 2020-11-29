using RedingtonCalculator.Domain.Models;

namespace RedingtonCalculator.Domain.Calculation.Calculators
{
    public class CombinedWith : ICalculator
    {
        public CalculatorType Type => CalculatorType.CombinedWith;

        public string Description => "The probability of the two scenarios occurring simultaneously.";

        public ICalculationResult Calculate(IInputData inputData)
        {
            var output = inputData.Probability1 * inputData.Probability2;
            return new CalculationResult(inputData, output);
        }
    }
}
