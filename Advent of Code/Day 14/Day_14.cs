using SharedLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Advent_of_Code.Day_14
{
    internal class Day_14
    {

        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            Console.WriteLine($"=====Day 14, part 1=====");
            Console.WriteLine($"Solution: {GetPart1Solution()}");

            Console.WriteLine($"=====Day 14, part 2=====");
            Console.WriteLine($"Solution: {GetPart2Solution()}");

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 14 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();
        }

        internal long GetPart1Solution()
        {
            string input = File.ReadAllText(@"Inputs\Day14Input.txt");
            ResourceConverterMap map = new ResourceConverterMap(input);

            FuelConverterCalculator calculator = new FuelConverterCalculator(input, map);
            return calculator.CalculateRequiredOre();
        }

        internal long GetPart2Solution()
        {
            string input = File.ReadAllText(@"Inputs\Day14Input.txt");
            ResourceConverterMap map = new ResourceConverterMap(input);
            long oreCount = 1_000_000_000_000;

            FuelConverterCalculator calculator = new FuelConverterCalculator(input, map);
            return calculator.CalculateFuelProduced(oreCount);
        }
    }
}
