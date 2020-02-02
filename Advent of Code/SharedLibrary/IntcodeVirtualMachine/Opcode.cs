using System;
using System.Collections.Generic;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine
{
    internal class Opcode
    {
        readonly long _integerOpcode;
        readonly string _stringOpcode;
        
        public List<ParameterMode> ParameterModes { private set; get; }
        public long NumericOpcode { private set; get; }

        public Opcode(long opcode)
        {
            _integerOpcode = opcode;
            _stringOpcode = _integerOpcode.ToString().PadLeft(5, '0'); // Assumption: Opcodes are 5 digit integers as per AOC Day5.

            ParameterModes = new List<ParameterMode>(3);
            
            PopulateParametermodes();

            NumericOpcode = long.Parse(_stringOpcode.Substring(_stringOpcode.Length - 2));
        }

        private void PopulateParametermodes()
        {
            for (int i = 2; i >= 0; i--) // Starting from position 2, step back through 1 and 0.
            {
                switch (_stringOpcode[i])
                {
                    case '0':
                        ParameterModes.Add(ParameterMode.Position);
                        break;
                    case '1':
                        ParameterModes.Add(ParameterMode.Immediate);
                        break;
                    case '2':
                        ParameterModes.Add(ParameterMode.Relative);
                        break;
                    default:
                        throw new ArgumentException("Attempted to use an invalid opcode parameter mode");
                }
            }
        }
    }
}
