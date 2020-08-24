using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Advent_of_Code.Day_07
{
    public class FeedbackAmplifier
    {
        private readonly IntcodeVirtualMachine _intcodeVirtualMachine;
        private readonly List<int> _program;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;

        public bool IsDone => _intcodeVirtualMachine.IsDone;
        public void Step() => _intcodeVirtualMachine.Step();
        public Task Task { get; private set; }

        public void Run()
        {

            Task = Task.Run(
                () =>
                {
                    while (!_intcodeVirtualMachine.IsDone)
                    {
                        _token.ThrowIfCancellationRequested();
                        _intcodeVirtualMachine.Step();
                    }
                }
                , _token);
        }

        public void Cancel() => _tokenSource.Cancel();

        public BufferBlock<long> InputBuffer { get; }
        public BufferBlock<long> OutputBuffer { get; }

        public FeedbackAmplifier(List<int> program, BufferBlock<long> inputBuffer, BufferBlock<long> outputBuffer)
        {
            InputBuffer = inputBuffer;
            OutputBuffer = outputBuffer;
            _program = program;

            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _intcodeVirtualMachine = new IntcodeVirtualMachine(_program, new BufferInputProvider(InputBuffer), new BufferOutputProvider(OutputBuffer));
        }
    }
}
