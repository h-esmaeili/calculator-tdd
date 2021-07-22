
namespace TDDCalculator.Domain
{
    public interface ICalculatorService
    {
        int Add(string calculation);
        int Subtract(string calculation);
        int Multiply(string calculation);
        int Divide(int param1, int param2);
        string SplitEq(int param1, int param2);
        int SplitNum(string calculation);
    }
}
