using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    abstract class UnaryOperatorInstruction : InstructionBase
    {
        protected int inputParameterValue;
        protected int outputParameterValue;

        protected ParameterMode inputParameterMode;
        protected ParameterMode outputParameterMode;

        public int InputValue
        {
            get
            {
                switch (inputParameterMode)
                {
                    case ParameterMode.immediate:
                        return inputParameterValue;
                    case ParameterMode.position:
                        return program[inputParameterValue];
                    default:
                        throw new ApplicationException("Invalid Parameter mode encountered"); ;
                }
            }
        }

        public int OutputValue
        {
            get
            {
                switch (outputParameterMode)
                {
                    case ParameterMode.immediate:
                        return outputParameterValue;
                    case ParameterMode.position:
                        return program[outputParameterValue];
                    default:
                        throw new ApplicationException("Invalid Parameter mode encountered"); ;
                }
            }
        }

        protected bool IsSelfReferencing
        {
            // Used in instructions which may modify data within the running instruction, these should not automatically increment the instruction pointer. 
            get
            {
                return outputParameterMode == ParameterMode.position && outputParameterValue >= instructionPointer && outputParameterValue <= instructionPointer + 3;
            }
        }

    public UnaryOperatorInstruction(int instructionPointer, List<int> program, ParameterMode inputParameterMode, ParameterMode outputParameterMode) : base(instructionPointer, program)
        {
            inputParameterValue = program[instructionPointer + 1];
            outputParameterValue = program[instructionPointer + 2];

            this.inputParameterMode = inputParameterMode;
            this.outputParameterMode = outputParameterMode;
        }
    }
}
