using System;
using System.Collections.Generic;
using System.Text;
using Advent_of_Code.SharedLibrary.IntcodeVM.Instructions;

namespace Advent_of_Code.SharedLibrary.IntcodeVM
{
    public static class InstructionFactory
    {

        public static IInstruction GetInstruction(int instructionPointer, List<int> program)
        {
            int opcode = program[instructionPointer];

            switch (opcode)
            {
                case 1:
                    return new AddInstruction(instructionPointer, program);
                case 2:
                    return new MultiplyInstruction(instructionPointer, program);
                case 99:
                    return new StopInstruction(instructionPointer, program);
                default:
                    throw new ArgumentException($"Passed invalid opcode = {opcode}");
            }
        }
    }
}
