
namespace Calculator.Wpf.Operations
{
    public interface IOperation
    {
        public abstract State? Apply(State state);
    }
}