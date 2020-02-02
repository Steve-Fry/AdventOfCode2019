using System.Collections.Generic;
using Xunit;

namespace Advent_of_Code.SharedLibrary.IntcodeVM.Tests
{
    public class Test_IntCodeMachine_Day2
    {
        [Fact]
        public void ShouldCorrectlyCalculateExample1()
        {
            List<int> opcodes = new List<int>() { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            IntcodeVirtualMachine intMachine = new IntcodeVirtualMachine(opcodes);
            intMachine.Run();

            List<long> actual = intMachine.GetState();
            List<long> expected = new List<long>() { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample2()
        {
            List<int> opcodes = new List<int>() { 1, 0, 0, 0, 99 };
            IntcodeVirtualMachine intMachine = new IntcodeVirtualMachine(opcodes);
            intMachine.Run();

            List<long> actual = intMachine.GetState();
            List<long> expected = new List<long>() { 2, 0, 0, 0, 99 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample3()
        {
            List<int> opcodes = new List<int>() { 2, 3, 0, 3, 99 };
            IntcodeVirtualMachine intMachine = new IntcodeVirtualMachine(opcodes);
            intMachine.Run();

            List<long> actual = intMachine.GetState();
            List<long> expected = new List<long>() { 2, 3, 0, 6, 99 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample4()
        {
            List<int> opcodes = new List<int>() { 2, 4, 4, 5, 99, 0 };
            IntcodeVirtualMachine intMachine = new IntcodeVirtualMachine(opcodes);
            intMachine.Run();

            List<long> actual = intMachine.GetState();
            List<long> expected = new List<long>() { 2, 4, 4, 5, 99, 9801 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample5()
        {
            List<int> opcodes = new List<int>() { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            IntcodeVirtualMachine intMachine = new IntcodeVirtualMachine(opcodes);
            intMachine.Run();

            List<long> actual = intMachine.GetState();
            List<long> expected = new List<long>() { 30, 1, 1, 4, 2, 5, 6, 0, 99 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldCalculateTheCorrectResultForPart1()
        {
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"..\..\..\Day 02\input.txt");
            IntcodeVirtualMachine intMachine = new IntcodeVirtualMachine(program);
            long actual = intMachine.Run();

            Assert.Equal(4570637, actual);
        }

    }
}


