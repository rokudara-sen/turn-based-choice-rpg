using TurnBasedChoiceRPG.Core;
using TurnBasedChoiceRPG.Entities;
using TurnBasedChoiceRPG.Utilities;

namespace TurnBasedChoiceRPG.Systems.World;

public class WorldInitializationSystem
{
    public List<Entity> InitializeWorld(int floorCount)
    {
        var floors = new List<Entity>();
        var mapGenSystem = ServiceLocatorUtils.GetRequiredService<MapGenerationSystem>();
        
        ConsoleRenderer.LoadingVisual("Initializing World");

        for (int i = 0; i < floorCount; i++)
        {
            floors.Add(mapGenSystem.GenerateFloor(i, floorCount));
        }
        
        return floors;
    }
}