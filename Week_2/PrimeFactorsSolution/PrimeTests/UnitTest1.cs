using NUnit.Framework;
using PrimeLib;

namespace PrimeTests
{
    public class Tests
    {
        [TestCase(4, "2 x 2")]
        [TestCase(7, "7")]
        [TestCase(30, "2 x 3 x 5")]
        [TestCase(40, "2 x 2 x 2 x 5")]
        [TestCase(50, "2 x 5 x 5")]
        public void TestPrimeFactors(int input, string expected)
        {
            Assert.AreEqual(expected, Factorizer.PrimeFactors(input));
        }
    }
}
