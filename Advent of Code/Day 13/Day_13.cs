using SharedLibrary;
using System;
using System.Diagnostics;
using System.Linq;

namespace Advent_of_Code.Day_13
{
    internal class Day_13
    {
        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            Console.WriteLine($"=====Day 13, part 1=====");
            Console.WriteLine($"Solution: {GetPart1Solution()}");

            Console.WriteLine($"=====Day 13, part 2=====");
            Console.WriteLine($"Solution: {GetPart2Solution()}");

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 13 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();
        }

        internal int GetPart1Solution()
        {
            ArcadeMachine arcadeMachine = new ArcadeMachine();
            int answer = arcadeMachine.GetInitialScreenOutput().InSetsOf(3).Count(x => x[2] == 2);
            return answer;
        }

        internal int GetPart2Solution()
        {
            return 0;
        }
    }
}
