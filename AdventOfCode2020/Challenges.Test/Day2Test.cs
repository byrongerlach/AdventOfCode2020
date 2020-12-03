using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Challenges.Test
{
    [TestClass]
    public class Day2Test
    {
        /// <summary>
        /// Shows that GetValidPasswordByOccurrenceCount gets the correct number of valid passwords.
        /// </summary>
        [TestMethod]
        public void GetValidPasswordByOccurenceCount_ValidInput_ExpectCorrectCount()
        {
            // ARRANGE
            var lines = new[] { "1-3 a: abcde", 
                "1-3 b: cdefg", 
                "2-9 c: ccccccccc" };

            // ACT
            var actual = Day2.GetValidPasswordByOccurenceCount(lines);

            // ASSERT
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Shows that GetValidPasswordByPositionCount gets the correct number of valid passwords.
        /// </summary>
        [TestMethod]
        public void GetValidPasswordByPositionCount_ValidInput_ExpectCorrectCount()
        {
            // ARRANGE
            var lines = new[] { "1-3 a: abcde", 
                "1-3 b: cdefg", 
                "2-9 c: ccccccccc" };

            // ACT
            var actual = Day2.GetValidPasswordByPositionCount(lines);

            // ASSERT
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Executes to solve puzzle 2.
        /// </summary>
        [TestMethod]
        [DeploymentItem("InputFiles/Day2Input.txt")]
        public void GetValidPasswordCount_SolvePuzzle1()
        {
            // ARRANGE
            var lines = File.ReadAllLines(@"Day2Input.txt");

            // ACT
            var actual = Day2.GetValidPasswordByPositionCount(lines);

            // ASSERT
            Assert.IsTrue(actual > 0);
        }

        /// <summary>
        /// Executes to solve puzzle 1.
        /// </summary>
        [TestMethod]
        [DeploymentItem("InputFiles/Day2Input.txt")]
        public void GetValidPasswordCount_SolvePuzzle2()
        {
            // ARRANGE
            var lines = File.ReadAllLines(@"Day2Input.txt");

            // ACT
            var actual = Day2.GetValidPasswordByPositionCount(lines);

            // ASSERT
            Assert.IsTrue(actual > 0);
        }
    }
}
