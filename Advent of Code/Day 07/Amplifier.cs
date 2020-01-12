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

        public Amplifier(int input, int phase, List<int> program, IInputProvider inputProvider = null, IOutputProvider outputProvider = null)
        {
            this._input = input;
            this._phase = phase;
            _program = program;
            _filename = Path.GetTempFileName();

            inputProvider ??= new StaticInputProvider(new List<int>() { _phase, _input });
            outputProvider ??= new FileOutputProvider(_filename);

            _intcodeVirtualMachine = new IntcodeVirtualMachine(_program, inputProvider, outputProvider);
        }

        public int Run()
        {
            _intcodeVirtualMachine.Run();
            return int.Parse(File.ReadAllText(_filename));
        }
    }
}
