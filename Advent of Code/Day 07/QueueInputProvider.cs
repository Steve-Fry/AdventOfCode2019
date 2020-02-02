using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;

namespace Advent_of_Code.Day_07
{
    public class QueueInputProvider : IInputProvider
    {
        Queue<long> _inputQueue;
        public QueueInputProvider(Queue<long> inputQueue)
        {
            _inputQueue = inputQueue;   
        }

        public long GetInput()
        {
            return _inputQueue.Dequeue();
        }
    }

}
