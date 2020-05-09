namespace Advent_of_Code.Day_13
{
    internal class ArcadeMachineBlockTile : ArcadeMachineTile
    {
        public ArcadeMachineBlockTile(int x, int y) : base(x, y) { }
        public override string ToString()
        {
            return "*";
        }

    }
}
