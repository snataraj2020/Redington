using RedingtonCalculator.Domain.Calculation.Calculators;
using RedingtonCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RedingtonCalculator.DomainTests.Calculation.Calculators
{
    public class CombinedWithTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0.5, 0.5, 0.25)]
        [InlineData(0.25, 0.8, 0.2)]
        [InlineData(0, 0.666, 0)]
        public void Calculations_ValidData_CorrectValues(decimal p1, decimal p2, decimal output)
        {
            CombinedWith calculator = new CombinedWith();
            var input = new InputData(p1, p2);
            var result = calculator.Calculate(input);

            Assert.True(result.Success);
            Assert.Equal(output, result.Output);
        }
    }
}
