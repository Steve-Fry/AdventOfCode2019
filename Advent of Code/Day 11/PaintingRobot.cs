using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine;
using Advent_of_Code.SharedLibrary.IntcodeVirtualMachine.Input_OutputProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.Day_11
{
    class PaintingRobot
    {
        private readonly PaintableHullSection _hull;

        private List<long> _program;
        private IntcodeVirtualMachine _vm;
        private Queue<long> _inputQueue;
        private Queue<long> _outputQueue;

        public long X { get; private set; }
        public long Y { get; private set; }
        public Direction _direction { get; private set; }

        public int PaintedPanels => _hull.CountPaintedPanels();

        public PaintingRobot(PaintableHullSection hull, int startingColour)
        {
            _program = SharedLibrary.FileParser.GetLongIntCodeFromFile(@"Inputs\Day11Input.txt");
            _inputQueue = new Queue<long>();
            _outputQueue = new Queue<long>();


            _hull = hull;
            RobotInputProvider inputProvider = new RobotInputProvider(_hull, this);
            _vm = new IntcodeVirtualMachine(_program, inputProvider, new QueueOutputProvider(_outputQueue));
            _direction = Direction.North;

            SetStartingColour(startingColour);

            RunRobot();
        }

        private void RunRobot()
        {
            while (_vm.IsDone == false)
            {
                GetOutput();
            }
        }

        private void SetStartingColour(int startingColour)
        {
            _hull.SetColour(0, 0, startingColour);
        }

        private void GetOutput()
        {

            while (_outputQueue.Count == 0)
            {
                _vm.Step();
                if (_vm.IsDone) { return; }
            }
            long paintColour = _outputQueue.Dequeue();

            while (_outputQueue.Count == 0 && _vm.IsDone == false)
            {
                if (_vm.IsDone) { return; }
                _vm.Step();
            }
            long turnDirection = _outputQueue.Dequeue();

            DoPaint(paintColour);
            DoTurn(turnDirection);
            DoMove();
        }

        private void DoTurn(long turnDirection)
        {
            switch (_direction)
            {
                case Direction.North:
                    if (turnDirection == 0) { _direction = Direction.West; }
                    if (turnDirection == 1) { _direction = Direction.East; }
                    break;
                case Direction.South:
                    if (turnDirection == 0) { _direction = Direction.East; }
                    if (turnDirection == 1) { _direction = Direction.West; }
                    break;
                case Direction.East:
                    if (turnDirection == 0) { _direction = Direction.North; }
                    if (turnDirection == 1) { _direction = Direction.South; }
                    break;
                case Direction.West:
                    if (turnDirection == 0) { _direction = Direction.South; }
                    if (turnDirection == 1) { _direction = Direction.North; }
                    break;
                default:
                    break;
            }
        }

        private void DoMove()
        {
            switch (_direction)
            {
                case Direction.North:
                    Y++;
                    break;
                case Direction.South:
                    Y--;
                    break;
                case Direction.East:
                    X++;
                    break;
                case Direction.West:
                    X--;
                    break;
                default:
                    break;
            }
        }
    
        private void DoPaint(long colour)
        {
            _hull.SetColour((int)X, (int)Y, colour);
        }
    }

    
    class RobotInputProvider :IInputProvider
    {
        PaintingRobot _robot;
        PaintableHullSection _hull;

        public RobotInputProvider(PaintableHullSection hullSection, PaintingRobot paintingRobot)
        {
            _robot = paintingRobot;
            _hull = hullSection;
        }

        public long GetInput()
        {
            int x = (int)_robot.X;
            int y = (int)_robot.Y;

            return _hull.GetColour(x, y);
        }
    }

}

