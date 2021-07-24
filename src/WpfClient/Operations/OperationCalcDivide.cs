
namespace TDDCalculator.WpfClient.Operations
{
    public class OperationCalcDivide : OperationCalc
    {
        public OperationCalcDivide()
        {
            Processor = (x, y) => { return CalcServiceAgent.Divide(x, y); };
        }
    }
}
