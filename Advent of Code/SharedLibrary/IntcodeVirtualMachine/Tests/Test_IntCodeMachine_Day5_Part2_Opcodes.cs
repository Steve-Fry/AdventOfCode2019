using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;

namespace Advent_of_Code.SharedLibrary.IntcodeVM.Tests
{
    public class Test_IntCodeMachine_Day5_Part2_Opcodes
    {

        [Theory]
        [InlineData(7, 0)]
        [InlineData(8, 1)]
        [InlineData(9, 0)]
        public void ShouldCalculateEqualsOperatorInPositionMode(int input, int expected)
        {
            List<int> program = new List<int>() { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };

            string filename = $"ShouldCalculateEqualsOperatorInPositionMode.txt";

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { input }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(expected.ToString(), actual);
            System.IO.File.Delete(filename);
        }

        [Theory]
        [InlineData(7, 1)]
        [InlineData(8, 0)]
        [InlineData(9, 0)]
        public void ShouldCalculateLessThanOperatorInPositionMode(int input, int expected)
        {
            List<int> program = new List<int>() { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };

            string filename = $"ShouldCalculateLessThanOperatorInPositionMode.txt";

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { input }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(expected.ToString(), actual);
            System.IO.File.Delete(filename);
        }

        [Theory]
        [InlineData(7, 0)]
        [InlineData(8, 1)]
        [InlineData(9, 0)]
        public void ShouldCalculateEqualsOperatorInImmediateMode(int input, int expected)
        {
            List<int> program = new List<int>() { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };

            string filename = $"ShouldCalculateEqualsOperatorInPositionMode.txt";

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { input }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(expected.ToString(), actual);
            System.IO.File.Delete(filename);
        }

        [Theory]
        [InlineData(7, 1)]
        [InlineData(8, 0)]
        [InlineData(9, 0)]
        public void ShouldCalculateLessThanOperatorInImmediateMode(int input, int expected)
        {
            List<int> program = new List<int>() { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };

            string filename = $"ShouldCalculateLessThanOperatorInPositionMode.txt";

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { input }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(expected.ToString(), actual);
            System.IO.File.Delete(filename);
        }
    }
}


