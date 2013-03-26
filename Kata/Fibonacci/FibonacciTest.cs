using NUnit.Framework;

namespace Kata.Fibonacci
{
    [TestFixture]
    public class FibonacciTest
    {
        [Test]
        public void Run_Under100_Returns42()
        {
            var fib = new Fibonacci();

            var response = fib.Run(100);

            Assert.AreEqual(44, response);
        }

        [Test]
        public void Run_Under4Million_Returns4613732()
        {
            var fib = new Fibonacci();

            var response = fib.Run(4000000);

            Assert.AreEqual(4613732, response);
        }
    }
}
