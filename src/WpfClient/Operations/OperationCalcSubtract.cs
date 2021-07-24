
namespace TDDCalculator.WpfClient.Operations
{
    public class OperationCalcSubtract : OperationCalc
    {
        public OperationCalcSubtract()
        {
            Processor = (x, y) => { return CalcServiceAgent.Subtract($"{x},{y}"); };
        }
    }
}
