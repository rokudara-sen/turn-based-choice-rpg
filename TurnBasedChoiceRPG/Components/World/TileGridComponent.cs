using TurnBasedChoiceRPG.Utilities.Enums;

namespace TurnBasedChoiceRPG.Components.World;

public struct TileGridComponent
{
    public FloorTileType[,] Tiles;
    public int Height;
    public int Width;
}