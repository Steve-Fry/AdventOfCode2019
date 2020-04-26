using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharedLibrary;
using System;

namespace Advent_of_Code.Day_13
{
    internal class ArcadeMachine
    {
        private List<long> _program;
        IntcodeVirtualMachine _vm;
        Queue<long> _inputQueue;
        Queue<long> _outputQueue;
        public SortedDictionary<int, SortedDictionary<int, ArcadeMachineTile>> _state { get; private set; }

        long _score;
        private int _ballXPosition;

        public ArcadeMachine()
        {
            InitaliseVM();
            _state = new SortedDictionary<int, SortedDictionary<int, ArcadeMachineTile>>();
            _score = 0;
        }

        private void AddTile(ArcadeMachineTile tile)
        {
            int x = tile.X;
            int y = tile.Y;

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
            ReadState();
            WriteToScreen();
            _vm.Run();
            ReadState();
            WriteToScreen();
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
            return _outputQueue.ToList();
        }

        private void ReadState()
        {
            List<long> output = new List<long>(3);
            while (_outputQueue.Count >= 3)
            {
                output.Clear();
                for (int i = 0; i < 3; i++)
                {
                    output.Add(_outputQueue.Dequeue());
                }

                if (output[0] == -1 && output[1] == 0)
                {
                    _score = output[2];
                }
                else
                {
                    ArcadeMachineTile tile = ArcadeMachineTileFactory.GetTile((int)output[0], (int)output[1], (int)output[2]);
                    AddTile(tile);
                }
            }
        }

        private void WriteToScreen()
        {
            int width = _state.Keys.SelectMany(x => _state[x].Keys).Max();
            int height = _state.Keys.Max();

            SortedDictionary<int, ArcadeMachineTile> row;
            ArcadeMachineTile tile;
            Console.WriteLine($"Score: {_score}");
            for (int i = 0; i <= height; i++)
            {
                if (_state.TryGetValue(i, out row))
                {
                    for (int j = 0; j <= width; j++)
                    {
                        if (row.TryGetValue(j, out tile))
                        {
                            Console.Write(tile.ToString());
                        }
                    }
                }
                Console.WriteLine("");
            }
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
