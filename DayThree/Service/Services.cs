using System;
using System.IO;

namespace Adventofcode.DayThree.Services
{
    public static class TextFileReader
    {
        /// <summary>
        /// Reads all lines from a specified text file.
        /// </summary>
        /// <param name="filePath">The path to the text file.</param>
        /// <returns>The contents of the file as a single string.</returns>
        public static string ReadFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"The file at {filePath} was not found.");

                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                throw;
            }
        }
    }
}
