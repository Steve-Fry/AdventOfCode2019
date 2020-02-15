using System;
using System.Diagnostics;

namespace Advent_of_Code.Day_10
{
    class Day_10
    {

        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            Asteroid part1Asteroid = GetPart1Solution();
            Console.WriteLine($"=====Day 10, part 1=====");
            Console.WriteLine($"Solution: Asteroids Visible = {part1Asteroid.AsteroidsVisible} Position = ({part1Asteroid.X},{part1Asteroid.Y}) ");

            Console.WriteLine($"=====Day 10, part 2=====");
            Console.WriteLine($"Solution: ");

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 10 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();
        }

        internal Asteroid GetPart1Solution()
        {
            AsteroidMap map = new AsteroidMap(@"..\..\..\Day 10\Day10Input.txt");
            return map.GetBestAsteroid();
        }
    }
}
