using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class JumpIfFalseInstruction : InstructionBase, IInstruction
    {
        public JumpIfFalseInstruction(int instructionPointer, int relativeBase, List<long> program, Opcode opcode) : base(instructionPointer, relativeBase, program, opcode) { }

        public override int Execute()
        {
            if (ParameterOneValue == 0)
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
