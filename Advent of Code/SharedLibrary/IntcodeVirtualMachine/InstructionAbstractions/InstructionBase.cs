using System;
using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    abstract class InstructionBase : IInstruction
    {
        public int InstructionPointer { get; }
        public int RelativeBase { get; }
        public List<long> Program { get; }
        public Opcode Opcode { get; }

        public bool IsSelfReferencing { private set; get; }

        public InstructionBase(int instructionPointer, int relativeBase, List<long> program, Opcode opcode)
        {
            this.InstructionPointer = instructionPointer;
            this.RelativeBase = relativeBase;
            this.Program = program;
            this.Opcode = opcode;
        }

        private long GetParameter(int paramNumber)
        {
            int positionReference;
            switch (Opcode.ParameterModes[paramNumber])
            {
                case ParameterMode.Immediate:
                    return Program[InstructionPointer + paramNumber + 1];
                case ParameterMode.Position:
                    positionReference = (int)Program[InstructionPointer + paramNumber + 1];
                    return Program[positionReference];
                case ParameterMode.Relative:
                    positionReference = (int)Program[InstructionPointer + paramNumber + 1] + RelativeBase;
                    return Program[positionReference];
                default:
                    throw new ArgumentException("Unable to get Parameter value");
            }
        }

        private void SetParameter(int paramNumber, long value)
        {
            int positionReference;
            switch (Opcode.ParameterModes[paramNumber])
            {
                case ParameterMode.Immediate:
                    throw new ArgumentException("Cannot set a value for an immediate Parameter");
                case ParameterMode.Position:
                    positionReference = (int)Program[InstructionPointer + paramNumber + 1];
                    Program[positionReference] = value;
                    return;
                case ParameterMode.Relative:
                    positionReference = (int)Program[InstructionPointer + paramNumber + 1] + RelativeBase;
                    Program[positionReference] = value;
                    return;
                default:
                    throw new ArgumentException("Unable to set Parameter value");
            }
        }

        public long ParameterOneValue
        {
            get { return GetParameter(0); }
            set { SetParameter(0, value); }
        }
        public long ParameterTwoValue
        {
            get { return GetParameter(1); }
            set { SetParameter(1, value); }
        }
        public long ParameterThreeValue
        {
            get { return GetParameter(2); }
            set { SetParameter(2, value); }
        }

        abstract public int Execute();
    }
}
