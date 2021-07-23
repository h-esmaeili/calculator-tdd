using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Wpf.Operations
{
    public class OperationCalcAdd : OperationCalc
    {
        public OperationCalcAdd()
        {
            Processor = (x, y) => { return CalcServiceAgent.Add($"{x},{y}"); };
        }
    }
}
