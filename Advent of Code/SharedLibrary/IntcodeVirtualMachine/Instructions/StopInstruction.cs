using System;
using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class StopInstruction : InstructionBase, IInstruction
    {
        public StopInstruction(VirtualMachineState vmState, List<long> program, Opcode opcode) : base(vmState, program, opcode) { }

        public override int Execute()
        {
            throw new ApplicationException("A stop instruction should never be executed");
        }
    }
}
