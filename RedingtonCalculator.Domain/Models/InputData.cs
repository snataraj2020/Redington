using RedingtonCalculator.Domain.Properties;

namespace RedingtonCalculator.Domain.Models
{
    public interface IInputData
    {
        decimal Probability1 { get; }
        decimal Probability2 { get; }

        IResult Validate();
    }

    public class InputData : IInputData
    {
        public decimal Probability1 { get; set; }
        public decimal Probability2 { get; set; }

        public InputData(decimal probability1, decimal probability2)
        {
            Probability1 = probability1;
            Probability2 = probability2;
        }

        public IResult Validate()
        {
            var result = new Result();

            if (this.Probability1 > 1 || this.Probability1 < 0 ||
                this.Probability2 > 1 || this.Probability2 < 0)
            {
                result.AppendError(Resources.InputData_ProbabilityValue_Invalid);
            }

            return result;
        }
    }
}
