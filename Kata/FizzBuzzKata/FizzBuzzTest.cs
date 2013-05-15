using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Kata.FizzBuzzKata
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [Test]
        public void WhenDivisibleByThree_ReturnsFizz()
        {
            // arrange
            var fb = new FizzBuzz();

            // act
            var response = fb.Answer(15);

            //assert
            Assert.AreEqual(4, response.Count(r => r == "Fizz"));
        }

        [Test]
        public void WhenDivisibleByFive_ReturnsBuzz()
        {
            var fb = new FizzBuzz();

            var response = fb.Answer(15);

            Assert.AreEqual(2, response.Count(r => r == "Buzz"));
        }
        
        [Test]
        public void WhenDivisibleByFifteen_ReturnsFizzBuzz()
        {
            var fb = new FizzBuzz();

            var response = fb.Answer(15);

            Assert.AreEqual(1, response.Count(r => r == "FizzBuzz"));
        }
        
    }

    public class FizzBuzz
    {
        public List<string> Answer(int upperRange)
        {
            var response = new List<string>();
            var combinations = new List<Tuple<int, string>> 
                                   {
                                       new Tuple<int, string>(3, "Fizz"),
                                       new Tuple<int, string>(5, "Buzz"),
                                       new Tuple<int, string>(15, "FizzBuzz")
                                   };

            Func<int, int, bool> isMatch = (i, j) => (i % j) == 0;

            for (var i = 0; i < upperRange; i++)
            {
                var match = combinations.Where(c => isMatch(i, c.Item1))
                    .Select(c => c.Item2)
                    .OrderByDescending(o => o.Length)
                    .FirstOrDefault();

                response.Add(match);
            }
            return response;
        }
    }
}
