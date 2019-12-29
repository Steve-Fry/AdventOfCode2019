using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Advent_of_Code.Day_01
{
    class Day_01
    {
        const string filename = @"D:\DEV\CSharp\Advent of Code\Advent of Code\Day 01\input.txt";
        public static void Run()
        {
            Console.WriteLine($"=====Day 1, part 1=====");
            IEnumerable<double> moduleMasses = SharedLibrary.FileParser.GetDoublesFromFile(filename);

            double total = moduleMasses
                            .Select(x => FuelCalculator.GetFuelRequirementForMass(x))
                            .Sum();

            Console.WriteLine($"Total fuel required: {total}");

            Console.WriteLine($"=====Day 1, part 2=====");
            double part2total = moduleMasses
                                         .Select(x => FuelCalculator.GetFuelRequirementsForMassIncludingSelf(x))
                                         .Sum();

            Console.WriteLine($"Total fuel required: {part2total}");
            Console.WriteLine("");
        }
    }
}
