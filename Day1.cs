using Adventofcode.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Adventofcode
{
    internal class Day1
    {
        List<int> leftList;
        List<int> rightList;

        public Day1()
        {
            leftList = ReadFromFile.ReadIntegersFromFile(@"C:\Users\bernt\source\repos\Adventofcode\Services\LeftColumn.txt");
            rightList = ReadFromFile.ReadIntegersFromFile(@"C:\Users\bernt\source\repos\Adventofcode\Services\RightColumn.txt");

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