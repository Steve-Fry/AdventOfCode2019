namespace Advent_of_Code.Day_13
{
    internal abstract class ArcadeMachineTile
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public ArcadeMachineTile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
