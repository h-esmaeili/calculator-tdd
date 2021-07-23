
namespace TDDCalculator.Domain
{
    public interface ICalculatorService
    {
        float Add(string calculation);
        float Subtract(string calculation);
        float Multiply(string calculation);
        float Divide(float param1, float param2);
        string SplitEq(float param1, float param2);
        float SplitNum(string calculation);
    }
}
