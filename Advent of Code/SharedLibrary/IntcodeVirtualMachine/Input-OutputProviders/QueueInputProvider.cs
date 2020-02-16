using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
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
