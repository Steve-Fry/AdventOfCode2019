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
            var intersections = from a in wirePath1.positions
                               join b in wirePath2.positions on a.Key equals b.Key
                               select a;

            return intersections.Select(a => Math.Abs(a.Key.x) + Math.Abs(a.Key.y)).Min();
        }

        public int GetFirstCrossing()
        {
            var intersections = from a in wirePath1.positions
                                join b in wirePath2.positions on a.Key equals b.Key
                                orderby (a.Value + b.Value) ascending
                                select a.Value + b.Value;

            return intersections.Take(1).ToList()[0];

        }
    }
}
