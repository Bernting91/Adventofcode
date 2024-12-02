using Adventofcode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventofcode
{
    internal class Day2
    {
        List<int> leftList;
        List<int> rightList;

        public Day2()
        {
            leftList = ReadFromFile.ReadIntegersFromFile(@"C:\Users\bernt\source\repos\Adventofcode\Services\LeftColumn.txt");
            rightList = ReadFromFile.ReadIntegersFromFile(@"C:\Users\bernt\source\repos\Adventofcode\Services\RightColumn.txt");

            int similarityScore = CalculateSimilarityScore(leftList, rightList);
            Console.WriteLine($"Similarity score: {similarityScore}");
        }

        static int CalculateSimilarityScore(List<int> leftList, List<int> rightList)
        {
            
            var numberCountsInRightList = rightList
                .GroupBy(number => number)
                .ToDictionary(group => group.Key, group => group.Count());

            
            int similarityScore = leftList.Sum(number =>
                numberCountsInRightList.TryGetValue(number, out int count) ? number * count : 0);

            return similarityScore;
        }
    }
}
