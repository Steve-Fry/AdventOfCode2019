using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using Advent_of_Code.SharedLibrary.IntcodeVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

        public Queue<int> InputQueue { get; }
        public Queue<int> OutputQueue { get; }

        public FeedbackAmplifier(List<int> program, Queue<int> inputQueue, Queue<int> outputQueue)
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
