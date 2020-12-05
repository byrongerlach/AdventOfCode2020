using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Challenges.Test
{
    [TestClass]
    public class Day4Test
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

        [TestMethod]
        [DeploymentItem("InputFiles/Day4Problem1InputExample.txt")]
        public void GetPassports_InputValid_ExpectCorrectPassports()
        {
            // ARRANGE
            var lines = File.ReadAllLines(@"Day4Problem1InputExample.txt");

            // ACT
            var actual = Day4.GetPassports(lines);

            // ASSERT
            Assert.AreEqual(4, actual.Count());
        }

        /// <summary>
        /// Shows that we can get the passport fields from the 
        /// data lines.
        /// </summary>
        /// <param name="lines"></param>
        [TestMethod]
        public void GetPassportFields_ValidInput_ExpectCorrectFields()
        {
            // ARRANGE
             var lines = new[]
             {
                 @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                 @"byr:1937 iyr:2017 cid:147 hgt:183cm"
             };

            // ACT
            var passport = new Day4.Passport() { DataLines = lines.ToList() };

            passport.PopulateFields();

            // ASSERT
            Assert.AreEqual("gry", passport.PassportFields["ecl"]);
            Assert.AreEqual("860033327", passport.PassportFields["pid"]);
            Assert.AreEqual("2020", passport.PassportFields["eyr"]);
            Assert.AreEqual( "#fffffd", passport.PassportFields["hcl"]);
            Assert.AreEqual("1937", passport.PassportFields["byr"]);
            Assert.AreEqual("2017", passport.PassportFields["iyr"]);
            Assert.AreEqual("147", passport.PassportFields["cid"]);
            Assert.AreEqual("183cm", passport.PassportFields["hgt"]);
        }

        /// <summary>
        /// Shows that IsValid correctly computes passport rules.
        /// </summary>
        [TestMethod]
        public void IsValid_DifferentInput_ExpectCorrectResult()
        {

            // ARRANGE
            var passportFields = new Dictionary<string, string>
            {
                { "byr", "2002"},
                { "iyr", "2010"},
                { "eyr", "2020"},
                { "hgt", "60in"},
                { "hcl", "#123abc"},
                { "ecl", "brn"},
                { "pid", "000000001"},
            };
            
            var passport = new Day4.Passport() { PassportFields = passportFields };

            // ACT/ASSERT
            Assert.IsTrue(passport.IsVaild());

            //byr valid:   2002
            //byr invalid: 2003

            //hgt valid:   60in
            //hgt valid:   190cm
            //hgt invalid: 190in
            //hgt invalid: 190

            //hcl valid:   #123abc
            //hcl invalid: #123abz
            //hcl invalid: 123abc

            //ecl valid: brn
            //ecl invalid: wat

            //pid valid: 000000001
            //pid invalid: 0123456789
        }

        /// <summary>
        /// Shows that we get the correct valid passports.
        /// </summary>
        [TestMethod]
        public void GetValidPassports_ValidInput_ExpectCorrectPassports()
        {
            // ARRANGE
            var lines = File.ReadAllLines(@"Day4Problem1InputExample.txt");

            // ACT
            var actual = Day4.GetPassports(lines).Where(passport => passport.IsVaild()).Count();

            // ASSERT
            Assert.AreEqual(2, actual);
        }

        /// <summary>
        /// Solves problem 1 and outputs the answer.
        /// </summary>
        [TestMethod]
        [DeploymentItem("InputFiles/Day4Problem1Input.txt")]
        public void SolveProblem1()
        {
            // ARRANGE
            var lines = File.ReadAllLines(@"Day4Problem1Input.txt");

            // ACT
            var actual = Day4.GetPassports(lines).Where(passport => passport.IsVaild()).Count();

            // Output the result
            TestContext.WriteLine($"Day 4 Problem 1: Found {actual} valid passports.");

            // Output detail
            var count = 1;
            foreach (var passport in Day4.GetPassports(lines)) 
            {
                passport.PopulateFields();
                var requiredFields = new HashSet<string> { "ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt" };

                TestContext.WriteLine($"Passport #{count++}");

                foreach (var field in requiredFields)
                {
                    if (passport.PassportFields.ContainsKey(field))
                        TestContext.WriteLine($"{field}: {passport.PassportFields[field]} ");
                    else      
                        TestContext.WriteLine($"{field} not found");
                }

                TestContext.WriteLine($"{passport.IsVaild()}");

                if (!passport.IsVaild())
                {
                    TestContext.WriteLine($"Invalid fields: {passport.InvalidFieldName} {passport.InvalidFieldValue}");
                }

                TestContext.WriteLine($"-----------");
            }
        }

        [TestMethod]
        public void MyTestMethod()
        {
            var number = "170cm";
            var pattern = @"^([\d]+)(cm|in)";

            var matches = Regex.Match(number, pattern);

            Assert.IsTrue(matches.Success);

            Assert.AreEqual("170", matches.Groups[1].Value);           
            Assert.AreEqual("cm", matches.Groups[2].Value);           


            matches = Regex.Match("cm", pattern);
            Assert.IsFalse(matches.Success); 
            
            matches = Regex.Match("170", pattern);
            Assert.IsFalse(matches.Success); 
           

        }
    }
}
