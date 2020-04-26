using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine;
using System.Collections.Generic;

namespace Advent_of_Code.Day_13
{
    internal class ArcadeMachine
    {
        private List<long> _program;
        IntcodeVirtualMachine _vm;
        private ArcadeController _controller;

        public ArcadeMachine()
        {
            _controller = new ArcadeController();
            InitaliseVM();
        }

        public int GetInitialBlockCount()
        {
            _vm.Run();
            _controller.ReadState();
            return _controller.NumberOfBlocks;
        }

        public int PlayGameUntilCompleted()
        {
            // Start by running until completion
            _vm.Run();
            _controller.ReadState();

            // Set memory location 0 to value 2 in order to proceed.
            DisablePayment();

            // The vm halts after the first part is completed. 
            // Reset instruction pointers/isDone flag and continue. 
            _vm.Reset();
            _vm.Run();

            // Second halt - we are done. Process the final output buffer.
            _controller.ReadState();

            // And return the score from the controller
            return _controller.Score;
        }

        private void InitaliseVM()
        {
            _program = SharedLibrary.FileParser.GetLongIntCodeFromFile(@"Inputs\Day13Input.txt");
            _vm = new IntcodeVirtualMachine(_program, _controller, _controller);
        }

        private void DisablePayment()
        {
            _program[0] = 2;
        }
    }
}