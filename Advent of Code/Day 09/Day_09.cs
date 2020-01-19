using Advent_of_Code.SharedLibrary.IntcodeVM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Advent_of_Code.Day_09
{
    class Day_09
    {

        public void Run()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"..\..\..\Day 09\Day9Input.txt");
            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program);

            Console.WriteLine($"=====Day 9, part 1=====");

            Console.WriteLine($"=====Day 9, part 2=====");

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 9 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
