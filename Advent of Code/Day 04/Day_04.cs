using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Advent_of_Code.Day_04
{
    class Day_04
    {
        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            Console.WriteLine($"=====Day 4, part 1=====");
            PasswordBruteForcer bruteForcer = new PasswordBruteForcer(6, 382345, 843167);

            Console.WriteLine($"There are {bruteForcer.GetValidPasswordsInRange_Part1()} valid passwords in this range");

            Console.WriteLine($"=====Day 4, part 2=====");
            Console.WriteLine($"There are {bruteForcer.GetValidPasswordsInRange_Part2()} valid passwords in this range");
            Console.WriteLine("");

            Console.WriteLine($"Day 4 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
