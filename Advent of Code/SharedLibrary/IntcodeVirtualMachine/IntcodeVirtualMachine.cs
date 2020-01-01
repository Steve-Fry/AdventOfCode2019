using Advent_of_Code.SharedLibrary.IntcodeVM.Instructions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVM
{
    class IntcodeVirtualMachine
    {
        List<int> program;
        int instructionPointer;
        bool isDone = false;

        public IntcodeVirtualMachine(List<int> program)
        {
            this.program = program;
            instructionPointer = 0;
            isDone = false;
        }

        public int Run()
        {
            while (isDone == false)
            {
                Step();
            }
            return program[0];
        }

        public void Step()
        {
            IInstruction instruction = InstructionFactory.GetInstruction(instructionPointer, program);

            if (instruction is StopInstruction)
            {
                isDone = true;
            }
            else
            {
                instructionPointer = instruction.Execute();
            }
        }

        public string GetStateAsString()
        {
            return String.Join(",", program);
        }
        public List<int> GetState()
        {
            return program;
        }
    }
}
