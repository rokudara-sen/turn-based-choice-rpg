using System.Security.Cryptography;
using TurnBasedChoiceRPG.Components.World;
using TurnBasedChoiceRPG.Entities;
using TurnBasedChoiceRPG.Entities.Archetypes;
using TurnBasedChoiceRPG.Utilities;
using TurnBasedChoiceRPG.Utilities.Enums;

namespace TurnBasedChoiceRPG.Systems.World;

public class MapGenerationSystem
{
    public Entity GenerateFloor(int floorNumber, int totalFloors)
    {
        const int minHeight = 10, maxHeight = 40;
        const int minWidth = 10, maxWidth = 40;

        var entityManager = ServiceLocatorUtils.GetRequiredService<EntityManager>();
        
        var entity = FloorArchetype.Create(entityManager);
        
        int height = RandomNumberGenerator.GetInt32(minHeight, maxHeight);
        int width = RandomNumberGenerator.GetInt32(minWidth, maxWidth);

        var tileGridComponent = new TileGridComponent
        {
            Height = height,
            Width = width,
            Tiles = new FloorTileType[height, width]
        };

        var floorDataComponent = new FloorDataComponent
        {
            FloorNumber = floorNumber,
            TotalFloors = totalFloors,
            RelicAmount = RandomNumberGenerator.GetInt32((height * width) / 100, (height * width) / 50)
        };
        
        entity.UpdateComponent(tileGridComponent);
        entity.UpdateComponent(floorDataComponent);
        
        RandomizeTiles(ref tileGridComponent, ref floorDataComponent);
        
        entity.UpdateComponent(tileGridComponent);
        entity.UpdateComponent(floorDataComponent);
        
        return entity;
    }
    
    private void RandomizeTiles(ref TileGridComponent grid, ref FloorDataComponent data)
    {
        var positions = new List<(int x, int y)>();
        for (int i = 0; i < grid.Height; i++)
        {
            for (int j = 0; j < grid.Width; j++)
            {
                positions.Add((i, j));
            }
        }
        
        positions = positions.OrderBy(_ => RandomNumberGenerator.GetInt32(0, int.MaxValue)).ToList();
        
        for (int i = 0; i < data.RelicAmount && i < positions.Count; i++)
        {
            var (x, y) = positions[i];
            grid.Tiles[x, y] = FloorTileType.Relic;
        }
        
        for (int i = data.RelicAmount; i < positions.Count; i++)
        {
            var (x, y) = positions[i];
            int randomTile = RandomNumberGenerator.GetInt32(1, 101);

            if (randomTile <= 80)
            {
                grid.Tiles[x, y] = RandomNumberGenerator.GetInt32(0, 2) == 0
                    ? FloorTileType.Danger
                    : FloorTileType.Empty;

                data.DangerAmount++;
            }
            else
            {
                grid.Tiles[x, y] = FloorTileType.Well;
                data.WellAmount++;
            }
        }
    }
}