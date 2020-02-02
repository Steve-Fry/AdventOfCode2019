using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class OutputInstruction : InstructionBase, IInstruction
    {
        private readonly IOutputProvider _outputProvider;


        public OutputInstruction(VirtualMachineState vmState, List<long> program, Opcode opcode, IOutputProvider outputProvider) : base(vmState, program, opcode)
        {
            this._outputProvider = outputProvider;
        }
        
        public override int Execute()
        {
            _outputProvider.SendOutput(ParameterOneValue);
            return _instructionPointer + 2;
        }
    }
}
