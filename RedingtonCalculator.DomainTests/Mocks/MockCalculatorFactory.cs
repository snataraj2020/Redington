using RedingtonCalculator.Domain.Calculation;
using System;
using System.Collections.Generic;

namespace RedingtonCalculator.DomainTests.Mocks
{
    class MockCalculatorFactory : ICalculatorFactory
    {
        public IEnumerable<CalculatorType> Calculators
        {
            get
            {
                yield return CalculatorType.CombinedWith;
                yield return CalculatorType.Either;
            }
        }

        public ICalculator GetCalculator(CalculatorType calculatorType)
        {
            switch (calculatorType)
            {
                case CalculatorType.CombinedWith:
                    return new Domain.Calculation.Calculators.CombinedWith();
                case CalculatorType.Either:
                    return new Domain.Calculation.Calculators.Either();
                default:
                    throw new InvalidOperationException($"Unknown calculator type: {calculatorType}");
            }
        }
    }
}