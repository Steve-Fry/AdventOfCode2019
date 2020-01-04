using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    public static class InstructionFactory
    {
        private static int instructionsProcessed = 0;

        public static IInstruction GetInstruction(int instructionPointer, List<int> program, IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            Opcode opcode = new Opcode(program[instructionPointer]);

            instructionsProcessed += 1;

            switch (opcode.NumericOpcode)
            {
                case 1:
                    return new AddInstruction(instructionPointer, program, opcode.Parameter1Mode, opcode.Parameter2Mode, opcode.Parameter3Mode);
                case 2:
                    return new MultiplyInstruction(instructionPointer, program, opcode.Parameter1Mode, opcode.Parameter2Mode, opcode.Parameter3Mode);
                case 3:
                    return new InputInstruction(instructionPointer, program, inputProvider);
                case 4:
                    return new OutputInstruction(instructionPointer, program, outputProvider, opcode.Parameter1Mode);
                case 5:
                    return new JumpInstruction(instructionPointer, program, jumpIfTrue: true, opcode.Parameter1Mode, opcode.Parameter2Mode);
                case 6:
                    return new JumpInstruction(instructionPointer, program, jumpIfTrue: false, opcode.Parameter1Mode, opcode.Parameter2Mode);
                case 7:
                    return new LessThanInstruction(instructionPointer, program, opcode.Parameter1Mode, opcode.Parameter2Mode, opcode.Parameter3Mode);
                case 8:
                    return new EqualsInstruction(instructionPointer, program, opcode.Parameter1Mode, opcode.Parameter2Mode, opcode.Parameter3Mode);
                case 99:
                    return new StopInstruction(instructionPointer, program);
                default:
                    System.IO.File.WriteAllText("MemoryDebug.txt", String.Join(',', program));
                    throw new ArgumentException($"Passed invalid opcode = {opcode.NumericOpcode}, last instructionPointer = {instructionPointer}, instructionsProcessed = {instructionsProcessed}");
            }
        }
    }
}
