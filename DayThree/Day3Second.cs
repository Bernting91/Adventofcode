using System;
using System.Text.RegularExpressions;
using Adventofcode.DayThree.Services;

namespace Adventofcode.DayThree
{
    internal class Day3Second
    {
        public Day3Second()
        {
            // Path to your text file
            string filePath = @"C:\Users\bernt\Source\Repos\Adventofcode\DayThree\Service\Text.txt";

            // Read the file content
            string input = TextFileReader.ReadFile(filePath);

            // Calculate the sum of all valid mul(x, y) instructions with enabled states
            int result = CalculateMulSumWithState(input);

            Console.WriteLine($"Sum of all valid enabled mul(x, y) instructions: {result}");
        }

        private static int CalculateMulSumWithState(string input)
        {
            // Define regex patterns for instructions
            var mulRegex = new Regex(@"\bmul\((\d{1,3}),(\d{1,3})\)");
            var doRegex = new Regex(@"\bdo\(\)");
            var dontRegex = new Regex(@"\bdon't\(\)");

            // Initialize a sum accumulator and state for mul instructions
            int sum = 0;
            bool isMulEnabled = true;

            // Iterate through each match in sequence to process instructions in order
            var regex = new Regex(@"\b(mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\))");
            foreach (Match match in regex.Matches(input))
            {
                string instruction = match.Value;

                if (mulRegex.IsMatch(instruction) && isMulEnabled)
                {
                    // Process mul(x, y) when enabled
                    var mulMatch = mulRegex.Match(instruction);
                    int x = int.Parse(mulMatch.Groups[1].Value);
                    int y = int.Parse(mulMatch.Groups[2].Value);
                    sum += x * y;
                }
                else if (doRegex.IsMatch(instruction))
                {
                    // Enable mul instructions
                    isMulEnabled = true;
                }
                else if (dontRegex.IsMatch(instruction))
                {
                    // Disable mul instructions
                    isMulEnabled = false;
                }
            }

            return sum;
        }
    }
}
