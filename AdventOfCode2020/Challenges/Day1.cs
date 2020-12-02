using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    /// <summary>
    /// Advent of Code 2020 Day 1: https://adventofcode.com/2020/day/1
    /// 
    /// </summary>
    public class Day1
    {
        /// <summary>
        // Find the product of a pair of numbers that sum to targetSumValue.
        /// </summary>
        /// <param name="numbers">The numbers to add.</param>
        /// <param name="targetSumValue">The target sum value.</param>
        /// <returns>The product, or -1 if there's no valid pair found.</returns>
        public static int Find2020Product(IEnumerable<int> numbers, int targetSumValue)
        {
            // Sort so we can skip numbers that are too large
            var sortedNumbers = numbers.OrderByDescending(n => n).ToArray();

            for (var i = 0; i < sortedNumbers.Length; i++)
            {
                // skip numbers that are too large
                if (sortedNumbers[i] >= targetSumValue)
                    continue;

                // Sum the numbers to see if they match the target value.
                for (var j = i+1; j < sortedNumbers.Length; j++)
                {
                    if (sortedNumbers[i] + sortedNumbers[j] == targetSumValue)
                    {
                        return  sortedNumbers[i] * sortedNumbers[j];
                    }
                }
            }

            // No pair found
            return -1;
        }
    }
}
