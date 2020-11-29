using RedingtonCalculator.Domain.Calculation;
using System.ComponentModel.DataAnnotations;

namespace RedingtonCalculator.Web.Models
{
    public class CalculationModel
    {
        [Required]
        public CalculatorType Type { get; set; }

        [Required]
        [Range(0, 1)]
        [Display(Name ="Probability 1")]
        public decimal Probability1 { get; set; }

        [Required]
        [Range(0, 1)]
        [Display(Name = "Probability 2")]
        public decimal Probability2 { get; set; }

        public decimal? Output { get; set; }
    }
}
