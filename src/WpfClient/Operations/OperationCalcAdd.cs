
namespace TDDCalculator.WpfClient.Operations
{
    public class OperationCalcAdd : OperationCalc
    {
        public OperationCalcAdd()
        {
            Processor = (x, y) => { return CalcServiceAgent.Add($"{x},{y}"); };
        }
    }
}
