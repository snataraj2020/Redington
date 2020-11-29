using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RedingtonCalculator.Domain.Calculation;
using RedingtonCalculator.Domain.Models;
using System;
using System.Collections.Generic;

namespace RedingtonCalculator.Domain
{
    public interface ICalculatorService
    {
        IEnumerable<CalculatorType> Calculators { get; }

        ICalculationResult PerformCalculation(CalculatorType type, decimal probability1, decimal probability2);
    }

    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculatorFactory _calculatorFactory;
        private readonly ICalculationLogger _logger;

        public IEnumerable<CalculatorType> Calculators => _calculatorFactory.Calculators;

        public CalculatorService(ICalculatorFactory calculatorFactory, ICalculationLogger logger)
        {
            _calculatorFactory = calculatorFactory;
            _logger = logger;
        }

        public ICalculationResult PerformCalculation(CalculatorType type, decimal probability1, decimal probability2)
        {
            IInputData data = new InputData(probability1, probability2);
            ICalculationResult calculationResult;

            var validationResult = data.Validate();
            if (validationResult.Success == false)
            {
                CalculationResult concreteResult = new CalculationResult(data);
                concreteResult.AppendResult(validationResult);

                calculationResult = concreteResult;
            }
            else
            {
                var calculator = _calculatorFactory.GetCalculator(type);
                calculationResult = calculator.Calculate(data);
            }

            _logger.LogCalculation(calculationResult);

            return calculationResult;
        }
    }
}
