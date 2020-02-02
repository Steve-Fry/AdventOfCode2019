using System;
using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    class StaticInputProvider : IInputProvider
    {
        readonly List<long> _availableInput;
        int _index;

        public StaticInputProvider(List<long> input)
        {
            _availableInput = input;
            _index = 0;
        }

        public long GetInput()
        {
            if (_index <= _availableInput.Count)
            {
                return _availableInput[_index++];
            }
            else
            {
                throw new IndexOutOfRangeException("Attempted to pull more values than were available.");
            }
        }
    }
}
