using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Adventofcode.DayTwo
{
    internal class Day2Second
    {
        public Day2Second()
        {
            // Read reports from file
            var reports = ReadFromFile(@"C:\Users\bernt\source\repos\Adventofcode\DayTwo\Services\Levels.txt");

            // Count safe reports considering the Problem Dampener
            int safeReportsCount = CountSafeReportsWithDampener(reports);

            // Print the result
            Console.WriteLine($"Number of safe reports with Problem Dampener: {safeReportsCount}");
        }

        private static List<List<int>> ReadFromFile(string filePath)
        {
            var reports = new List<List<int>>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var levels = line.Split(' ')
                                 .Where(l => int.TryParse(l, out _))
                                 .Select(int.Parse)
                                 .ToList();
                reports.Add(levels);
            }
            return reports;
        }

        private static bool IsReportSafe(List<int> levels)
        {
            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 1; i < levels.Count; i++)
            {
                int difference = levels[i] - levels[i - 1];

                // If the difference is invalid, the report is unsafe
                if (difference < -3 || difference > 3 || difference == 0)
                    return false;

                // If a single pair doesn't match increasing pattern, set flag to false
                if (difference < 0)
                    isIncreasing = false;

                // If a single pair doesn't match decreasing pattern, set flag to false
                if (difference > 0)
                    isDecreasing = false;
            }

            // The report is safe if it is either increasing or decreasing
            return isIncreasing || isDecreasing;
        }

        private static bool IsReportSafeWithDampener(List<int> levels)
        {
            // First, check if the report is already safe
            if (IsReportSafe(levels))
                return true;

            // Try removing each level and check if the remaining report is safe
            for (int i = 0; i < levels.Count; i++)
            {
                var modifiedLevels = new List<int>(levels);
                modifiedLevels.RemoveAt(i); // Remove one level

                if (IsReportSafe(modifiedLevels))
                    return true; // The report becomes safe by removing this level
            }

            // If no single removal makes the report safe, it remains unsafe
            return false;
        }

        private static int CountSafeReportsWithDampener(List<List<int>> reports)
        {
            int safeCount = 0;
            foreach (var report in reports)
            {
                if (IsReportSafeWithDampener(report))
                {
                    safeCount++;
                }
            }
            return safeCount;
        }
    }
}
