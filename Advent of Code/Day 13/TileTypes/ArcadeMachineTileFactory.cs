using System;

namespace Advent_of_Code.Day_13
{
    internal static class ArcadeMachineTileFactory
    {
        public static ArcadeMachineTile GetTile(int x, int y, int tileType)
        {
            switch (tileType)
            {
                case 0: { return null; }
                case 1: { return new ArcadeMachineWallTile(x, y); }
                case 2: { return new ArcadeMachineBlockTile(x, y); }
                case 3: { return new ArcadeMachineHPaddleTile(x, y); }
                case 4: { return new ArcadeMachineBallTile(x, y); }
                default:
                    throw new ArgumentException($"Tile Type was invalid ({tileType})");
            }

        }
    }
}
