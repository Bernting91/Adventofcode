using Adventofcode.DayTwo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventofcode.DayTwo
{
    internal class Day2First
    {
        public Day2First()
        {
            var reports = Day2ReadFromFile.ReadFromFile(@"C:\Users\bernt\source\repos\Adventofcode\DayTwo\Services\Levels.txt");
            int safeReportsCount = CountSafeReports(reports);
            Console.WriteLine($"Number of safe reports: {safeReportsCount}");
        }

        static bool IsReportSafe(List<int> levels)
        {
            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 1; i < levels.Count; i++)
            {
                int difference = levels[i] - levels[i - 1];

                if (difference < -3 || difference > 3 || difference == 0)
                    return false;

                if (difference < 0)
                    isIncreasing = false;

                if (difference > 0)
                    isDecreasing = false;
            }

            return isIncreasing || isDecreasing;
        }

        static int CountSafeReports(List<List<int>> reports)
        {
            int safeCount = 0;
            foreach (var report in reports)
            {
                if (IsReportSafe(report))
                {
                    safeCount++;
                }
            }
            return safeCount;
        }
    }
}
