
namespace TDDCalculator.WpfClient.Operations
{
    public class OperationClear : IOperation
    {
        public State? Apply(State state)
        {
            bool _IsClear(State state)
            {
                bool isTextClear = state.Text == null || state.Text.Length == 0;
                return isTextClear && state.Accumulator == null;
            }
            if (_IsClear(state)) { return null; }
            return new State();
        }
    }
}
