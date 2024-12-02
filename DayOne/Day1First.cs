using Adventofcode.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Adventofcode
{
    internal class Day1First
    {
        List<int> leftList;
        List<int> rightList;

        public Day1First()
        {
            leftList = Day1ReadFromFile.ReadIntegersFromFile(@"C:\Users\bernt\source\repos\Adventofcode\DayOne\Services\LeftColumn.txt");
            rightList = Day1ReadFromFile.ReadIntegersFromFile(@"C:\Users\bernt\source\repos\Adventofcode\DayOne\Services\RightColumn.txt");

            int totalDistance = CalculateTotalDistance(leftList, rightList);
            Console.WriteLine($"Total distance: {totalDistance}");
        }


        static int CalculateTotalDistance(List<int> leftList, List<int> rightList)
        {
           
            leftList.Sort();
            rightList.Sort();

            
            int totalDistance = 0;
            for (int i = 0; i < leftList.Count; i++)
            {
                totalDistance += Math.Abs(leftList[i] - rightList[i]);
            }

            return totalDistance;
        }
    }
}