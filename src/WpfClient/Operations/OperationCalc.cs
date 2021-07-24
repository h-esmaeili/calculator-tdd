using TDDCalculator.WpfClient.ServiceAgent;
using System;

namespace TDDCalculator.WpfClient.Operations
{
    using Processor = Func<float, float, string>;
    public abstract class OperationCalc : IOperation
    {
        protected Processor Processor { get; set; } = (a, b) => "";
        protected ICalcServiceAgent CalcServiceAgent;
        public OperationCalc()
        {
            CalcServiceAgent = new CalcServiceAgent();
        }
        public State Apply(State state)
        {
            if (state.Text.Length == 0) { return null; }
            State newState = new OperationCalcEquals().Apply(state);

            if (newState == null)
            {
                newState = new State(
                    accumulator: float.Parse(state.Text),
                    processor: this.Processor,
                    text: "");
            }

            return newState;
        }
    }
}
