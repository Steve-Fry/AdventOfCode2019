using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    public class BufferOutputProvider : IOutputProvider
    {
        private readonly BufferBlock<long> _outputBuffer;
        public BufferOutputProvider(BufferBlock<long> outputBuffer)
        {
            _outputBuffer = outputBuffer;
        }

        public void SendOutput(long output)
        {
            _outputBuffer.Post(output);
            Log.Information("BufferOutputProvider Posted output {output}", output);
        }
    }
}
