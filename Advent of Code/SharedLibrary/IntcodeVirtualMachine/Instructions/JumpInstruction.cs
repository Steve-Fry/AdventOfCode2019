using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using Advent_of_Code.SharedLibrary.IntcodeVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class JumpInstruction : UnaryOperatorInstruction
    {
        private int valueIndex;
        private int jumpDestination;
        private bool jumpIfTrue;

        public JumpInstruction(int instructionPointer, List<int> program, bool jumpIfTrue, ParameterMode inputParameterMode, ParameterMode outputParameterMode) : base(instructionPointer, program, inputParameterMode, outputParameterMode)
        {
            this.jumpIfTrue = jumpIfTrue;
            valueIndex = program[instructionPointer + 1];
            jumpDestination = program[instructionPointer + 2];
        }

        public override int Execute()
        {
            switch (jumpIfTrue)
            {
                case true:
                    if (InputValue != 0) { return OutputValue; };
                    break;
                case false:
                    if (InputValue == 0) { return OutputValue; };
                    break;
            }
            return instructionPointer + 3;
        }
    }
}
