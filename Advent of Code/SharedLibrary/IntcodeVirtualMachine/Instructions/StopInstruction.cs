using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class StopInstruction : InstructionBase, IInstruction
    {
        public StopInstruction(int instructionPointer, List<int> program) : base(instructionPointer, program)
        {
        }

        public override int Execute()
        {
            throw new ApplicationException("A stop instruction should never be executed");
        }
    }
}
