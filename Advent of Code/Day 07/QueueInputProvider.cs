using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;

namespace Advent_of_Code.Day_07
{
    public class QueueInputProvider : IInputProvider
    {
        Queue<int> _inputQueue;
        public QueueInputProvider(Queue<int> inputQueue)
        {
            _inputQueue = inputQueue;   
        }

        public int GetInput()
        {
            return _inputQueue.Dequeue();
        }
    }

}
