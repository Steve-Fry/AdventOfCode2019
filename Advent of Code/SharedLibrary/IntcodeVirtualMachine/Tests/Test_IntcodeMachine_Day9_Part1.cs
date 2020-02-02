using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Linq;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Tests
{
    public class Test_IntcodeMachine_Day9_Part1
    {
        [Fact]
        public void ShouldCorrectlyCalculateExample1_Test()
        {
            List<long> program = new List<long>() { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };   
            List<long> expected = new List<long>() { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };

            Queue<long> outputQueue = new Queue<long>();

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { }), new QueueOutputProvider(outputQueue));
            intcodeVirtualMachine.Run();

            Assert.Equal(expected, outputQueue.ToList());
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample2_Test()
        {
            string filename = System.IO.Path.GetTempFileName();
            List<long> program = new List<long>() { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal(16, actual.Length);
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample3_Test()
        {
            string filename = System.IO.Path.GetTempFileName();
            List<long> program = new List<long>() { 104, 1125899906842624, 99 };

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long>() { }), new FileOutputProvider(filename));
            intcodeVirtualMachine.Run();

            string actual = System.IO.File.ReadAllText(filename);
            Assert.Equal("1125899906842624", actual);
        }
    }
}
