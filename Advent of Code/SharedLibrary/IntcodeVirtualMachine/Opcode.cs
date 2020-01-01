using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine
{
    internal class Opcode
    {
        int FullOpcode;
        string FullStringOpcode;

        public int NumericOpcode { private set; get; }
        public ParameterMode Parameter1Mode { private set; get; }
        public ParameterMode Parameter2Mode { private set; get; }
        public ParameterMode Parameter3Mode { private set; get; }


        public Opcode(int opcode)
        {
            FullOpcode = opcode;

            //if (FullOpcode < 100)
            //{
            //    SetupSimpleOpcode();
            //}
            //else
            //{
                SetupCompositeOpcode();
            //}
        }

        private void SetupCompositeOpcode()
        {
            FullStringOpcode = FullOpcode.ToString();
            if (FullStringOpcode.Length >=2)
            {
                NumericOpcode = int.Parse(FullStringOpcode.Substring(FullStringOpcode.Length - 2));
            }
            else
            {
                NumericOpcode = FullOpcode;
            }

            
            if (FullStringOpcode.Length >= 3)
            {
                Parameter1Mode = FullStringOpcode[FullStringOpcode.Length - 3] == '1' ? ParameterMode.immediate : ParameterMode.position;
            }
            else
            {
                Parameter1Mode = ParameterMode.position;
            }

            if (FullStringOpcode.Length >= 4)
            {
                Parameter2Mode = FullStringOpcode[FullStringOpcode.Length - 4] == '1' ? ParameterMode.immediate : ParameterMode.position;
            }
            else
            {
                Parameter2Mode = ParameterMode.position;
            }

            if (FullStringOpcode.Length == 5)
            {
                Parameter3Mode = FullStringOpcode[FullStringOpcode.Length - 5] == '1' ? ParameterMode.immediate : ParameterMode.position;
            }
            else
            {
                Parameter3Mode = ParameterMode.position;
            }
        }

        //private void SetupSimpleOpcode()
        //{
        //    Parameter1Mode = ParameterMode.position;
        //    Parameter2Mode = ParameterMode.position;
        //    Parameter3Mode = ParameterMode.position;
        //    NumericOpcode = FullOpcode;
        //}

    }
}
