using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace Advent_of_Code.Day_12
{
    class Day_12
    {
        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();


            Console.WriteLine($"=====Day 12, part 1=====");
            Console.WriteLine($"Solution: {GetPart1Solution()}");

            Console.WriteLine($"=====Day 12, part 2=====");
            Console.WriteLine($"Solution: {GetPart2Solution()}");

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 12 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();
        }

        private float GetPart1Solution()
        {
            List<OrbitalBody> bodies = new List<OrbitalBody>()
            {
                new OrbitalBody(new Vector3(17, 5, 1)),
                new OrbitalBody(new Vector3(-2, -8, 8)),
                new OrbitalBody(new Vector3(7, -6, 14)),
                new OrbitalBody(new Vector3(1, -10, 4)),
            };

            JovianSystem jovianSystem = new JovianSystem(bodies);

            for (int i = 0; i < 1000; i++)
            {
                jovianSystem.DoTimeStep();
            }

            return jovianSystem.GetSystemEnergy();
        }

        private double GetPart2Solution()
        {
            List<OrbitalBody> bodies = new List<OrbitalBody>()
            {
                new OrbitalBody(new Vector3(17, 5, 1)),
                new OrbitalBody(new Vector3(-2, -8, 8)),
                new OrbitalBody(new Vector3(7, -6, 14)),
                new OrbitalBody(new Vector3(1, -10, 4)),
            };

            JovianSystem jovianSystem = new JovianSystem(bodies);

            return jovianSystem.GetNumberOfStepsPerCycle();

        }

    }


}
