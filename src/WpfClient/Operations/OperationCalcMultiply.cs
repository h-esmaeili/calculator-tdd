
namespace TDDCalculator.WpfClient.Operations
{
    public class OperationCalcMultiply : OperationCalc
    {
        public OperationCalcMultiply()
        {
            Processor = (x, y) => { return CalcServiceAgent.Multiply($"{x},{y}"); };
        }
    }
}
