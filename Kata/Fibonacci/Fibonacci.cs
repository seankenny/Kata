using System.Collections.Generic;

namespace Kata.Fibonacci
{
    public class Fibonacci
    {
        public int Run(int limit)
        {
            var response = 2;

            var index = 1;
            var numbers = new List<int> { 1, 2 };

            do
            {
                index++;

                var nextNumber = numbers[index - 2] + numbers[index - 1];
                numbers.Add(nextNumber);

                if (nextNumber % 2 == 0 && nextNumber <= limit)
                {
                    response = response + nextNumber;
                }
            }
            while (numbers[index] <= limit);

            return response;
        }
    }
}
