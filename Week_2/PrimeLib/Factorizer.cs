using System.Collections.Generic;

namespace PrimeLib
{
    public class Factorizer
    {
        public static string PrimeFactors(int number)
        {
            List<int> factors = new List<int>();
            int divisor = 2;

            while (number > 1)
            {
                if (number % divisor == 0)
                {
                    factors.Add(divisor);
                    number /= divisor;
                }
                else
                {
                    divisor++;
                }
            }

            return string.Join(" x ", factors);
        }
    }
}
