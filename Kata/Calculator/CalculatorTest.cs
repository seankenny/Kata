using NUnit.Framework;

namespace Kata
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            var result = Calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [TestCase("1", 1)]
        [TestCase("3", 3)]
        public void Add_SingleNumber_ReturnsResultAsInt(string testCase, int expectedResult)
        {
            var result = Calculator.Add(testCase);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1,2", 3)]
        [TestCase("1,3", 4)]
        public void Add_TwoNumbers_ReturnsSum(string testCase, int expectedResult)
        {
            var result = Calculator.Add(testCase);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1,2,3,4", 10)]
        [TestCase("1,2,3,4,5", 15)]
        public void Add_MultipleNumbers_ReturnsSum(string testCase, int expectedResult)
        {
            var result = Calculator.Add(testCase);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Add_UsingNewLine_ReturnsSum()
        {
            var result = Calculator.Add("1\n,2");

            Assert.AreEqual(3, result);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[yabababa]\n1yabababa2yabababa4", 7)]
        public void Add_UsingDelimiters_ReturnsSum(string testCase, int expectedResult)
        {
            var result = Calculator.Add(testCase);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1, -1, -2", "-1,-2")]
        [TestCase("1, -1, -4, 5", "-1,-4")]
        public void Add_NegativeNumber_ThrowsExceptionWithNegativeNumber(string testCase, string expectedResult)
        {
            var exception = Assert.Throws<NumberNotPositiveException>(() => Calculator.Add(testCase));
            Assert.AreEqual(string.Format("Negatives not allowed - {0}", expectedResult), exception.Message);
        }

        [TestCase("5, 1001", 5)]
        [TestCase("5, 1000", 1005)]
        [TestCase("5, 1001, 8", 13)]
        public void Add_NumbersLargerThan1000_AreIgnoredFromSum(string testCase, int expectedResult)
        {
            var result = Calculator.Add(testCase);
            Assert.AreEqual(expectedResult, result);
        }
    }
}