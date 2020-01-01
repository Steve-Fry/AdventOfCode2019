using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    public interface IOutputProvider
    {
        public void SendOutput(int output);
    }
}
