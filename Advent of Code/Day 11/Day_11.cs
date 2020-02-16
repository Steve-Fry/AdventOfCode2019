using System;
using System.Diagnostics;
using System.Linq;

namespace Advent_of_Code.Day_11
{
    class Day_11
    {
        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            
            Console.WriteLine($"=====Day 11, part 1=====");
            Console.WriteLine($"Solution: Painted {GetPart1Solution()} panels");

            Console.WriteLine($"=====Day 11, part 2=====");
            Console.WriteLine($"{GetPart2Solution()}");

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 11 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();
        }

        private int GetPart1Solution()
        {
            PaintableHullSection hull = new PaintableHullSection();
            PaintingRobot robot = new PaintingRobot(hull, 0);
            return robot.PaintedPanels;
        }

        private string GetPart2Solution()
        {
            PaintableHullSection hull = new PaintableHullSection();
            PaintingRobot robot = new PaintingRobot(hull, 1);
            return hull.GetAreaOfInterest();
        }
    }
}
