using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
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

            Console.WriteLine($"=====Day 9, part 1=====");
            Console.WriteLine($"Solution: {GetPart1Solution()}");

            Console.WriteLine($"=====Day 9, part 2=====");
            Console.WriteLine($"Solution: {GetPart2Solution()}");

            stopWatch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Day 9 completed in {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine();

        }

        private long GetPart1Solution()
        {
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"Inputs\Day09Input.txt");
            Queue<long> outputQueue = new Queue<long>();
            
            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long> { 1 }), new QueueOutputProvider(outputQueue));
            intcodeVirtualMachine.Run();
            return outputQueue.Dequeue();
        }

        private long GetPart2Solution()
        {
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"Inputs\Day09Input.txt");
            Queue<long> outputQueue = new Queue<long>();

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long> { 2 }), new QueueOutputProvider(outputQueue));
            intcodeVirtualMachine.Run();
            return outputQueue.Dequeue();
        }
    }
}
