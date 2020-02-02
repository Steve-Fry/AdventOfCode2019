using System.Collections.Generic;
using Xunit;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Tests
{
    public class Test_IntCodeMachine_Day5_Part2_Jumps
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(-1, 1)]
        public void ShouldCalculatePart2JumpExamplesInPositionMode(int input, int expected)
        {
            List<int> program = new List<int>() { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };

            string filename = $"ShouldCalculatePart2JumpExamplesInPositionMode_{input}.txt";

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { input }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(expected.ToString(), actual);
            System.IO.File.Delete(filename);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(-1, 1)]
        [InlineData(0, 0)]
        public void ShouldCalculatePart2JumpExamplesInImmediateMode(int input, int expected)
        {
            List<int> program = new List<int>() { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };

            string filename = $"Day5Part2JumpImmediate_{input}.txt";

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { input }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(expected.ToString(), actual);
            System.IO.File.Delete(filename);
        }

        [Theory]
        [InlineData(7, 999)]
        [InlineData(8, 1000)]
        [InlineData(9, 1001)]
        public void ShouldCalculatePart2LongJumpExample(int input, int expected)
        {
            List<int> program = new List<int>() { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };

            string filename = $"Day5Part2LongerJump_{input}.txt";

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { input }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(expected.ToString(), actual);
            System.IO.File.Delete(filename);
        }
    }
}


