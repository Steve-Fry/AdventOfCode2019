using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.Day_03
{
    class InputParser
    {
        public static List<string> ParseString(string command)
        {
            return command.Split(",").ToList();
        }
    }
}
