using System;
using System.Text.RegularExpressions;
using Adventofcode.DayThree.Services;

namespace Adventofcode.DayThree
{
    internal class Day3First
    {
        public Day3First()
        {
            // Path to your text file
            string filePath = @"C:\Users\bernt\Source\Repos\Adventofcode\DayThree\Service\Text.txt";

            // Read the file content
            string input = Services.TextFileReader.ReadFile(filePath);

            // Calculate the sum of all valid mul(x, y) instructions
            int result = CalculateMulSum(input);

            Console.WriteLine($"Sum of all valid mul(x, y) instructions: {result}");
        }

        private static int CalculateMulSum(string input)
        {
            // Define a regex pattern to match only valid mul(x, y) expressions
            var regex = new Regex(@"\bmul\((\d{1,3}),(\d{1,3})\)");

            // Initialize a sum accumulator
            int sum = 0;

            // Iterate through all regex matches in the input string
            foreach (Match match in regex.Matches(input))
            {
                // Parse the matched numbers
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                // Compute and add the product to the sum
                sum += x * y;
            }

            return sum;
        }
    }
}
