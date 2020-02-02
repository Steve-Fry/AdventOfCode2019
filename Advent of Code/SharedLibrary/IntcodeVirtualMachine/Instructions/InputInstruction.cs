using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class InputInstruction : InstructionBase, IInstruction
    {
        private readonly IInputProvider _inputProvider;

        public InputInstruction(VirtualMachineState vmState, List<long> program, Opcode opcode, IInputProvider inputProvider) : base(vmState, program, opcode)
        {
            this._inputProvider = inputProvider;
        }
        
        public override int Execute()
        {
            ParameterOneValue = _inputProvider.GetInput();
            return _instructionPointer + 2;
        }
    }
}
