namespace Advent_of_Code.Day_13
{
    internal class ArcadeMachineEmptyTile : ArcadeMachineTile
    {
        public ArcadeMachineEmptyTile(int x, int y) : base(x, y) { }
        public override string ToString()
        {
            return " ";
        }

    }
}
