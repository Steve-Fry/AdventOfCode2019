using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.Day_03
{
    class WirePath
    {
        public Dictionary<Position, int> positions { get; private set; }
        public Position currentPosition { get; private set; }

        private int runningTotal;

        public WirePath()
        {
            positions = new Dictionary<Position, int>();
            //positions.Add(new Position(0, 0), 0);

            currentPosition = new Position(0, 0);
            runningTotal = 0;
        }

        public void Move(string instruction)
        {
            int xDirection;
            int yDirection;

            switch (instruction[0])
            {
                case 'U':
                    xDirection = 0;
                    yDirection = 1;
                    break;
                case 'D':
                    xDirection = 0;
                    yDirection = -1;
                    break;
                case 'L':
                    xDirection = -1;
                    yDirection = 0;
                    break;
                case 'R':
                    xDirection = 1;
                    yDirection = 0;
                    break;
                default:
                    throw new NotImplementedException("Invalid input");
            }

            int steps = int.Parse(instruction.Substring(1, instruction.Length - 1));


            for (int i = 0; i < steps; i++)
            {
                int newX = currentPosition.x + xDirection;
                int newY = currentPosition.y + yDirection;

                runningTotal += 1;

                currentPosition = new Position(newX, newY);
                if (positions.ContainsKey(new Position(newX, newY)) == false)
                {
                    positions.Add(new Position(newX, newY), runningTotal);
                }
            }
        }

        public void MoveAll(List<string> instructions)
        {
            foreach (var instruction in instructions)
            {
                Move(instruction);
            }
        }
    }
}
