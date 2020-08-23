using Advent_of_Code.Day_15.Enums;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Advent_of_Code.Day_15
{
    internal class RepairDroidController : IInputProvider, IOutputProvider
    {
        int XPosition { get; }
        int YPosition { get; }

        public long GetInput()
        {
            throw new NotImplementedException();
        }

        public void SendOutput(long output)
        {
            throw new NotImplementedException();
        }
    }
}
