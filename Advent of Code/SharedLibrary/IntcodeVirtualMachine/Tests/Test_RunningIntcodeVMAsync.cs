using Advent_of_Code.Day_07;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Xunit;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Tests
{
    public class Test_RunningIntcodeVMAsync
    {
        [Fact]
        public void ShouldReturnDay2AsAsync()
        {
            // Arrange 
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"Inputs\Day02Input.txt");

            // Act
            IntcodeVirtualMachine intMachine = new IntcodeVirtualMachine(program);
            long actual = 0;
            var runningTask = Task.Run(() => { actual = intMachine.Run(); });
            runningTask.Wait();

            // Assert
            Assert.Equal(4570637, actual);
        }

        [Fact]
        public void ShouldUseAsyncOutputProvider()
        {
            // Arrange 
            int input = 99798;
            int expected = input;
            List<int> program = new List<int>() { 3, 0, 4, 0, 99 };
            BufferBlock<long> inputBuffer = new BufferBlock<long>();
            BufferBlock<long> outputBuffer = new BufferBlock<long>();
            IInputProvider inputProvider = new BufferInputProvider(inputBuffer);
            IOutputProvider outputProvider = new BufferOutputProvider(outputBuffer);
            IntcodeVirtualMachine virtualMachine = new IntcodeVirtualMachine(program, inputProvider, outputProvider);

            // Act
            var vmTask = Task.Run(() => { virtualMachine.Run(); });
            inputBuffer.Post(input);
            vmTask.Wait();

            // Assert
            long actual = outputBuffer.Receive();
            Assert.Equal(expected, actual);
        }
    }
}
