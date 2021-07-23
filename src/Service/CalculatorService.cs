using Microsoft.Extensions.Logging;
using TDDCalculator.Domain;

namespace TDDCalculator.Service
{
    public sealed class CalculatorService : ICalculatorService
    {
        private readonly ILogger<CalculatorService> _logger;
       
        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
        }

        public float Add(string calculation)
        {
            var calc = new Calculator();
            _logger.LogDebug("Request of add, request = {@calculation}", calculation);

            var result = calc.Add(calculation);
            _logger.LogDebug("Result of request {@result}", result);

            return result;
        }

        public float Subtract(string calculation)
        {
            var calc = new Calculator();
            _logger.LogDebug("Request of subtract, request = {@calculation}", calculation);

            var result = calc.Subtract(calculation);
            _logger.LogDebug("Result of request {@result}", result);

            return result;
        }

        public float Multiply(string calculation)
        {
            var calc = new Calculator();
            _logger.LogDebug("Request of multiply, request = {@calculation}", calculation);

            var result = calc.Multiple(calculation);
            _logger.LogDebug("Result of request {@result}", result);

            return result;
        }

        public float Divide(float param1, float param2)
        {
            var calc = new Calculator();
            _logger.LogDebug("Request of divide, request = {@param1}, {@param2}", param1, param2);

            var result = calc.Divide(param1, param2);
            _logger.LogDebug("Result of request {@result}", result);

            return result;
        }

        public string SplitEq(float param1, float param2)
        {
            var calc = new Calculator();
            _logger.LogDebug("Request of splitEq, request = {@param1}, {@param2}", param1, param2);

            var result = calc.SplitEq(param1, param2);
            _logger.LogDebug("Result of request {@result}", result);

            return result;
        }

        public float SplitNum(string calculation)
        {
            var calc = new Calculator();
            _logger.LogDebug("Request of splitNum, request = {@calculation}", calculation);

            var result = calc.SplitNum(calculation);
            _logger.LogDebug("Result of request {@result}", result);

            return result;
        }
    }
}
