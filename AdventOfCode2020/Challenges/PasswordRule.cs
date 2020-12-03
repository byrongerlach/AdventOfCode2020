using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Challenges
{
    public class PasswordRule
    {
        public string Password { get; }
        public int MinOccurrence { get; }
        public int MaxOccurrence { get; }

        public string RecurringToken { get; }

        /// <summary>
        /// True if the rule input line is valid.
        /// </summary>
        public bool ValidInput { get; }

        public PasswordRule(string ruleLine)
        {
            ValidInput = true;
            var lineTokens = ruleLine.Split(':');

            // Check for invalid input
            if (lineTokens.Count() != 2)
                ValidInput = false;

            var rule = lineTokens[0].TrimStart().TrimEnd();
            var ruleTokens = rule.Split(' ');

            // Check for invalid input
            if (ruleTokens.Count() != 2)
                ValidInput = false;

            var ruleRange = ruleTokens[0];

            var ruleRangeTokens = ruleRange.Split('-');

            MinOccurrence = Convert.ToInt32(ruleRangeTokens[0]); 
            MaxOccurrence = Convert.ToInt32(ruleRangeTokens[1]); 

            RecurringToken = ruleTokens[1];

            Password = lineTokens[1].TrimStart().TrimEnd();
        }

        /// <summary>
        /// Checks to see if the recurring token position is correct.
        /// </summary>
        public bool IsValidByPosition()
        {
            var token = Convert.ToChar(RecurringToken);
            var minPosition = MinOccurrence - 1;
            var maxPosition = MaxOccurrence - 1;

            var found = false;

            if (Password.Length >= minPosition + 1 && Password[minPosition] == token)
                found = true;

            return (found ^ (Password.Length >= maxPosition + 1 && Password[maxPosition] == token));
        }

        /// <summary>
        /// Checks to see if the recurring token frequency is correct.
        /// </summary>
        public bool IsValidByOccurence()
        {
            var tokenCount = Regex.Matches(Password, RecurringToken.ToString()).Count;
            if (tokenCount < MinOccurrence || tokenCount > MaxOccurrence)
                return false;

            return true;
        }
    }
}
