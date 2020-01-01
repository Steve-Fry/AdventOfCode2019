using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVM
{
    public interface IInstruction
    {
        public int Execute();
    }
}
