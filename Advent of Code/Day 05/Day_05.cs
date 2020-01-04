using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Advent_of_Code.SharedLibrary.IntcodeVM;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;


namespace Advent_of_Code.Day_05
{
    class Day_05
    {
        public void Run()
        {
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"..\..\..\Day 05\input.txt");

            Console.WriteLine($"=====Day 5, part 1=====");
            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<int>() { 1 }), new FileOutputProvider("Day5Part1.txt"));
            intcodeVirtualMachine.Run();
            Console.WriteLine($"Output = {System.IO.File.ReadAllText("Day5Part1.txt")}");


            program = SharedLibrary.FileParser.GetIntCodeFromFile(@"..\..\..\Day 05\input.txt");
            Console.WriteLine($"=====Day 5, part 2=====");
            intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<int>() { 5 }), new FileOutputProvider("Day5Part2.txt"));
            intcodeVirtualMachine.Run();
            Console.WriteLine($"Output = {System.IO.File.ReadAllText("Day5Part2.txt")}");

        }
    }
}
