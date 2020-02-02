using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class MultiplyInstruction : InstructionBase, IInstruction
    {
        public MultiplyInstruction(int instructionPointer, int relativeBase, List<long> program, Opcode opcode) : base(instructionPointer, relativeBase, program, opcode) { }

        public override int Execute()
        {
            ParameterThreeValue = ParameterOneValue * ParameterTwoValue;
            return InstructionPointer + 4;
        }
    }
}
