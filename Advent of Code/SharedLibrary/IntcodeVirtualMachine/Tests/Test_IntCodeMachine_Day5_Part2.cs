using System.Collections.Generic;
using Xunit;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;

namespace Advent_of_Code.SharedLibrary.IntcodeVM.Tests
{
    public class Test_IntCodeMachine_Day5_Part2
    {

        [Fact]
        public void ShouldCorrectlyCalculatePart2()
        {
            string filename = @"Day5Part1.txt";
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"..\..\..\Day 05\input.txt");
            int expected = 3419022;

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { 5 }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(expected.ToString(), actual);
        }
    }
}


