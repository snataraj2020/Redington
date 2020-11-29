using RedingtonCalculator.Domain.Calculation.Calculators;
using RedingtonCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RedingtonCalculator.DomainTests.Calculation.Calculators
{
    public class EitherTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0.5, 0.5, 0.75)]
        [InlineData(0.25, 0.8, 0.85)]
        [InlineData(0, 0.666, 0.666)]
        public void Calculations_ValidData_CorrectValues(decimal p1, decimal p2, decimal output)
        {
            Either calculator = new Either();
            var input = new InputData(p1, p2);
            var result = calculator.Calculate(input);

            Assert.True(result.Success);
            Assert.Equal(output, result.Output);
        }
    }
}
