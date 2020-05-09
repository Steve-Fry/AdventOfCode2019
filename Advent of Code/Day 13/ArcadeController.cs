using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Advent_of_Code.Day_13
{
    internal class ArcadeController : IInputProvider, IOutputProvider
    {
        int _ballXPosition;
        int _paddleXPosition;
        public int NumberOfBlocks
        {
            get
            {
                return _state.Values.SelectMany(x => x.Values).Count(x => x is ArcadeMachineBlockTile);
            }
        }
        Queue<long> _outputQueue;
        public SortedDictionary<int, SortedDictionary<int, ArcadeMachineTile>> _state { get; private set; }

        public int Score { get; private set; }

        public ArcadeController()
        {
            _outputQueue = new Queue<long>();
            _state = new SortedDictionary<int, SortedDictionary<int, ArcadeMachineTile>>();
        }

        public long GetInput()
        {
            ReadState();
            // WriteToScreen();

            // Once we have 'completed' the game - allow it to end. 
            if (NumberOfBlocks == 0)
            {
                return 0;
            }

            return Math.Sign(_ballXPosition - _paddleXPosition);
        }

        public void SendOutput(long output)
        {
            _outputQueue.Enqueue(output);
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

        internal void ReadState()
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
                    Score = (int)output[2];
                }
                else
                {
                    ArcadeMachineTile tile = ArcadeMachineTileFactory.GetTile((int)output[0], (int)output[1], (int)output[2]);
                    AddTile(tile);

                    if (tile is ArcadeMachineBallTile)
                    {
                        _ballXPosition = tile.X;
                    }
                    else if (tile is ArcadeMachineHPaddleTile)
                    {
                        _paddleXPosition = tile.X;
                    }
                }
            }
        }

        private void WriteToScreen()
        {
            int width = _state.Keys.SelectMany(x => _state[x].Keys).Max();
            int height = _state.Keys.Max();

            SortedDictionary<int, ArcadeMachineTile> row;
            ArcadeMachineTile tile;
            Console.WriteLine($"Score: {Score}");
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
}
