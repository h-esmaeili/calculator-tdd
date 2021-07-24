
namespace TDDCalculator.WpfClient.Operations
{
    public class OperationCalcEquals : IOperation
    {
        public State Apply(State state)
        {
            if (state.Accumulator == null) { return null; }
            if (state.Processor == null) { return null; }

            if (state.Text.Length == 0)
            {
                return state
                    .withText($"{ state.Accumulator }");
            }
            else if (!state.HasExecuted)
            {
                float userInputValue = float.Parse(state.Text);

                float oldAccumulator = state.Accumulator ?? 0;

                string newValue = state.Processor(oldAccumulator, userInputValue);

                return state
                    .withHasExecuted(true)
                    .withAccumulator(userInputValue)
                    .withText($"{ newValue }");
            }
            else if (state.HasExecuted)
            {
                float userInputValue = float.Parse(state.Text);

                float oldAccumulator = state.Accumulator ?? 0;

                string newValue = state.Processor(userInputValue, oldAccumulator);

                return state
                    .withText($"{ newValue }");
            }
            else
            {
                return null;
            }
        }
    }
}
