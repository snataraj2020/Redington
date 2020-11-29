using RedingtonCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RedingtonCalculator.DomainTests.Calculation.Calculators
{
    public class InputDataTests
    {
        #region Happy Day Scenarios

        [Theory]
        [InlineData(0)]
        [InlineData(0.00000000001)]
        [InlineData(0.5)]
        [InlineData(0.99999999999)]
        [InlineData(1)]
        public void Probability1_Valid_Success(decimal x)
        {
            InputData data = new InputData(x, 0.5m);

            var result = data.Validate();

            Assert.True(result.Success);
            Assert.True(result.Errors.Count() == 0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.00000000001)]
        [InlineData(0.5)]
        [InlineData(0.99999999999)]
        [InlineData(1)]
        public void Probability2_Valid_Success(decimal x)
        {
            InputData data = new InputData(0.5m, x);

            var result = data.Validate();

            Assert.True(result.Success);
            Assert.True(result.Errors.Count() == 0);
        }
        #endregion

        #region Error Scenarios
        [Theory]
        [InlineData(-0.0000000001)]
        [InlineData(-1)]
        [InlineData(-9999999999)]
        [InlineData(1.00000000001)]
        [InlineData(2)]
        [InlineData(9999999999)]
        public void Probability1_Invalid_Error(decimal x)
        {
            InputData data = new InputData(x, 0.5m);
            data.Probability1 = x;

            var result = data.Validate();

            Assert.False(result.Success);
            Assert.True(result.Errors.Count() == 1);
        }

        [Theory]
        [InlineData(-0.0000000001)]
        [InlineData(-1)]
        [InlineData(-9999999999)]
        [InlineData(1.00000000001)]
        [InlineData(2)]
        [InlineData(9999999999)]
        public void Probability2_Invalid_Error(decimal x)
        {
            InputData data = new InputData(0.5m, x);
            data.Probability2 = x;

            var result = data.Validate();

            Assert.False(result.Success);
            Assert.True(result.Errors.Count() == 1);
        }
        #endregion
    }
}
