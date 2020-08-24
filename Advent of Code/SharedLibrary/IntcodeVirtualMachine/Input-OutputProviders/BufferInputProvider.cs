using Serilog;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    public class BufferInputProvider : IInputProvider
    {
        private readonly BufferBlock<long> _inputBuffer;
        public BufferInputProvider(BufferBlock<long> inputBuffer)
        {
            _inputBuffer = inputBuffer;
        }

        public long GetInput()
        {
            long input = _inputBuffer.Receive();
            Log.Information("BufferInputProvider Recieved input {output}", input);
            return input;
        }
    }
}
