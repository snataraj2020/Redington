using System;
using System.Collections.Generic;

namespace RedingtonCalculator.Domain.Calculation
{
    public interface ICalculatorFactory
    {
        IEnumerable<CalculatorType> Calculators { get; }
        ICalculator GetCalculator(CalculatorType calculatorType);
    }

    public class CalculatorFactory : ICalculatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public IEnumerable<CalculatorType> Calculators
        {
            get
            {
                yield return CalculatorType.CombinedWith;
                yield return CalculatorType.Either;
            }
        }

        public CalculatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICalculator GetCalculator(CalculatorType calculatorType)
        {
            switch (calculatorType)
            {
                case CalculatorType.CombinedWith:
                    return (ICalculator)_serviceProvider.GetService(typeof(Calculators.CombinedWith));
                case CalculatorType.Either:
                    return (ICalculator)_serviceProvider.GetService(typeof(Calculators.Either));
                default:
                    throw new InvalidOperationException($"Unknown calculator type: {calculatorType}");
            }
        }
    }
}
