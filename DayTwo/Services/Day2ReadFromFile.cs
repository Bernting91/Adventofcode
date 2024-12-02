using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventofcode.DayTwo.Services
{
    internal class Day2ReadFromFile
    {
        public static List<List<int>> ReadFromFile(string filePath)
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
    }
}
