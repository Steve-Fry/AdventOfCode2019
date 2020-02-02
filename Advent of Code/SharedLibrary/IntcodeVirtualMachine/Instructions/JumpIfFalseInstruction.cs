using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class JumpIfFalseInstruction : InstructionBase, IInstruction
    {
        public JumpIfFalseInstruction(VirtualMachineState vmState, List<long> program, Opcode opcode) : base(vmState, program, opcode) { }

        public override int Execute()
        {
            if (ParameterOneValue == 0)
            {
                return (int)ParameterTwoValue;
            }
            else
            {
                return _instructionPointer + 3;
            }
        }
    }
}
