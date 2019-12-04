using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.Day_03
{
    class WirePath
    {
        public HashSet<Position> positions { get; private set; }
        public Position currentPosition { get; private set; }

        public WirePath()
        {
            positions = new HashSet<Position>();
            positions.Add(new Position(0, 0));



            currentPosition = new Position(0, 0);
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

                currentPosition = new Position(newX, newY);
                positions.Add(new Position(newX, newY));
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
