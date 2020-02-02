using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    public class QueueOutputProvider : IOutputProvider
    {
        Queue<long> _outputQueue;
        public QueueOutputProvider(Queue<long> outputQueue)
        {
            _outputQueue = outputQueue;
        }

        public void SendOutput(long output)
        {
            _outputQueue.Enqueue(output);
        }
    }

}
