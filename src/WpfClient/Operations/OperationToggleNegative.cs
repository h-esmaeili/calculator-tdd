
namespace Calculator.Wpf.Operations
{
    public class OperationToggleNegative : IOperation
    {
        public State? Apply(State state)
        {
            return state.withText(_Toggle(state.Text));
        }

        public string _Toggle(string text)
        {
            if (text == null) { return "-"; }
            if (text.Length == 0) { return "-"; }

            string returnText = text;

            char firstChar = text.ToCharArray()[0];
            if (firstChar == '-')
            {
                returnText = text.Substring(1, text.Length - 1);
            }
            else
            {
                returnText = "-" + text;
            }

            return returnText;
        }
    }
}
