using RedingtonCalculator.Domain;
using RedingtonCalculator.Domain.Calculation;
using RedingtonCalculator.Domain.Calculation.Calculators;
using RedingtonCalculator.Domain.Models;
using RedingtonCalculator.DomainTests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RedingtonCalculator.DomainTests
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData(CalculatorType.CombinedWith, 0, 0, 0)]
        [InlineData(CalculatorType.CombinedWith, 1, 1, 1)]
        [InlineData(CalculatorType.CombinedWith, 0.5, 0.5, 0.25)]
        [InlineData(CalculatorType.Either, 1, 1, 1)]
        [InlineData(CalculatorType.Either, 0.5, 0.5, 0.75)]
        [InlineData(CalculatorType.Either, 0.25, 0.8, 0.85)]
        public void Calculations_ValidData_CorrectValues(CalculatorType type, decimal p1, decimal p2, decimal output)
        {
            CalculatorService service = new CalculatorService(new MockCalculatorFactory(), new MockCalculationLogger());
            var result = service.PerformCalculation(type, p1, p2);

            Assert.True(result.Success);
            Assert.Equal(output, result.Output);
        }

        [Theory]
        [InlineData(CalculatorType.CombinedWith, -1, 0)]
        [InlineData(CalculatorType.CombinedWith, 2, 0)]
        [InlineData(CalculatorType.Either, 0, -1)]
        [InlineData(CalculatorType.Either, 0, 2)]
        [InlineData(CalculatorType.CombinedWith, -1, 2)]
        [InlineData(CalculatorType.Either, 2, -1)]
        public void Calculation_InvalidData_Error(CalculatorType type, decimal p1, decimal p2)
        {
            CalculatorService service = new CalculatorService(new MockCalculatorFactory(), new MockCalculationLogger());
            var result = service.PerformCalculation(type, p1, p2);

            Assert.False(result.Success);
        }
    }
}
