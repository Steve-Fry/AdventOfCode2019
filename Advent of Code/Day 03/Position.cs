using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.Day_03
{
    //class Position : IEquatable<Position>
    //{
    //    public Position(int x, int y)
    //    {
    //        this.x = x;
    //        this.y = y;

    //    }
    //    public int x { get; private set; }
    //    public int y { get; private set; }

    //    public override bool Equals(object obj)
    //    {
    //        return this.Equals(obj);
    //    }


    //}

    struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}