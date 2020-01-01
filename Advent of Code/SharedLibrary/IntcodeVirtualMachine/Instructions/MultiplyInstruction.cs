using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class MultiplyInstruction : BinaryOperatorInstruction, IInstruction
    {

        public MultiplyInstruction(int instructionPointer, List<int> program, ParameterMode parameter1Mode, ParameterMode parameter2Mode, ParameterMode parameter3Mode) : base(instructionPointer, program, parameter1Mode, parameter2Mode, parameter3Mode)
        {
        }

        public override int Execute()
        {
            program[outputIndex] = Input1Value * Input2Value;
            return instructionPointer + 4;
        }
    }
}
