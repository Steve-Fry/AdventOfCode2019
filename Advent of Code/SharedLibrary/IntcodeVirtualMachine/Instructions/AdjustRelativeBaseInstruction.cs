using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    class AdjustRelativeBaseInstruction : InstructionBase, IInstruction
    {
        public AdjustRelativeBaseInstruction(VirtualMachineState vmState, List<long> program, Opcode opcode) : base(vmState, program, opcode) { }
        
        public override int Execute()
        {
            this._vmState.RelativeBaseOffset += (int)ParameterOneValue;
            return _instructionPointer + 2;
        }
    }
}
