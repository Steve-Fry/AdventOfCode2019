using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    class StaticInputProvider : IInputProvider
    {
        List<int> availableInput;
        int index;

        public StaticInputProvider(List<int> input)
        {
            availableInput = input;
            index = 0;
        }

        public int GetInput()
        {
            if (index <= availableInput.Count)
            {
                return availableInput[index++];
            }
            else
            {
                throw new IndexOutOfRangeException("Attempted to pull more values than were available.");
            }
        }
    }
}
