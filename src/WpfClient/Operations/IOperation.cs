
namespace TDDCalculator.WpfClient.Operations
{
    public interface IOperation
    {
        public abstract State? Apply(State state);
    }
}