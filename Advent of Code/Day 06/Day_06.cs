using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Advent_of_Code.Day_06
{
    class Day_06
    {
        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            List<string> input = SharedLibrary.FileParser.GetStringsFromFile(@"Inputs\Day06Input.txt");
            OrbitMapSolver mapSolver = new OrbitMapSolver(input);

            Console.WriteLine($"=====Day 6, part 1=====");
            Console.WriteLine($"Total number of orbits = {mapSolver.TotalMapDistance}");

            Console.WriteLine($"=====Day 6, part 2=====");
            Console.WriteLine($"Number of orbit changes required = {mapSolver.GetShortestPathToSanta()}");
            Console.WriteLine("");

            Console.WriteLine($"Day 6 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
