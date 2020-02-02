namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders
{
    class FileOutputProvider : IOutputProvider
    {
        readonly string _filename;
        public FileOutputProvider(string filename)
        {
            this._filename = filename;
        }
        
        public void SendOutput(long output)
        {
            System.IO.File.WriteAllText(_filename, output.ToString());
        }
    }
}
