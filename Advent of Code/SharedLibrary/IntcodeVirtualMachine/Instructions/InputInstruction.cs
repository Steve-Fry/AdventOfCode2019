using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using Advent_of_Code.SharedLibrary.IntcodeVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class InputInstruction : InstructionBase
    {
        private int valueIndex;
        private IInputProvider inputProvider;

        public InputInstruction(int instructionPointer, List<int> program, IInputProvider inputProvider) : base(instructionPointer, program)
        {
            valueIndex = program[instructionPointer + 1];
            this.inputProvider = inputProvider;
        }
        
        public override int Execute()
        {
            int inputNumber = inputProvider.GetInput();
            program[valueIndex] = inputNumber;

            return instructionPointer + 2;
        }
    }
}
