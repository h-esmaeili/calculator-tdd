using System;
using System.Linq;

namespace TDDCalculator.Domain
{
    public sealed class Calculator
    {
        public Calculator()
        {

        }
        public int Add(string numbers)
        {
            var delimiters = new char[] { ',', '\n' };

            var splitNumbers =
                numbers
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var negativeNumbers = splitNumbers.Where(x => x < 0).ToArray();

            if (negativeNumbers.Any())
                throw new Exception("Negatives not allowed: " + string.Join(",", negativeNumbers));

            return splitNumbers.Sum();
        }

        public int Subtract(string numbers)
        {
            var delimiters = new char[] { ',', '\n' };

            var splitNumbers =
                numbers
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            if (!splitNumbers.Any())
                return 0;

            var result = splitNumbers[0];

            for (int index = 1; index < splitNumbers.Length; index++)
            {
                result -= splitNumbers[index];
            }

            return result;
        }

        public int Multiple(string numbers)
        {
            var delimiters = new char[] { ',', '\n' };

            var splitNumbers =
                numbers
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            if (!splitNumbers.Any())
                return 0;

            var result = splitNumbers[0];

            for (int index = 1; index < splitNumbers.Length; index++)
            {
                result *= splitNumbers[index];
            }

            return result;
        }

        public int Divide(int param1, int param2)
        {
            if (param2 == 0)
                throw new DivideByZeroException("Zero not allowed: " + param2);

            var result = param1 / param2;

            return result;
        }
       
        public string SplitEq(int param1, int param2)
        {
            int z = param1 / param2;
            int remain = param1 % param2;
            string result = "{";
            for (int i = 1; i <= param2; i++)
            {
                result += $"{z}";

                if (i < param2)
                    result += ", ";
                else if (remain > 0)
                    result += $", {remain}";
                else
                    result += "}";
            }
            return result;
        }

        public int SplitNum(string numbers)
        {
            var delimiters = new char[] { ',', '\n' };

            var splitNumbers =
                numbers
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            if (!splitNumbers.Any())
                return 0;

            var result = splitNumbers[0];

            for (int index = 1; index < splitNumbers.Length; index++)
            {
                result -= splitNumbers[index];
            }

            return result;
        }
    }
}
