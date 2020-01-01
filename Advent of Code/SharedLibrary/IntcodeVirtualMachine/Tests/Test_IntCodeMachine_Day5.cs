using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;

namespace Advent_of_Code.SharedLibrary.IntcodeVM.Tests
{
    public class Test_IntCodeMachine_Day5
    {

        // Simple test program which echos back the input as output. 
        [Fact]
        public void ShouldCorrectlyRunExample1()
        {
            string filename = "Example1.txt";
            int theNumber = 99798;

            List<int> program = new List<int>() { 3, 0, 4, 0, 99 };
            IInputProvider inputProvider = new StaticInputProvider(new List<int>() { theNumber });
            IOutputProvider outputProvider = new FileOutputProvider(filename);

            IntcodeVirtualMachine virtualMachine = new IntcodeVirtualMachine(program, inputProvider, outputProvider);
            virtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(theNumber.ToString(), actual);
        }

        [Fact]
        public void ShouldCorrectlyRunExample2()
        {
            List<int> program = new List<int>() { 1002, 4, 3, 4, 33 };
            IntcodeVirtualMachine virtualMachine = new IntcodeVirtualMachine(program);
            virtualMachine.Run();

            List<int> expected = new List<int>() { 1002, 4, 3, 4, 99 };
            Assert.Equal(expected, virtualMachine.GetState());
        }

        [Fact]
        public void ShouldCorrectlyCalculatePart1()
        {
            string filename = @"Day5Part1.txt";
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"..\..\..\Day 05\input.txt");
            int expected = 4887191;

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<int>() { 1 }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(expected.ToString(), actual);
        }
    }
}


