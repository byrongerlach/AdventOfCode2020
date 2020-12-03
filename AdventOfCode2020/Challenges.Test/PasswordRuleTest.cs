using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges.Test
{
    [TestClass]
    public class PasswordRuleTest
    {
        [TestMethod]
        public void PasswordRuleConstructor_ValidInput_ExpectCorrectPasswordRule()
        {
            // ARRANGE
            var ruleLine = @"10-11 k: jrktpgkvkqk";

            // ACT
            var actual = new PasswordRule(ruleLine);

            // ASSERT
            Assert.AreEqual(10, actual.MinOccurrence);
            Assert.AreEqual(11, actual.MaxOccurrence);
            Assert.AreEqual("k", actual.RecurringToken);
            Assert.AreEqual("jrktpgkvkqk", actual.Password);
        }
    }
}
