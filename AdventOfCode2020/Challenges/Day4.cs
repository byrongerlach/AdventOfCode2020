using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Challenges
{
    /// <summary>
    /// Solution for Advent of Code Day 4
    /// https://adventofcode.com/2020/day/4
    /// </summary>
    public class Day4
    {
        /// <summary>
        /// Gets the passports. Each passport is separated by an empty blank line.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IEnumerable<Passport> GetPassports(string[] lines)
        {
            var passport = new Passport();
            foreach (var line in lines)
            {
                // Remove whitespace from the line
                var currentLine = line.Trim();
                // If the line's empty, we're at the end of the passport entry.
                if (string.IsNullOrEmpty(currentLine))
                {
                    // Return the passport if it has any data lines.
                    if (passport.DataLines.Any())
                        yield return passport;

                    // Start a new passport
                    passport = new Passport();
                }

                // The line has content, so add it.
                passport.DataLines.Add(line);
            }

            // Return the last passport
            yield return passport;
        }

        public class Passport
        {
            /// <summary>
            /// Gets the raw data lines for the passport.
            /// </summary>
            /// <value>
            /// The data lines.
            /// </value>
            public List<string> DataLines { get; set; }

            public Dictionary<string, string> PassportFields { get; set; }

            /// <summary>
            /// The name of the first invalid field found in the IsValid method
            /// </summary>
            public string InvalidFieldName { get; set; }
 
            /// <summary>
            /// The value of the first invalid field found in the IsValid method
            /// </summary>
            public string InvalidFieldValue { get; set; }
           
            public Passport()
            {
                DataLines = new List<string>();
                PassportFields = new Dictionary<string, string>();
            }

            /// <summary>
            /// Populates the passport fields from the DataLines.
            /// </summary>
            public void PopulateFields()
            {
                // Brute-force method of dealing with inconsistent line endings.
                var data = string.Join("", DataLines.Select(d => d.Trim() + ' ').ToArray()).Trim();
                var dataTokens = data.Split(' ');
                foreach (var dataToken in dataTokens)
                {
                    var fieldTokens = dataToken.Split(':');

                    // Skip if there's not two fields
                    if (fieldTokens.Count() != 2)
                        continue;

                    PassportFields.Add(fieldTokens[0], fieldTokens[1]);
                }
            }

            /// <summary>
            /// Determines whether this passport is valid based on required fields.
            /// </summary>
            /// <returns>
            ///   <c>true</c> if this instance is vaild; otherwise, <c>false</c>.
            /// </returns>
            public bool IsVaild()
            {
                /*
                Here are the validation rules:
                byr(Birth Year) - four digits; at least 1920 and at most 2002.
                iyr(Issue Year) - four digits; at least 2010 and at most 2020.
                eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
                hgt(Height) - a number followed by either cm or in:

                    If cm, the number must be at least 150 and at most 193.
                    If in, the number must be at least 59 and at most 76.

                hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                pid(Passport ID) - a nine - digit number, including leading zeroes.

                */

                var requiredFields = new HashSet<string> { "ecl", "pid", "eyr", "hcl", "byr", "iyr", "hgt" };

                if (!PassportFields.Any())
                    PopulateFields();

                var suppliedFields = PassportFields.Select(f => f.Key).ToHashSet();

                // Check that all required fields exist.
                if (requiredFields.Except(suppliedFields).Any())
                {
                    return false;
                }

                // Check birth year.
                var byr = Convert.ToInt32(PassportFields["byr"]);
                if (byr < 1920 || byr > 2002)
                {
                    InvalidFieldName = "byr";
                    InvalidFieldValue = byr.ToString();
                    return false;
                }

                // Check issue year
                var iyr = Convert.ToInt32(PassportFields["iyr"]);
                if (iyr < 2010 || iyr > 2020)
                {
                    InvalidFieldName = "iyr";
                    InvalidFieldValue = iyr.ToString();
                    return false;
                }

                // Check expiration year
                var eyr = Convert.ToInt32(PassportFields["eyr"]);
                if (eyr < 2020 || eyr > 2030)
                {
                    InvalidFieldName = "eyr";
                    InvalidFieldValue = eyr.ToString();
                    return false;
                }

                // Check height
                var matches = Regex.Match(PassportFields["hgt"], @"^([\d]+)(cm|in)");

                if (!matches.Success)
                {
                    InvalidFieldName = "hgt";
                    InvalidFieldValue = PassportFields["hgt"];
                    return false;
                }

                var height = Convert.ToInt32(matches.Groups[1].Value);
                var heightUnit = matches.Groups[2].Value;

                if (heightUnit != "cm" && heightUnit != "in")
                {
                    InvalidFieldName = "hgt";
                    InvalidFieldValue = PassportFields["hgt"];
                    return false;
                }

                if (heightUnit == "cm" &&  (height < 150 || height > 193))
                {
                    InvalidFieldName = "hgt";
                    InvalidFieldValue = PassportFields["hgt"];
                    return false;
                }

                if (heightUnit == "in" &&  (height < 59 || height > 76))
                {
                    InvalidFieldName = "hgt";
                    InvalidFieldValue = PassportFields["hgt"];
                    return false;
                }

                // Check hair color
                if (!Regex.IsMatch(PassportFields["hcl"], @"^#[0-9a-f]{6}"))
                {
                    InvalidFieldName = "hcl";
                    InvalidFieldValue = PassportFields["hcl"];
                    return false;
                }

                // Check eye color
                var validColors = new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

                if (!validColors.Contains(PassportFields["ecl"]))
                {
                    InvalidFieldName = "ecl";
                    InvalidFieldValue = PassportFields["ecl"];
                    return false;
                }

                // Check passport ID
                if (!Regex.IsMatch(PassportFields["pid"], @"^[0-9]{9}"))
                {
                    InvalidFieldName = "pid";
                    InvalidFieldValue = PassportFields["pid"];
                    return false;
                }

                return true;

                /*
                byr(Birth Year) - four digits; at least 1920 and at most 2002.
                iyr(Issue Year) - four digits; at least 2010 and at most 2020.
                eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
                hgt(Height) - a number followed by either cm or in:

                    If cm, the number must be at least 150 and at most 193.
                    If in, the number must be at least 59 and at most 76.

                hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                pid(Passport ID) - a nine - digit number, including leading zeroes.

                */
            }
        }
    }
}
