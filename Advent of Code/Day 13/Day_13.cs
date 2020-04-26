using SharedLibrary;
using System;
using System.Diagnostics;
using System.Linq;

namespace Advent_of_Code.Day_13
{
    internal class Day_13
    {

        ArcadeMachine _arcadeMachine;

        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            _arcadeMachine = new ArcadeMachine();

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
            int answer = _arcadeMachine.GetInitialScreenOutput().InSetsOf(3).Count(x => x[2] == 2);
            return answer;
        }

        internal int GetPart2Solution()
        {
            _arcadeMachine.RunMachine();
            return 0;
        }
    }
}
