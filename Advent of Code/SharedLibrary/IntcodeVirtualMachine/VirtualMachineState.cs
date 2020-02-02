namespace Advent_of_Code.SharedLibrary.IntcodeVirtualMachine
{
    internal class VirtualMachineState
    {
        public int InstructionPointer { get; set; } = 0;
        public int RelativeBaseOffset { get; set; } = 0;
        public bool IsDone { get; set; } = false;
    }
}
