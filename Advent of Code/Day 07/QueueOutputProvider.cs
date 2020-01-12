using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;

namespace Advent_of_Code.Day_07
{
    public class QueueOutputProvider : IOutputProvider
    {
        Queue<int> _outputQueue;
        public QueueOutputProvider(Queue<int> outputQueue)
        {
            _outputQueue = outputQueue;
        }

        public void SendOutput(int output)
        {
            _outputQueue.Enqueue(output);
        }
    }

}
