
namespace Calculator.Wpf.Operations
{
    public class OperationCalcMultiply : OperationCalc
    {
        public OperationCalcMultiply()
        {
            Processor = (x, y) => { return CalcServiceAgent.Multiply($"{x},{y}"); };
        }
    }
}
