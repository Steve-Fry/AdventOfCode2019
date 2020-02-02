using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class EqualsInstruction : InstructionBase, IInstruction
    {
        public EqualsInstruction(VirtualMachineState vmState, List<long> program, Opcode opcode) : base(vmState, program, opcode) { }

        public override int Execute()
        {
            ParameterThreeValue = ParameterOneValue == ParameterTwoValue ? 1 : 0;
            return _instructionPointer + 4;
        }
    }
}

