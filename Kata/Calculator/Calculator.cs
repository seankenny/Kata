using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public static class Calculator
    {
        static string delimiter;

        public static int Add(string input)
        {
            ParseDelimiter(input);

            var numbers = ParseNumbersToInts(input);

            numbers = RemoveAllNumbersGreater1000(numbers);

            ValidateNumbersArePositive(numbers);

            return numbers.Sum(number => Convert.ToInt32(number));
        }

        private static void ValidateNumbersArePositive(IEnumerable<int> numbers)
        {
            if (numbers.Any(n => n < 0))
            {
                throw new NumberNotPositiveException(string.Format("Negatives not allowed - {0}", string.Join(",", numbers.Where(p => p < 0))));
            }
        }

        private static void ParseDelimiter(string numbersAsString)
        {
            if (numbersAsString.Contains("//["))
            {
                delimiter = numbersAsString.Substring(3, numbersAsString.IndexOf("]") - 3);
            }
            else
            {
                delimiter = ",";
            }
        }

        private static IEnumerable<int> RemoveAllNumbersGreater1000(IEnumerable<int> numbers)
        {
            return numbers.Where(n => n <= 1000).ToList();
        }

        private static IEnumerable<int> ParseNumbersToInts(string numbersAsString)
        {
            numbersAsString = ParseNewLineFromNumbersAsString(numbersAsString);

            numbersAsString = ParseDelimitersFromNumbersString(numbersAsString);

            var numberList = numbersAsString.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            return numberList.Select(p => Convert.ToInt32(p));
        }

        private static string ParseNewLineFromNumbersAsString(string numbersAsString)
        {
            return numbersAsString.Replace("\n", string.Empty);
        }

        private static string ParseDelimitersFromNumbersString(string numbersAsString)
        {
            return numbersAsString.Replace("//[", string.Empty).Replace("]", string.Empty);
        }
    }

    internal class NumberNotPositiveException : ApplicationException
    {
        public NumberNotPositiveException(string message)
            : base(message)
        {
        }
    }
}