using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVM
{
    abstract class InstructionBase : IInstruction
    {
        public int instructionPointer { get;}
        public List<int> program { get; }

        public InstructionBase(int instructionPointer, List<int> program)
        {
            this.instructionPointer = instructionPointer;
            this.program = program;
        }

        abstract public int Execute();
    }
}
