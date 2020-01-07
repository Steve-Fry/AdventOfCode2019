using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using Advent_of_Code.SharedLibrary.IntcodeVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Advent_of_Code.Day_07
{
    public class Amplifier
    {
        private readonly int _input;
        private readonly int _phase;
        private readonly IntcodeVirtualMachine _intcodeVirtualMachine;
        private readonly List<int> _program;
        private readonly string _filename;

        public Amplifier(int input, int phase, List<int> program)
        {
            this._input = input;
            this._phase = phase;
            _program = program;
            _filename = Path.GetTempFileName();

            _intcodeVirtualMachine = new IntcodeVirtualMachine(_program, new StaticInputProvider(new List<int>() { _phase, _input}), new FileOutputProvider(_filename));
        }

        public int Run()
        {
            _intcodeVirtualMachine.Run();
            return int.Parse(File.ReadAllText(_filename));
        }
    }
}
