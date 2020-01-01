using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    class ConsoleOutputProvider : IOutputProvider
    {
        public void SendOutput(int output)
        {
            Console.WriteLine($"Output: {output}");
        }
    }
}
