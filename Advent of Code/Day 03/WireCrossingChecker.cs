using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.Day_03
{
    class WireCrossingChecker
    {

        WirePath wirePath1;
        WirePath wirePath2;

        public WireCrossingChecker(string wire1, string wire2)
        {
            wirePath1 = new WirePath();
            List<string> instructions1 = InputParser.ParseString(wire1);
            wirePath1.MoveAll(instructions1);

            wirePath2 = new WirePath();
            List<string> instructions2 = InputParser.ParseString(wire2);
            wirePath2.MoveAll(instructions2);
        }

        public int GetClosestIntersection()
        {
            
            wirePath1.positions.IntersectWith(wirePath2.positions);

            // The intersection at 0,0 is not valid. 
            wirePath1.positions.Remove(new Position(0, 0));

            return wirePath1.positions.Select(a => Math.Abs(a.x) + Math.Abs(a.y)).Min();
        }
    }
}
