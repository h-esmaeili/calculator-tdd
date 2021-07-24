
namespace TDDCalculator.WpfClient.Operations
{
    public class OperationCalcSplitNum : OperationCalc
    {
        public OperationCalcSplitNum()
        {
            Processor = (x, y) => { return CalcServiceAgent.SplitNum($"{x},{y}"); };
        }
    }
}
