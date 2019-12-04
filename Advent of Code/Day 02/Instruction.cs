using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.Day_02
{
    class Instruction
    {

        public Instruction(List<int> command)
        {
            opcode = command[0];
            if (command.Count > 1)
            {
                parameter1 = command[1];
                parameter2 = command[2];
                parameter3 = command[3];
            }
        }

        public int opcode { get; private set; }
        public int parameter1 { get; private set; }
        public int parameter2 { get; private set; }
        public int parameter3 { get; private set; }
    }
}
