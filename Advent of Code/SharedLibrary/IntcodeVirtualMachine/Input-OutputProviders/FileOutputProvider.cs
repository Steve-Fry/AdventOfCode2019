using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    class FileOutputProvider : IOutputProvider
    {
        string filename;
        public FileOutputProvider(string filename)
        {
            this.filename = filename;
        }
        
        public void SendOutput(int output)
        {
            System.IO.File.WriteAllText(filename, output.ToString());
        }
    }
}
