
namespace TDDCalculator.WpfClient.Operations
{
    public class OperationCalcSplitEq : OperationCalc
    {
        public OperationCalcSplitEq()
        {
            Processor = (x, y) => { return CalcServiceAgent.SplitEq(x, y); };
        }
    }
}
