
namespace Calculator.Wpf.Operations
{
    public class OperationAppendText : IOperation
    {
        public string Text { get; private set; }

        public OperationAppendText(string text)
        {
            this.Text = text;
        }

        public State? Apply(State state)
        {
            /* remove 0 if that is what is being displayed */
            string prependText = state.Text;
            if (prependText == "0")
            {
                prependText = "";
            }
            else if (prependText == "-0")
            {
                prependText = "-";
            }

            return state.withText(prependText + Text);
        }
    }
}