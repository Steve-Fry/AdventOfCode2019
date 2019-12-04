using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
    }
}
