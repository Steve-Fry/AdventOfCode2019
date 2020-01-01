using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    public static class InstructionFactory
    {

        public static IInstruction GetInstruction(int instructionPointer, List<int> program, IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            Opcode opcode = new Opcode(program[instructionPointer]);

            switch (opcode.NumericOpcode)
            {
                case 1:
                    return new AddInstruction(instructionPointer, program, opcode.Parameter1Mode, opcode.Parameter2Mode, opcode.Parameter3Mode);
                case 2:
                    return new MultiplyInstruction(instructionPointer, program, opcode.Parameter1Mode, opcode.Parameter2Mode, opcode.Parameter3Mode);
                case 3:
                    return new InputInstruction(instructionPointer, program, inputProvider);
                case 4:
                    return new OutputInstruction(instructionPointer, program, outputProvider);
                case 99:
                    return new StopInstruction(instructionPointer, program);
                default:
                    throw new ArgumentException($"Passed invalid opcode = {opcode}");
            }
        }




    }
}
