using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class Day3
    {
        /// <summary>
        /// Counts the target character encountered using the given right and down steps per iteration.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <param name="rightStep">The number of steps to go right in each iteration.</param>
        /// <param name="downStep">The number of steps to go down in each iteration.</param>
        /// <param name="targetChar">The target character.</param>
        /// <returns>
        /// Number of target characters
        /// </returns>

        public static int CountTargetCharacters(string[] lines, int rightStep, int downStep, char targetChar)
        {
            var x = rightStep;
            var y = downStep;
            var targetCount = 0;

            var stepsTried = 0;

            while (y < lines.Length) 
            {
                var currentLine = lines[y];
                while (x >= currentLine.Length -1)
                {
                    currentLine += lines[y];
                }

                //if (lines[y][x] == targetChar)
                if (currentLine[x] == targetChar)
                {
                    targetCount++;
                }

                x += rightStep;
                y += downStep;
                stepsTried++;
            }

            return targetCount;
        }
    }
}
