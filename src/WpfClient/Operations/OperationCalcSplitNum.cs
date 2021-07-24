﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
