using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenges
{

    /// <summary>
    /// Advent of Code 2020 Day 2: https://adventofcode.com/2020/day/2
    /// </summary>
    public class Day2
    {
        /// <summary>
        /// Gets the valid password count by occurence.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <returns></returns>
        public static int GetValidPasswordByOccurenceCount(IEnumerable<string> lines)
        {
            return lines.Select(l => new PasswordRule(l))
                .Where(pr => pr.IsValidByOccurence())
                .Count();
        }

        /// <summary>
        /// Gets the valid password count.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <returns></returns>
        public static int GetValidPasswordByPositionCount(IEnumerable<string> lines)
        {
            return lines.Select(l => new PasswordRule(l))
                .Where(pr => pr.IsValidByPosition())
                .Count();
        }

    }
}
