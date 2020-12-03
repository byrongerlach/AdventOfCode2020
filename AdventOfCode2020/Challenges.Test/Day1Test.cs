using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Challenges.Test
{
    [TestClass]
    public class Day1Test
    {
        /// <summary>
        /// Show that FindProductOfTwo returns the two numbers that sum to 2020.
        /// </summary>
        [TestMethod]
        public void FindProductOfTwo_InputValid_ExpectCorrectSum()
        {
            // ARRANGE
            var numbers = new[] { 1721, 979, 366, 299, 675, 1456 };

            // ACT
            var actualProduct = Day1.FindProductOfTwo(numbers, 2020);

            // ASSERT
            var expectedProduct = 514579;

            Assert.AreEqual(expectedProduct, actualProduct);
        }

        /// <summary>
        /// Show that FindProductOfTwo returns -1 when the numbers are too large.
        /// </summary>
        [TestMethod]
        public void FindProductOfTwo_InputInvalid_ExpectFailureResult()
        {
            // ARRANGE
            var numbers = new[] { 2020, 100, 3000};

            // ACT
            var actual = Day1.FindProductOfTwo(numbers, 2020);

            // ASSERT
            var expected = -1;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Show that FindProductOfThree returns the product of three numbers that sum to 2020.
        /// </summary>
        [TestMethod]
        public void FindProductOfThree_InputValid_ExpectCorrectSum()
        {
            // ARRANGE
            var numbers = new[] { 1721, 979, 366, 299, 675, 1456 };

            // ACT
            var actualProduct = Day1.FindProductOfThree(numbers, 2020);

            // ASSERT
            var expectedProduct = 241861950;

            Assert.AreEqual(expectedProduct, actualProduct);
        }
       
        /// <summary>
        /// This test solves the Day1 puzzle.
        /// </summary>
        [TestMethod]
        [DeploymentItem ("InputFiles/Day1Input.txt")]
        public void Find2020Product_SolvePuzzle()
        {
            // ARRANGE
            var numbers = File
                .ReadAllLines(@"Day1Input.txt")
                .Select(l=> System.Convert.ToInt32(l)); 

            // ACT
            var actual = Day1.FindProductOfTwo(numbers, 2020);

            // ASSERT
            Assert.IsTrue(actual > -1);
        }

        /// <summary>
        /// This test solves the Day1 puzzle 2.
        /// </summary>
        [TestMethod]
        [DeploymentItem ("InputFiles/Day1Input.txt")]
        public void FindProductOfThree_SolvePuzzle()
        {
            // ARRANGE
            var numbers = File
                .ReadAllLines(@"Day1Input.txt")
                .Select(l=> System.Convert.ToInt32(l)); 

            // ACT
            var actual = Day1.FindProductOfThree(numbers, 2020);

            // ASSERT
            Assert.IsTrue(actual > -1);
        }
    }
}
