
namespace TDDCalculator.WpfClient.Operations
{
    public class OperationAddDotText : IOperation
    {
        public State Apply(State state)
        {
            if (state.Text.Contains(".")) { return null; }
            return state.withText(state.Text + ".");
        }
    }
}
