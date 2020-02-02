using System;
using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class StopInstruction : InstructionBase, IInstruction
    {
        public StopInstruction(int instructionPointer, int relativeBase, List<long> program, Opcode opcode) : base(instructionPointer, relativeBase, program, opcode) { }

        public override int Execute()
        {
            throw new ApplicationException("A stop instruction should never be executed");
        }
    }
}
