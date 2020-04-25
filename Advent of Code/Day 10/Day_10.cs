using System;
using System.Diagnostics;
using System.Linq;

namespace Advent_of_Code.Day_10
{
    class Day_10
    {
        internal AsteroidMap _map = new AsteroidMap(@"Inputs\Day10Input.txt");

        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            Asteroid part1Asteroid = GetPart1Solution();
            Console.WriteLine($"=====Day 10, part 1=====");
            Console.WriteLine($"Solution: Asteroids Visible = {part1Asteroid.AsteroidsVisible} Position = ({part1Asteroid.X},{part1Asteroid.Y}) ");

            Asteroid part2Asteroid = GetPart2Solution(part1Asteroid);
            Console.WriteLine($"=====Day 10, part 2=====");
            Console.WriteLine($"Solution: Asteroid Position = {part2Asteroid.X}, {part2Asteroid.Y}.  100X + Y = {(part2Asteroid.X * 100) + part2Asteroid.Y}");

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 10 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();
        }

        internal Asteroid GetPart1Solution()
        {
            return _map.GetBestAsteroid();
        }

        internal Asteroid GetPart2Solution(Asteroid asteroid)
        {
            return _map.GetOrderOfDestruction(asteroid).Skip(199).First();
        }
    }
}
