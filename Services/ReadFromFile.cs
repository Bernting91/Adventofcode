using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventofcode.Services
{
    internal class ReadFromFile
    {
        public static List<int> ReadIntegersFromFile(string filePath)
        {
            var list = new List<int>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                if (int.TryParse(line, out int number))
                {
                    list.Add(number);
                }
            }
            return list;
        }
    }
}
