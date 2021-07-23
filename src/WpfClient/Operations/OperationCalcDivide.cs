using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Wpf.Operations
{
    public class OperationCalcDivide : OperationCalc
    {
        public OperationCalcDivide()
        {
            Processor = (x, y) => { return CalcServiceAgent.Divide(x, y); };
        }
    }
}
