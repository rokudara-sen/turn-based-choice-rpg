using TurnBasedChoiceRPG.Entities;
using TurnBasedChoiceRPG.Systems.Render;
using TurnBasedChoiceRPG.Systems.World;
using TurnBasedChoiceRPG.Utilities;

namespace TurnBasedChoiceRPG.Core;

public class GameLoop
{
    private List<Entity>? _floors;
    private int _currentFloorIndex;

    public void Initialize()
    {
        var worldInitSystem = ServiceLocatorUtils.GetRequiredService<WorldInitializationSystem>();

        _floors = worldInitSystem.InitializeWorld(15);
        _currentFloorIndex = 0;
    }

    public void RenderCurrentFloor()
    {
        var floorRenderSystem = ServiceLocatorUtils.GetRequiredService<FloorRenderSystem>();
        floorRenderSystem.RenderFloor(_floors?[_currentFloorIndex]);
    }
}