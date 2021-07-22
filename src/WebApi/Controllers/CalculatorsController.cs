using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDDCalculator.Domain;

namespace TDDCalculator.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorsController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        private readonly ILogger<CalculatorsController> _logger;

        public CalculatorsController(ICalculatorService calculatorService, ILogger<CalculatorsController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }

        /// <summary>
        /// Takes two or more parameters and returns the sum of all the numbers
        /// </summary>
        [HttpPost("Add")]
        public int Add(string calculation)
        {
            var result = _calculatorService.Add(calculation);

            return result;
        }

        /// <summary>
        /// Takes two or more parameters and returns the subtraction of the numbers
        /// </summary>
        [HttpPost("Subtract")]
        public int Subtract(string calculation)
        {
            int result = _calculatorService.Subtract(calculation);
            
            return result;
        }

        /// <summary>
        /// Takes two or more parameters and returns the multiplication
        /// </summary>
        [HttpPost("Multiply")]
        public int Multiply(string calculation)
        {
            int result = _calculatorService.Multiply(calculation);

            return result;
        }

        /// <summary>
        /// Takes two parameters and returns the division
        /// </summary>
        [HttpPost("Divide")]
        public int Divide(int param1, int param2)
        {
            var result = _calculatorService.Divide(param1, param2);

            return result;
        }

        /// <summary>
        /// Takes two parameters and return the split of param1, param2 times
        /// </summary>
        [HttpPost("SplitEq")]
        public string SplitEq(int param1, int param2)
        {
            var result = _calculatorService.SplitEq(param1, param2);

            return result;
        }

        /// <summary>
        /// Takes two or more parameters and returns the remainder
        /// </summary>
        [HttpPost("SplitNum")]
        public int SplitNum(string calculation)
        {
            var result = _calculatorService.SplitNum(calculation);

            return result;
        }
    }
}