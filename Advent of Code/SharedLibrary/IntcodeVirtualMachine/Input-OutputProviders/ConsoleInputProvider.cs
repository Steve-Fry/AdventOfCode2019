using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    class ConsoleInputProvider : IInputProvider
    {
        public int GetInput()
        {
            Console.WriteLine("Enter your input");
            string input = Console.ReadLine();
            int inputNumber = int.Parse(input);
            return inputNumber;
        }
    }
}
