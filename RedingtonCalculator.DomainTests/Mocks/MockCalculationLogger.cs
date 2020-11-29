using RedingtonCalculator.Domain;
using RedingtonCalculator.Domain.Calculation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedingtonCalculator.DomainTests.Mocks
{
    class MockCalculationLogger : ICalculationLogger
    {
        public void LogCalculation(ICalculationResult result)
        {
        }
    }
}
