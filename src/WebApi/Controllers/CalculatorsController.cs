using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDDCalculator.Domain;
using TDDCalculator.WebApi.Models;

namespace TDDCalculator.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public int Add([FromBody] AddRequest request)
        {
            var result = _calculatorService.Add(request.Calculation);

            return result;
        }

        /// <summary>
        /// Takes two or more parameters and returns the subtraction of the numbers
        /// </summary>
        [HttpPost("Subtract")]
        public int Subtract([FromBody]SubtractRequest request)
        {
            int result = _calculatorService.Subtract(request.Calculation);
            
            return result;
        }

        /// <summary>
        /// Takes two or more parameters and returns the multiplication
        /// </summary>
        [HttpPost("Multiply")]
        public int Multiply([FromBody] MultiplyRequest request)
        {
            int result = _calculatorService.Multiply(request.Calculation);

            return result;
        }

        /// <summary>
        /// Takes two parameters and returns the division
        /// </summary>
        [HttpPost("Divide")]
        public int Divide([FromBody] DivideRequest request)
        {
            var result = _calculatorService.Divide(request.Param1, request.Param2);

            return result;
        }

        /// <summary>
        /// Takes two parameters and return the split of param1, param2 times
        /// </summary>
        [HttpPost("SplitEq")]
        public string SplitEq([FromBody] SplitEqRequest request)
        {
            var result = _calculatorService.SplitEq(request.Param1, request.Param2);

            return result;
        }

        /// <summary>
        /// Takes two or more parameters and returns the remainder
        /// </summary>
        [HttpPost("SplitNum")]
        public int SplitNum([FromBody] SplitNumRequest request)
        {
            var result = _calculatorService.SplitNum(request.Calculation);

            return result;
        }
    }
}