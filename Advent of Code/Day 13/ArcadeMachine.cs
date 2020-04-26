using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharedLibrary;

namespace Advent_of_Code.Day_13
{
    internal class ArcadeMachine
    {
        private List<long> _program;
        IntcodeVirtualMachine _vm;
        Queue<long> _inputQueue;
        Queue<long> _outputQueue;
        public SortedDictionary<int, SortedDictionary<int, ArcadeMachineTile>> _state { get; private set; }

        public ArcadeMachine()
        {
            InitaliseVM();
        }

        private void SetState(int x, int y, ArcadeMachineTile tile)
        {
            if (!_state.ContainsKey(y))
            {
                _state[y] = new SortedDictionary<int, ArcadeMachineTile>();
            }
            _state[y][x] = tile;
        }

        public void RunMachine()
        {
            DisablePayment();
            _vm.Run();
            Debug.WriteLine("Hello World");
        }

        private void InitaliseVM()
        {
            _program = SharedLibrary.FileParser.GetLongIntCodeFromFile(@"Inputs\Day13Input.txt");
            _inputQueue = new Queue<long>();
            _outputQueue = new Queue<long>();

            IInputProvider inputProvider = new JoyStickInputProvider();
            QueueOutputProvider outputProvider = new QueueOutputProvider(_outputQueue);

            _vm = new IntcodeVirtualMachine(_program, inputProvider, outputProvider);
        }

        private void DisablePayment()
        {
            _program[0] = 2;
        }

        public List<long> GetInitialScreenOutput()
        {
            _vm.Run();
            _inputQueue.Enqueue(0);
            return _outputQueue.ToList();
        }
    }

    internal class JoyStickInputProvider : IInputProvider
    {
        public long GetInput()
        {
            return 1;
        }
    }
}
