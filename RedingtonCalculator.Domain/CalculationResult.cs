using RedingtonCalculator.Domain.Models;
using System;
using System.Collections.Generic;

namespace RedingtonCalculator.Domain
{
    public interface ICalculationResult : IResult
    {
        IInputData InputData { get; }
        decimal? Output { get; }
    }

    internal class CalculationResult : Result, ICalculationResult
    {
        private List<string> _errors = new List<string>();

        public DateTime CalculationDate { get; } = DateTime.Now;
        public IInputData InputData { get; private set; }
        public decimal? Output { get; set; }

        public CalculationResult(IInputData inputData, decimal? output = null)
        {
            this.InputData = inputData;
            this.Output = output;
        }
    }
}
