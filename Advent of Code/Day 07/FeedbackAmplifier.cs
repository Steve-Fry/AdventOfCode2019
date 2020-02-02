using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;

namespace Advent_of_Code.Day_07
{
    public class FeedbackAmplifier
    {
        private readonly IntcodeVirtualMachine _intcodeVirtualMachine;
        private readonly List<int> _program;

        public bool IsDone
        {
            get
            {
                return _intcodeVirtualMachine.IsDone;
            }
        }

        public Queue<long> InputQueue { get; }
        public Queue<long> OutputQueue { get; }

        public FeedbackAmplifier(List<int> program, Queue<long> inputQueue, Queue<long> outputQueue)
        {
            _program = program;
            InputQueue = inputQueue;
            OutputQueue = outputQueue;

            _intcodeVirtualMachine = new IntcodeVirtualMachine(_program, new QueueInputProvider(inputQueue), new QueueOutputProvider(outputQueue));
        }

        public void Step()
        {
            _intcodeVirtualMachine.Step();
        }

    }
}
