using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;


namespace Advent_of_Code.Day_06
{
    class Day_06
    {
        public void Run()
        {
            List<string> input = SharedLibrary.FileParser.GetStringsFromFile(@"..\..\..\Day 06\Day6Input.txt");
            OrbitMapSolver mapSolver = new OrbitMapSolver(input);

            Console.WriteLine($"=====Day 6, part 1=====");
            Console.WriteLine($"Total number of orbits = {mapSolver.TotalMapDistance}");

            Console.WriteLine($"=====Day 6, part 2=====");
            Console.WriteLine($"Number of orbit changes required = {mapSolver.GetShortestPathToSanta()}");
        }
    }
}
