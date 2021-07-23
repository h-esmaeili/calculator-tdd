using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Wpf.Operations
{
    public class OperationCalcSplitEq : OperationCalc
    {
        public OperationCalcSplitEq()
        {
            Processor = (x, y) => { return CalcServiceAgent.SplitEq(x, y); };
        }
    }
}
