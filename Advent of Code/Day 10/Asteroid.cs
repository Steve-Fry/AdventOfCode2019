using System;

namespace Advent_of_Code.Day_10
{
    internal class Asteroid
    {
        public int X { get; }
        public int Y { get; }
        public int AsteroidsVisible { get; set; }

        public Asteroid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double GetSlope(Asteroid asteroid)
        {
            double deltaY = asteroid.Y - this.Y;
            double deltaX = asteroid.X - this.X;
            return Math.Atan2(deltaY, deltaX);
        }
    }
}
