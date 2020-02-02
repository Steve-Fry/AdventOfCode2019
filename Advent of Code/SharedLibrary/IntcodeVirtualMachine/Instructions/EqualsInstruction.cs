using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class EqualsInstruction : InstructionBase, IInstruction
    {
        public EqualsInstruction(int instructionPointer, int relativeBase, List<long> program, Opcode opcode) : base(instructionPointer, relativeBase, program, opcode) { }

        public override int Execute()
        {
            ParameterThreeValue = ParameterOneValue == ParameterTwoValue ? 1 : 0;
            return InstructionPointer + 4;
        }
    }
}

