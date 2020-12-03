using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Challenges.Test
{
    /// <summary>
    /// Tests for Day3
    /// </summary>
    [TestClass]
    public class Day3Test
    {
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        /// Shows the CountTargetCharacters returns the correct target count.
        /// </summary>
        [TestMethod]
        [DeploymentItem("InputFiles/Day3Problem1InputExample.txt")]
        public void CountTargetCharacters_ValidInput_ExpectCorrectCount()
        {
            // ARRANGE 
            var lines = File.ReadAllLines(@"Day3Problem1InputExample.txt");

            // ACT 
            var actual = Day3.CountTargetCharacters(lines, 3, 1, '#');

            // ASSERT 
            Assert.AreEqual(7, actual);

        }

        [TestMethod]
        [DeploymentItem("InputFiles/Day3Problem1Input.txt")]
        public void SolveProblem1()
        {
            // ARRANGE 
            var lines = File.ReadAllLines(@"Day3Problem1Input.txt");

            // ACT 
            var actual = Day3.CountTargetCharacters(lines, 3, 1, '#');

            // Output the result
            TestContext.WriteLine($"Day 3 Problem 1: Found {actual} tree characters.");
        }

        [TestMethod]
        [DeploymentItem("InputFiles/Day3Problem1Input.txt")]
        public void SolveProblem2()
        {
            // ARRANGE 
            var lines = File.ReadAllLines(@"Day3Problem1Input.txt");

            // ACT 
            var actual = Day3.CountTargetCharacters(lines, 1, 1, '#') *
            Day3.CountTargetCharacters(lines, 3, 1, '#') *
            Day3.CountTargetCharacters(lines, 5, 1, '#') *
            Day3.CountTargetCharacters(lines, 7, 1, '#') *
            Day3.CountTargetCharacters(lines, 1, 2, '#');

            // Output the result
            TestContext.WriteLine($"Day 3 Problem 2: Found {actual} tree characters.");
        }

    }
}
