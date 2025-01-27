using TurnBasedChoiceRPG.Utils.Enums;

namespace TurnBasedChoiceRPG.Models;

public class FloorLevel
{
    public FloorLevel(int height, int width, int relicAmount)
    {
        Height = height;
        Width = width;
        RelicAmount = relicAmount;
        
        FloorTiles = new FloorTileType[Height][];
        for (int i = 0; i < Height; i++)
        {
            FloorTiles[i] = new FloorTileType[Width];
            Array.Fill(FloorTiles[i], FloorTileType.Empty);
        }
    }
    
    public int Height { get; private set; }
    public int Width { get; private set; }
    public int RelicAmount { get; set; }
    public int WellAmount { get; set; }
    public int DangerAmount { get; set; }
    public FloorTileType[][] FloorTiles { get; set; }
}