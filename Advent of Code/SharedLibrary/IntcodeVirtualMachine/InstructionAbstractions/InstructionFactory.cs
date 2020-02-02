using System;
using System.Collections.Generic;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Instructions
{
    public static class InstructionFactory
    {
        private static int _instructionsProcessed = 0;

        public static IInstruction GetInstruction(int instructionPointer, int relativeBase, List<long> program, IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            Opcode opcode = new Opcode(program[instructionPointer]);

            _instructionsProcessed += 1;

            switch (opcode.NumericOpcode)
            {
                case 1:
                    return new AddInstruction(instructionPointer, relativeBase, program, opcode);
                case 2:
                    return new MultiplyInstruction(instructionPointer, relativeBase, program, opcode);
                case 3:
                    return new InputInstruction(instructionPointer, relativeBase, program, opcode, inputProvider);
                case 4:
                    return new OutputInstruction(instructionPointer, relativeBase, program, opcode, outputProvider);
                case 5:
                    return new JumpIfTrueInstruction(instructionPointer, relativeBase, program, opcode);
                case 6:
                    return new JumpIfFalseInstruction(instructionPointer, relativeBase, program, opcode);
                case 7:
                    return new LessThanInstruction(instructionPointer, relativeBase, program, opcode);
                case 8:
                    return new EqualsInstruction(instructionPointer, relativeBase, program, opcode);
                case 99:
                    return new StopInstruction(instructionPointer, relativeBase, program, opcode);
                default:
                    System.IO.File.WriteAllText("MemoryDebug.txt", String.Join(',', program));
                    throw new ArgumentException($"Passed invalid opcode = {opcode.NumericOpcode}, last instructionPointer = {instructionPointer}, instructionsProcessed = {_instructionsProcessed}");
            }
        }
    }
}
