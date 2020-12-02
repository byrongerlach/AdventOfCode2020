using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenges.Test
{
    [TestClass]
    public class Day1Test
    {
        /// <summary>
        /// Show that Find2020SumNumbers returns the two numbers that sum to 2020.
        /// </summary>
        [TestMethod]
        public void Find2020Product_InputValid_ExpectCorrectSum()
        {
            // ARRANGE
            var numbers = new[] { 1721, 979, 366, 299, 675, 1456 };

            // ACT
            var actualProduct = Day1.Find2020Product(numbers, 2020);

            // ASSERT
            var expectedProduct = 514579;

            Assert.AreEqual(expectedProduct, actualProduct);
        }

        /// <summary>
        /// Show that Find2020Product returns -1 when the numbers are too large.
        /// </summary>
        [TestMethod]
        public void Find2020Product_InputInvalid_ExpectFailureResult()
        {
            // ARRANGE
            var numbers = new[] { 2020, 100, 3000};

            // ACT
            var actual = Day1.Find2020Product(numbers, 2020);

            // ASSERT
            var expected = -1;

            Assert.AreEqual(expected, actual);
        }
    }
}
