using RedingtonCalculator.Domain.Models;

namespace RedingtonCalculator.Domain.Calculation.Calculators
{
    public class Either : ICalculator
    {
        public CalculatorType Type => CalculatorType.Either;

        public string Description => "The probability of exactly one of the two scenarios occurring.";

        public ICalculationResult Calculate(IInputData inputData)
        {
            var output = inputData.Probability1 + 
                         inputData.Probability2 -
                         (inputData.Probability1 * inputData.Probability2);

            return new CalculationResult(inputData, output);
        }
    }
}
