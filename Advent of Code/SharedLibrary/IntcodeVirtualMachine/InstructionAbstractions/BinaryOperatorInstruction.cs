using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    abstract class BinaryOperatorInstruction : InstructionBase
    {
        protected int parameter1Value;
        protected int parameter2Value;
        protected int outputIndex;

        protected ParameterMode parameter1mode;
        protected ParameterMode parameter2mode;

        public int Input1Value
        {
            get
            {
                switch (parameter1mode)
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

        public int Input2Value
        {
            get
            {
                switch (parameter2mode)
                {
                    case ParameterMode.immediate:
                        return parameter2Value;
                    case ParameterMode.position:
                        return program[parameter2Value];
                    default:
                        throw new ApplicationException("Invalid Parameter mode encountered"); ;
                }
            }
        }

        protected bool isSelfReferencing
        {
            // Used in instructions which may modify data within the running instruction, these should not automatically increment the instruction pointer. 
            get
            {
                if (parameter1mode == ParameterMode.position && parameter1Value >= instructionPointer && parameter1Value <= instructionPointer + 4)
                {
                    return true;
                }

                if (parameter2mode == ParameterMode.position && parameter2Value >= instructionPointer && parameter2Value <= instructionPointer + 4)
                {
                    return true;
                }

                if (parameter2mode == ParameterMode.position && parameter2Value >= instructionPointer && parameter2Value <= instructionPointer + 4)
                {
                    return true;
                }
                return false;
            }
        }

    public BinaryOperatorInstruction(int instructionPointer, List<int> program, ParameterMode parameter1Mode, ParameterMode parameter2Mode, ParameterMode parameter3Mode) : base(instructionPointer, program)
        {
            parameter1Value = program[instructionPointer + 1];
            parameter2Value = program[instructionPointer + 2];
            outputIndex = program[instructionPointer + 3];

            this.parameter1mode = parameter1Mode;
            this.parameter2mode = parameter2Mode;
        }
    }
}
