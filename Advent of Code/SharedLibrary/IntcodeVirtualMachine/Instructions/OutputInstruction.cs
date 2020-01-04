using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using Advent_of_Code.SharedLibrary.IntcodeVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class OutputInstruction : InstructionBase
    {
        protected int parameter1Value;
        protected ParameterMode parameter1Mode;
        private IOutputProvider outputProvider;

        public int Value1
        {
            get
            {
                switch (parameter1Mode)
                {
                    case ParameterMode.immediate:
                        return parameter1Value;
                    case ParameterMode.position:
                        return program[parameter1Value];
                    default:
                        throw new ApplicationException("Invalid Parameter mode encountered"); ;
                }
            }
        }

        public OutputInstruction(int instructionPointer, List<int> program, IOutputProvider outputProvider, ParameterMode parameter1Mode) : base(instructionPointer, program)
        {
            this.parameter1Mode = parameter1Mode;
            parameter1Value = program[instructionPointer + 1];
            this.outputProvider = outputProvider;
        }
        
        public override int Execute()
        {
            outputProvider.SendOutput(Value1);

            return instructionPointer + 2;
        }
    }
}
