
namespace TDDCalculator.WpfClient.ServiceAgent
{
    public interface ICalcServiceAgent
    {
        string Add(string calculation);
        string Subtract(string calculation);
        string Multiply(string calculation);
        string Divide(float param1, float param2);
        string SplitEq(float param1, float param2);
        string SplitNum(string calculation);
    }
}
