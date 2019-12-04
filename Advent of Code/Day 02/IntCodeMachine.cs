using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.Day_02
{
    class IntCodeMachine
    {
        List<int> memory;
        int instructionPointer;
        bool isDone;
        int valuesPerInstruction;

        public IntCodeMachine(List<int> memory)
        {
            this.memory = memory;
            instructionPointer = 0;
            isDone = false;
            valuesPerInstruction = 4;
        }

        public int Run()
        {
            while (isDone == false)
            {
                Step();
            }
            return memory[0];
        }

        public void Step()
        {

            List<int> command;
            try 
            { 
                command = memory.GetRange(instructionPointer, valuesPerInstruction); 
            }
            catch (ArgumentException e)
            {
                command = memory.GetRange(instructionPointer, 1);
            }

            Instruction operation = new Instruction(command);

            switch (operation.opcode)
            {
                case 99:
                    isDone = true;
                    break;
                case 1:
                    DoAdd(operation);
                    break;
                case 2:
                    DoMultiply(operation);
                    break;
            }
        }

        private void DoAdd(Instruction operation)
        {
            memory[operation.parameter3] = memory[operation.parameter1] + memory[operation.parameter2];
            instructionPointer += 4;
        }

        private void DoMultiply(Instruction operation)
        {
            memory[operation.parameter3] = memory[operation.parameter1] * memory[operation.parameter2];
            instructionPointer += 4;
        }

        public string GetStateAsString()
        {
            return String.Join(",", memory);
        }
        public List<int> GetState()
        {
            return memory;
        }
    }
}
