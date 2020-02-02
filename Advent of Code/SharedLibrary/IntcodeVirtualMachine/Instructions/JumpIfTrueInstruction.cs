using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class JumpIfTrueInstruction : InstructionBase, IInstruction
    {
        public JumpIfTrueInstruction(int instructionPointer, int relativeBase, List<long> program, Opcode opcode) : base(instructionPointer, relativeBase, program, opcode) { }

        public override int Execute()
        {
            if (ParameterOneValue != 0)
            {
                return (int)ParameterTwoValue;
            }
            else
            {
                return InstructionPointer + 3;
            }
        }
    }
}
