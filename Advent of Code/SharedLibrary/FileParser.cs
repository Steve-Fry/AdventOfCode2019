using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Advent_of_Code.SharedLibrary
{
    public class FileParser
    {

        public static IEnumerable<double> GetDoublesFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    yield return double.Parse(line);
                }
            }
        }


        public static List<int> GetIntCodeFromFile(string path)
        {
            string input = File.ReadAllText(path);
            return input.Split(',').Select(x => int.Parse(x)).ToList();
        }

        public static List<string> GetStringsFromFile(string path)
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}
