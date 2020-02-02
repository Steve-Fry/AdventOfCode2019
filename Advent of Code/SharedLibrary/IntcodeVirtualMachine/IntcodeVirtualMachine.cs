using System;
using System.Collections.Generic;

using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Linq;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine
{
    class IntcodeVirtualMachine
    {
        readonly List<long> _program;

        readonly VirtualMachineState _vmstate;

        private int _relativeBase
        {
            get { return _vmstate.RelativeBaseOffset; }
            set { _vmstate.RelativeBaseOffset = value; }
        }

        private int _instructionPointer
        {
            get { return _vmstate.InstructionPointer; }
            set { _vmstate.InstructionPointer = value; }
        }

        public bool IsDone
        {
            get { return _vmstate.IsDone; }
            private set { _vmstate.IsDone = value; }
        }

        readonly IInputProvider _inputProvider;
        readonly IOutputProvider _outputProvider;

        public IntcodeVirtualMachine(List<long> program, IInputProvider inputProvider = null, IOutputProvider outputProvider = null)
        {
            this._program = program;

            _vmstate = new VirtualMachineState();

            this._inputProvider = inputProvider ?? new ConsoleInputProvider();
            this._outputProvider = outputProvider ?? new ConsoleOutputProvider();
        }

        public IntcodeVirtualMachine(List<int> program, IInputProvider inputProvider = null, IOutputProvider outputProvider = null)
        {
            this._program = program.Select(x => (long)x).ToList();
            _vmstate = new VirtualMachineState();

            this._inputProvider = inputProvider ?? new ConsoleInputProvider();
            this._outputProvider = outputProvider ?? new ConsoleOutputProvider();
        }

        public long Run()
        {
            while (IsDone == false) { Step(); }
            return _program[0];
        }

        public void Step()
        {
            IInstruction instruction = InstructionFactory.GetInstruction(_vmstate, _program, _inputProvider, _outputProvider);

            if (instruction is StopInstruction)
            {
                IsDone = true;
            }
            else
            {
                _instructionPointer = instruction.Execute();
            }
        }

        public string GetStateAsString()
        {
            return String.Join(",", _program);
        }
        public List<long> GetState() => _program;
    }
}
