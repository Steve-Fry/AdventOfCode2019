using System;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    class ConsoleInputProvider : IInputProvider
    {
        public long GetInput()
        {
            Console.WriteLine("Enter your input");
            string input = Console.ReadLine();
            long inputNumber = long.Parse(input);
            return inputNumber;
        }
    }
}
