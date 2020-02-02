using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class MultiplyInstruction : InstructionBase, IInstruction
    {
        public MultiplyInstruction(VirtualMachineState vmState, List<long> program, Opcode opcode) : base(vmState, program, opcode) { }

        public override int Execute()
        {
            ParameterThreeValue = ParameterOneValue * ParameterTwoValue;
            return _instructionPointer + 4;
        }
    }
}
