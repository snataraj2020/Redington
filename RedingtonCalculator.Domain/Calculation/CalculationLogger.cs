using Newtonsoft.Json;
using System;
using System.IO;

namespace RedingtonCalculator.Domain.Calculation
{
    public interface ICalculationLogger
    {
        void LogCalculation(ICalculationResult result);
    }

    public class CalculationLoggerOptions
    {
        public string FilePath { get; set; }
    }

    public class CalculationLogger : ICalculationLogger
    {
        private static readonly object _SyncLock = new object();

        public void LogCalculation(ICalculationResult result)
        {
            string calculation = JsonConvert.SerializeObject(result, Formatting.None);

            lock (_SyncLock)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "CalculationHistory.txt");
                File.AppendAllText(filePath, calculation + Environment.NewLine);
            }
        }
    }
}
