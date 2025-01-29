using TurnBasedChoiceRPG.Components.World;
using TurnBasedChoiceRPG.Entities;
using TurnBasedChoiceRPG.Utilities.Enums;

namespace TurnBasedChoiceRPG.Systems.Render;

public class FloorRenderSystem
{
    public void RenderFloor(Entity? floor)
    {
        if (floor is null)
            throw new InvalidOperationException("RenderFloor: floor cannot be null.");
        var grid = floor.GetComponent<TileGridComponent>();
        var data = floor.GetComponent<FloorDataComponent>();
        
        for (int i = 0; i < grid.Height; i++)
        {
            for (int j = 0; j < grid.Width; j++)
            {
                Console.Write(GetTileSymbol(grid.Tiles[i, j]));
            }
            Console.WriteLine();
        }
        
        Console.WriteLine($"\nRelics: {data.RelicAmount}" +
                          $"\nDangers: {data.DangerAmount}" +
                          $"\nWells: {data.WellAmount}" +
                          $"\nCurrent Floor: {data.FloorNumber + 1} out of {data.TotalFloors}\n\n");
    }

    private string GetTileSymbol(FloorTileType tileType) => tileType switch
    {
        FloorTileType.Relic => " ‡ ",
        FloorTileType.Danger => " ¤ ",
        FloorTileType.Well => " † ",
        _ => " - "
    };
}