using Microsoft.Extensions.DependencyInjection;
using RedingtonCalculator.Domain.Calculation;

namespace RedingtonCalculator.Domain
{
    public static class StartupExtensions
    {
        public static void RegisterCalculationService(this IServiceCollection services)
        {
            services.AddSingleton<ICalculationLogger, CalculationLogger>();
            services.AddSingleton<ICalculatorService, CalculatorService>();
        }

        public static void RegisterStandardCalculators(this IServiceCollection services)
        {
            services.AddSingleton<Calculation.Calculators.CombinedWith>();
            services.AddSingleton<Calculation.Calculators.Either>();
            services.AddSingleton<ICalculatorFactory, CalculatorFactory>();
        }
    }
}
