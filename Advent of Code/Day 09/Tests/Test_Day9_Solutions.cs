using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;
using Xunit;

namespace Advent_of_Code.Day_09.Tests
{
    public class Test_Day9_Solutions
    {
        [Fact]
        public void ShouldCorrectlyCalculatePart1Solution()
        {
            long expected = 3533056970;

            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"..\..\..\Day 09\Day9Input.txt");
            Queue<long> outputQueue = new Queue<long>();

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long> { 1 }), new QueueOutputProvider(outputQueue));
            intcodeVirtualMachine.Run();

            Assert.Equal(expected, outputQueue.Dequeue());
        }

        [Fact]
        public void ShouldCorrectlyCalculatePart2Solution()
        {
            long expected = 72852;

            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"..\..\..\Day 09\Day9Input.txt");
            Queue<long> outputQueue = new Queue<long>();

            IntcodeVirtualMachine intcodeVirtualMachine = new IntcodeVirtualMachine(program, new StaticInputProvider(new List<long> { 2 }), new QueueOutputProvider(outputQueue));
            intcodeVirtualMachine.Run();

            Assert.Equal(expected, outputQueue.Dequeue());
        }
    }
}
