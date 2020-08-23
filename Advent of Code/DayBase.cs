using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Advent_of_Code.SharedLibrary
{
    class DayBase
    {
        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            Console.WriteLine($"=====Day 15, part 1=====");
            Console.WriteLine($"Solution: {GetPart1Solution()}");

            Console.WriteLine($"=====Day 15, part 2=====");
            Console.WriteLine($"Solution: {GetPart2Solution()}");

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 15 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();
        }

        internal virtual string GetPart1Solution()
        {
            return "Not Implemented";
        }

        internal virtual string GetPart2Solution()
        {
            return "Not Implemented";
        }
    }
}
