using System;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    class ConsoleOutputProvider : IOutputProvider
    {
        public void SendOutput(long output)
        {
            Console.WriteLine($"Output: {output}");
        }
    }
}
