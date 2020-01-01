using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVM
{
    abstract class BinaryOperatorInstruction : InstructionBase
    {
        protected int input1ValueIndex;
        protected int input2ValueIndex;
        protected int outputIndex;

        public int Input1Value => program[input1ValueIndex];
        public int Input2Value => program[input2ValueIndex];

        public BinaryOperatorInstruction(int instructionPointer, List<int> program) : base(instructionPointer, program)
        {
            input1ValueIndex = program[instructionPointer + 1];
            input2ValueIndex = program[instructionPointer + 2];
            outputIndex = program[instructionPointer + 3];
        }
    }
}
