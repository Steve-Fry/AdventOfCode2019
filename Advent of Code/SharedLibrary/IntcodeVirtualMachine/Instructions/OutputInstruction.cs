using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using Advent_of_Code.SharedLibrary.IntcodeVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class OutputInstruction : InstructionBase
    {
        private int valueIndex;
        private IOutputProvider outputProvider;

        public OutputInstruction(int instructionPointer, List<int> program, IOutputProvider outputProvider) : base(instructionPointer, program)
        {
            valueIndex = program[instructionPointer + 1];
            this.outputProvider = outputProvider;
        }
        
        public override int Execute()
        {
            outputProvider.SendOutput(program[valueIndex]);

            return instructionPointer + 2;
        }
    }
}
