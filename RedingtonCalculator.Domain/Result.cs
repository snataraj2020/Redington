using System.Collections.Generic;

namespace RedingtonCalculator.Domain
{
    public interface IResult
    {
        bool Success { get; }
        IEnumerable<string> Errors { get; }
    }

    internal class Result : IResult
    {
        private List<string> _errors = new List<string>();
        public bool Success { get { return _errors.Count == 0; } }
        public IEnumerable<string> Errors { get { return _errors; } }

        public void AppendError(string error)
        {
            _errors.Add(error);
        }

        public void AppendResult(IResult result)
        {
            if (result != null)
            {
                _errors.AddRange(result.Errors);
            }
        }
    }
}
