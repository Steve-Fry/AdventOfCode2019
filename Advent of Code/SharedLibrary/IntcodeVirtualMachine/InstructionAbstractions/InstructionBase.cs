using System;
using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    abstract class InstructionBase : IInstruction
    {
        protected VirtualMachineState _vmState;

        protected int _relativeBase
        {
            get { return _vmState.RelativeBaseOffset; }
            set { _vmState.RelativeBaseOffset = value; }
        }

        protected int _instructionPointer
        {
            get { return _vmState.InstructionPointer; }
            set { _vmState.InstructionPointer = value; }
        }

        protected List<long> Program { get; }
        protected Opcode Opcode { get; }

        public InstructionBase(VirtualMachineState vmState, List<long> program, Opcode opcode)
        {
            this._vmState = vmState;
            this.Program = program;
            this.Opcode = opcode;
        }

        private void ValidateAndExtendMemory(int positionReference)
        {
            if (positionReference < 0)
            {
                throw new ArgumentException($"Attempted to address invalid address {positionReference}");
            }
            else if (positionReference > Program.Count -1)
            {
                ExtendProgramMemory(positionReference);
            }
        }

        private void ExtendProgramMemory(int positionReference)
        {
            Program.Capacity = positionReference + 1;
            for (int i = Program.Count; i < positionReference + 1; i++)
            {
                Program.Add(0);
            }
        }

        private long GetParameter(int paramNumber)
        {
            int positionReference;
            switch (Opcode.ParameterModes[paramNumber])
            {
                case ParameterMode.Immediate:
                    positionReference = _instructionPointer + paramNumber + 1;
                    break;
                case ParameterMode.Position:
                    positionReference = (int)Program[_instructionPointer + paramNumber + 1];
                    break;
                case ParameterMode.Relative:
                    positionReference = (int)Program[_instructionPointer + paramNumber + 1] + _relativeBase;
                    break;
                default:
                    throw new ArgumentException("Unable to get Parameter value");
            }
            ValidateAndExtendMemory(positionReference);
            return Program[positionReference];
        }

        private void SetParameter(int paramNumber, long value)
        {
            int positionReference;
            switch (Opcode.ParameterModes[paramNumber])
            {
                case ParameterMode.Immediate:
                    throw new ArgumentException("Cannot set a value for an immediate Parameter");
                case ParameterMode.Position:
                    positionReference = (int)Program[_instructionPointer + paramNumber + 1];
                    break;
                case ParameterMode.Relative:
                    positionReference = (int)Program[_instructionPointer + paramNumber + 1] + _relativeBase;
                    break;
                default:
                    throw new ArgumentException("Unable to set Parameter value");
            }

            ValidateAndExtendMemory(positionReference);
            Program[positionReference] = value;
        }

        protected long ParameterOneValue
        {
            get { return GetParameter(0); }
            set { SetParameter(0, value); }
        }
        protected long ParameterTwoValue
        {
            get { return GetParameter(1); }
            set { SetParameter(1, value); }
        }
        protected long ParameterThreeValue
        {
            get { return GetParameter(2); }
            set { SetParameter(2, value); }
        }

        abstract public int Execute();
    }
}
