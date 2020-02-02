using System;
using System.Collections.Generic;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    public static class InstructionFactory
    {
        private static int _instructionsProcessed = 0;

        internal static IInstruction GetInstruction(VirtualMachineState vmState,  List<long> program, IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            int instructionPointer = vmState.InstructionPointer;
            Opcode opcode = new Opcode(program[instructionPointer]);

            _instructionsProcessed += 1;

            switch (opcode.NumericOpcode)
            {
                case 1:
                    return new AddInstruction(vmState, program, opcode);
                case 2:
                    return new MultiplyInstruction(vmState, program, opcode);
                case 3:
                    return new InputInstruction(vmState, program, opcode, inputProvider);
                case 4:
                    return new OutputInstruction(vmState, program, opcode, outputProvider);
                case 5:
                    return new JumpIfTrueInstruction(vmState, program, opcode);
                case 6:
                    return new JumpIfFalseInstruction(vmState, program, opcode);
                case 7:
                    return new LessThanInstruction(vmState, program, opcode);
                case 8:
                    return new EqualsInstruction(vmState, program, opcode);
                case 9:
                    return new AdjustRelativeBaseInstruction(vmState, program, opcode);
                case 99:
                    return new StopInstruction(vmState, program, opcode);
                default:
                    System.IO.File.WriteAllText("MemoryDebug.txt", String.Join(',', program));
                    throw new ArgumentException($"Passed invalid opcode = {opcode.NumericOpcode}, last instructionPointer = {instructionPointer}, instructionsProcessed = {_instructionsProcessed}");
            }
        }
    }
}
